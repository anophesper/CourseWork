using ExpressPost.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressPost
{
    public class DB_DataManager
    {
        //стоврюємо списки об'єктів різних класів для зберігання даних з бд
        public List<User> Users { get; set; }
        public List<Branch> Branches { get; set; }
        public List<Package> Packages { get; set; }
        public List<ParcelGroup> ParcelGroups { get; set; }
        public List<Route> Routes { get; set; }
        public List<UserInfo> UsersInfo { get; set; } //проміжний список для зберігання інформації про користувачів без розподілення на ролі

        private DBConnection dbConnection;
        // Делегат для завантаження даних
        public Action LoadData { get; private set; }

        public DB_DataManager(DBConnection dbConnection) 
        {
            this.dbConnection = dbConnection;
            // Ініціалізація делегата
            LoadData = () =>
            {
                GetBranches();
                GetPackages();
                GetUsers();
                GetRoutes();
                GetParcelGroups();
                AddParcelGroupsToClients(UsersInfo);
            };
        }

        public void GetUsers()
        {
            Users = new List<User>();//ініціалізуємо новий список користувачів
            dbConnection.openConnection(); //відкриваємо з'єднання з бд
            MySqlCommand command = new MySqlCommand("SELECT * FROM users", dbConnection.getConnection()); //створюємо запит MySQL
            MySqlDataReader reader = command.ExecuteReader(); //виконуємо запит

            //створення проміжного списку для зберігання інформації про користувачів
            UsersInfo = new List<UserInfo>();

            while (reader.Read())
            {
                //зчитуємо дані про користувача з поточного рядка результатів
                int id = Convert.ToInt32(reader["Id"]);
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string phoneNumber = reader["PhoneNumber"].ToString();
                string password = reader["Password"].ToString();
                string role = reader["Role"].ToString();

                //зберігаємо інформацію про користувача та додаємо об'єкт класу до списку
                UsersInfo.Add(new UserInfo(id, firstName, lastName, phoneNumber, password, role));
            }

            reader.Close();//закриваємо об'єкт MySqlDataReader після завершення читання результатів

            // Обробка інформації про користувачів після закриття reader
            foreach (UserInfo userInfo in UsersInfo)
            {
                User user;
                switch (userInfo.Role)//ділимо користувачів по ролям
                {
                    case "Адміністратор системи":
                        user = new SystemAdmin(userInfo.Id, userInfo.FirstName, userInfo.LastName, userInfo.PhoneNumber, userInfo.Password);
                        Users.Add(user);
                        break;
                    case "Адміністратор відділення":
                        Branch branch = GetBranchForUser(userInfo.Id); //знаходимо відділення за яким закріплений адміністратор за допомогою його id
                        user = new BranchAdmin(userInfo.Id, userInfo.FirstName, userInfo.LastName, userInfo.PhoneNumber, userInfo.Password, branch);
                        Users.Add(user);
                        break;
                    case "Клієнт":
                        user = new Client(userInfo.Id, userInfo.FirstName, userInfo.LastName, userInfo.PhoneNumber, userInfo.Password);
                        Users.Add(user);
                        break;
                    default:
                        throw new Exception($"Невідома роль");
                }
            }
            dbConnection.closeConnection();//закриваємо з'єднання
        }

        //метод для додавання посилок до вже існуючих клієнтів
        public void AddParcelGroupsToClients(List<UserInfo> usersInfo)
        {
            foreach (UserInfo userInfo in usersInfo)
            {
                if (userInfo.Role == "Клієнт")
                {
                    // Отримання груп посилок для цього користувача
                    dbConnection.openConnection();//відкриваємо з'єднання
                    MySqlCommand command = new MySqlCommand("SELECT BillOfLading FROM ParcelGroup WHERE SenderUser = @id OR RecipientUser = @id", dbConnection.getConnection());//прописуємо запит
                    command.Parameters.AddWithValue("@id", userInfo.Id);//вказуємо параметр за яким буде проводитись відбір даних
                    MySqlDataReader parcelGroupReader = command.ExecuteReader();//виконуємо запит

                    List<ParcelGroup> parcels = new List<ParcelGroup>();//ініціалізуємо список посилок який потім додамо до клієнта

                    while (parcelGroupReader.Read())
                    {
                        int billOfLading = Convert.ToInt32(parcelGroupReader["BillOfLading"]);//зчитуємо дані 
                        ParcelGroup parcelGroup = ParcelGroups.FirstOrDefault(pg => pg.BillOfLading == billOfLading);//шукаємо групу посилок з відповідним значенням "BillOfLading" в списку ParcelGroups
                        if (parcelGroup != null)
                            parcels.Add(parcelGroup);
                    }
                    parcelGroupReader.Close();//закриваємо об'єкт MySqlDataReader після завершення читання результатів
                    dbConnection.closeConnection();//закриваємо  з'єднання

                    // Додавання ParcelGroup до клієнта
                    Client client = (Client)Users.FirstOrDefault(u => u.Id == userInfo.Id);//шукаємо користувача з відповідним Id в списку Users і перетворюємо його в Client
                    if (client != null)
                        client.SetParcels(parcels); //якщо знайдено відповідного клієнта, встановлюємо його parcels на раніше зібраний список parcels
                }
            }
        }

        //метод для знаходження відділення за яким закріплений адміністратор
        public Branch GetBranchForUser(int userId)
        {
            dbConnection.openConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT BranchID FROM BranchAdmins WHERE UserID = @id", dbConnection.getConnection());//прописуємо запит
            command.Parameters.AddWithValue("@id", userId);//вказуємо параметр за яким буде проводитись відбір даних
            MySqlDataReader reader = command.ExecuteReader();//виконуємо запит

            Branch branch = null;
            if (reader.Read())
            {
                int branchId = Convert.ToInt32(reader["BranchID"]);//зчитуємо дані з результату
                branch = Branches.FirstOrDefault(b => b.Id == branchId);//шукаємо відділення зі списку Branches за допомогою Id
            }

            reader.Close();//закриваємо MySqlDataReader після обробки результатів
            dbConnection.closeConnection();//закриваємо з'єднання

            return branch;
        }

        public void GetBranches()
        {
            Branches = new List<Branch>();//ініціалізуємо список Відділень
            dbConnection.openConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT * FROM branch", dbConnection.getConnection());//створюємо запит
            MySqlDataReader reader = command.ExecuteReader();//виконуємо запит

            while (reader.Read())//зчитуємо дані
            {
                int id = Convert.ToInt32(reader["ID"]);
                Cities city = (Cities)Enum.Parse(typeof(Cities), reader["City"].ToString());
                string address = reader["Address"].ToString();

                Branch branch = new Branch(id, city, address);
                Branches.Add(branch);//додаємо відділення до списку
            }

            reader.Close();//закриваємо MySqlDataReader після обробки результатів
            dbConnection.closeConnection();//закриваємо з'єднання
        }

        public void GetPackages()
        {
            Packages = new List<Package>();//ініціалізуємо список посилок
            dbConnection.openConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT * FROM package", dbConnection.getConnection());//створюємо запит
            MySqlDataReader reader = command.ExecuteReader();//виконуємо запит

            while (reader.Read())//зчитуємо дані
            {
                int id = Convert.ToInt32(reader["Id"]);
                double weight = Convert.ToDouble(reader["Weight"]);
                Status packageStatus = (Status)Enum.Parse(typeof(Status), reader["Status"].ToString());
                TypeP parcelType = (TypeP)Enum.Parse(typeof(TypeP), reader["Type"].ToString());
                float valuationPrice = (float)Convert.ToDouble(reader["ValuationPrice"]);

                Package package = new Package(id, weight, packageStatus, parcelType, valuationPrice);
                Packages.Add(package);//додаємо посилку до списку
            }

            reader.Close();//закриваємо MySqlDataReader після обробки результатів
            dbConnection.closeConnection();//закриваємо з'єднання
        }

        public void GetParcelGroups()
        {
            ParcelGroups = new List<ParcelGroup>();//ініціалізуємо список груп посилок
            dbConnection.openConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT * FROM ParcelGroup", dbConnection.getConnection());//створюємо запит
            MySqlDataReader reader = command.ExecuteReader();//виконуємо запит

            while (reader.Read())//зчитуємо дані
            {
                int billOfLading = Convert.ToInt32(reader["BillOfLading"]);
                User sender = Users.FirstOrDefault(u => u.Id == Convert.ToInt32(reader["SenderUser"]));
                User recipient = Users.FirstOrDefault(u => u.Id == Convert.ToInt32(reader["RecipientUser"]));
                Route route = Routes.FirstOrDefault(r => r.Id == Convert.ToInt32(reader["Route"]));
                Branch currentBranch = Branches.FirstOrDefault(b => b.Id == Convert.ToInt32(reader["CurrentBranch"]));
                double deliveryPrise = Convert.ToDouble(reader["DeliveryPrice"]);
                DateTime date = Convert.ToDateTime(reader["DispatchTime"]);
                DateTime deliveryDate = Convert.ToDateTime(reader["DeliveryTime"]);

                ParcelGroup parcelGroup = new ParcelGroup(billOfLading, sender, recipient, route, currentBranch, deliveryPrise, date, deliveryDate);
                ParcelGroups.Add(parcelGroup);//додаємо групу посилок до списку
            }

            reader.Close();//закриваємо MySqlDataReader після обробки результатів

            foreach (ParcelGroup parcelGroup in ParcelGroups)
            {
                // Отримання пакунків для цієї групи посилок
                MySqlCommand command2 = new MySqlCommand("SELECT * FROM Package WHERE BillOfLading = @bill_of_lading", dbConnection.getConnection());//створюємо запит
                command2.Parameters.AddWithValue("@bill_of_lading", parcelGroup.BillOfLading);//вказуємо параметр за яким буде проводитись відбір даних
                MySqlDataReader packageReader = command2.ExecuteReader();//виконуємо запит

                List<Package> packages = new List<Package>();//ініціалізуємо список посилок
                while (packageReader.Read())//зчитуємо дані
                {
                    int id = Convert.ToInt32(packageReader["ID"]);
                    double weight = Convert.ToDouble(packageReader["Weight"]);
                    Status status = (Status)Enum.Parse(typeof(Status), packageReader["Status"].ToString());
                    TypeP type = (TypeP)Enum.Parse(typeof(TypeP), packageReader["Type"].ToString());
                    float valuationPrice = (float)Convert.ToDouble(packageReader["ValuationPrice"]);

                    Package package = new Package(id, weight, status, type, valuationPrice);
                    packages.Add(package);//додаємо посилку до списку
                }
                packageReader.Close();//закриваємо MySqlDataReader після обробки результатів

                parcelGroup.Packages = packages; //встановлюємо значення Packages для parcelGroup на раніше зібраний список packages
            }
            dbConnection.closeConnection();//закриваємо з'єднання
        }

        public void GetRoutes()
        {
            Routes = new List<Route>();//ініціалізуємо список маршрутів
            dbConnection.openConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT * FROM Route", dbConnection.getConnection());//створюємо запит
            MySqlDataReader reader = command.ExecuteReader();//виконуємо запит

            List<Route> routes = new List<Route>();//ініціалізуємо допоміжний список (зберігаємо в ньому тільки початкове відділення та кінцеве)

            while (reader.Read())//зчитуємо дані
            {
                int id = Convert.ToInt32(reader["ID"]);
                Branch origin = Branches.FirstOrDefault(b => b.Id == Convert.ToInt32(reader["Origin"]));
                Branch destination = Branches.FirstOrDefault(b => b.Id == Convert.ToInt32(reader["Destination"]));
                TimeSpan duration = (TimeSpan)reader["Duration"];

                Route route = new Route(id, origin, destination, duration);
                routes.Add(route);//додаємо маршрут до списку
            }
            reader.Close();//закриваємо MySqlDataReader після обробки результатів

            foreach (Route route in routes)
            {
                // Отримання проміжних відділень
                MySqlCommand command2 = new MySqlCommand("SELECT BranchID FROM Route_Branch WHERE RouteID = @id", dbConnection.getConnection());//створюємо запит
                command2.Parameters.AddWithValue("@id", route.Id);//вказуємо параметр за яким буде проводитись відбір даних
                MySqlDataReader reader2 = command2.ExecuteReader();//виконуємо запит
                List<Branch> intermediateBranches = new List<Branch>();//ініціалізуємо допоміжний список (зберігаємо в ньому тільки проміжні відділення
                while (reader2.Read())//зчитуємо дані
                {
                    Branch branch = Branches.FirstOrDefault(b => b.Id == Convert.ToInt32(reader2["BranchID"]));
                    if (branch != null)
                        intermediateBranches.Add(branch);//якщо проміжні відділення є додаємо їх до списку
                }
                reader2.Close();//закриваємо MySqlDataReader після обробки результатів

                route.SetIntermediateBranches(intermediateBranches);//встановлюємо список проміжних відділень для маршруту
                Routes.Add(route);//додаємо маршрут до загального списку маршрутів
            }
            dbConnection.closeConnection();//закриваємо з'єднання
        }
    }
}