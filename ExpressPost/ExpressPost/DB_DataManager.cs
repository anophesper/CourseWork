using ExpressPost.Classes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
        public List<Parcel> Parcels { get; set; }
        public List<Route> Routes { get; set; }
        public List<UserInfo> UsersInfo { get; set; } //проміжний список для зберігання інформації про користувачів без розподілення на ролі

        // Делегат для завантаження даних
        public static Action LoadData { get; private set; }

        public DB_DataManager() 
        {
            // Ініціалізація делегата
            LoadData = () =>
            {
                GetBranches();
                GetUsers();
                GetRoutes();
                GetParcels();
                AddParcelsToClients(UsersInfo);
            };
        }

        public void GetUsers()
        {
            Users = new List<User>();//ініціалізуємо новий список користувачів
            DBConnection.OpenConnection(); //відкриваємо з'єднання з бд
            MySqlCommand command = new MySqlCommand("SELECT * FROM users", DBConnection.GetConnection()); //створюємо запит MySQL
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
                        user = new Classes.Client(userInfo.Id, userInfo.FirstName, userInfo.LastName, userInfo.PhoneNumber, userInfo.Password);
                        Users.Add(user);
                        break;
                    default:
                        throw new Exception($"Невідома роль");
                }
            }
            DBConnection.CloseConnection();//закриваємо з'єднання
        }

        //метод для додавання посилок до вже існуючих клієнтів
        public void AddParcelsToClients(List<UserInfo> usersInfo)
        {
            foreach (UserInfo userInfo in usersInfo)
            {
                if (userInfo.Role == "Клієнт")
                {
                    // Отримання посилок для цього користувача
                    DBConnection.OpenConnection(); // відкриваємо з'єднання
                    MySqlCommand command = new MySqlCommand("SELECT BillOfLading FROM ParcelUsers WHERE SenderUser = @id OR RecipientUser = @id", DBConnection.GetConnection()); // прописуємо запит
                    command.Parameters.AddWithValue("@id", userInfo.Id); // вказуємо параметр за яким буде проводитись відбір даних
                    MySqlDataReader parcelReader = command.ExecuteReader(); // виконуємо запит

                    Parcels = new List<Parcel>(); // ініціалізуємо список посилок який потім додамо до клієнта

                    while (parcelReader.Read())
                    {
                        string billOfLading = parcelReader["BillOfLading"].ToString(); // зчитуємо дані 
                        Parcel parcel = Parcels.FirstOrDefault(p => p.BillOfLading == billOfLading); // шукаємо посилку з відповідним значенням "BillOfLading" в списку Parcels
                        if (parcel != null)
                            Parcels.Add(parcel);
                    }
                    parcelReader.Close(); // закриваємо об'єкт MySqlDataReader після завершення читання результатів
                    DBConnection.CloseConnection(); // закриваємо з'єднання

                    // Додавання Parcel до клієнта
                    Classes.Client client = (Classes.Client)Users.FirstOrDefault(u => u.Id == userInfo.Id); // шукаємо користувача з відповідним Id в списку Users і перетворюємо його в Client
                    if (client != null)
                        client.Parcels = Parcels; // якщо знайдено відповідного клієнта, встановлюємо його parcels на раніше зібраний список parcels
                }
            }
        }

        //метод для знаходження відділення за яким закріплений адміністратор
        public Branch GetBranchForUser(int userId)
        {
            DBConnection.OpenConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT BranchID FROM BranchAdmins WHERE UserID = @id", DBConnection.GetConnection());//прописуємо запит
            command.Parameters.AddWithValue("@id", userId);//вказуємо параметр за яким буде проводитись відбір даних
            MySqlDataReader reader = command.ExecuteReader();//виконуємо запит

            Branch branch = null;
            if (reader.Read())
            {
                int branchId = Convert.ToInt32(reader["BranchID"]);//зчитуємо дані з результату
                branch = Branches.FirstOrDefault(b => b.Id == branchId);//шукаємо відділення зі списку Branches за допомогою Id
            }

            reader.Close();//закриваємо MySqlDataReader після обробки результатів
            DBConnection.CloseConnection();//закриваємо з'єднання

            return branch;
        }

        public void GetBranches()
        {
            Branches = new List<Branch>();//ініціалізуємо список Відділень
            DBConnection.OpenConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT * FROM branch", DBConnection.GetConnection());//створюємо запит
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
            DBConnection.CloseConnection();//закриваємо з'єднання
        }

        public void GetParcels()
        {
            Parcels = new List<Parcel>(); // ініціалізуємо список посилок
            DBConnection.OpenConnection(); // відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT Parcel.*, ParcelUsers.SenderUser, ParcelUsers.RecipientUser, ParcelUsers.IsSenderPay, " +
                "ParcelRouteDelivery.Route, ParcelRouteDelivery.CurrentBranch, ParcelRouteDelivery.IsConfirmedBranch, " +
                "ParcelRouteDelivery.DeliveryPrice, ParcelRouteDelivery.DispatchTime, ParcelRouteDelivery.DeliveryTime FROM Parcel INNER JOIN " +
                "ParcelUsers ON Parcel.BillOfLading = ParcelUsers.BillOfLading INNER JOIN ParcelRouteDelivery ON Parcel.BillOfLading = " +
                "ParcelRouteDelivery.BillOfLading", DBConnection.GetConnection()); // створюємо запит
            MySqlDataReader reader = command.ExecuteReader(); // виконуємо запит

            while (reader.Read()) // зчитуємо дані
            {
                string billOfLading = reader["BillOfLading"].ToString();
                User senderUser = User.GetUserById(Convert.ToInt32(reader["SenderUser"]));
                User recipientUser = User.GetUserById(Convert.ToInt32(reader["RecipientUser"]));
                bool isSenderPay = Convert.ToBoolean(reader["IsSenderPay"]);
                Route route = Route.SearchRoute((Convert.ToInt32(reader["Route"])));
                string type = reader["Type"].ToString();
                double weight = Convert.ToDouble(reader["Weight"]);
                Status status = (Status)Enum.Parse(typeof(Status), reader["Status"].ToString());
                Branch currentBranch = Branch.GetBranchById(Convert.ToInt32(reader["CurrentBranch"]));
                bool isConfirmedBranch = Convert.ToBoolean(reader["IsConfirmedBranch"]);  // Нове поле
                decimal deliveryPrice = Convert.ToDecimal(reader["DeliveryPrice"]);
                DateTime dispatchTime = Convert.ToDateTime(reader["DispatchTime"]);
                DateTime deliveryTime = Convert.ToDateTime(reader["DeliveryTime"]);
                decimal valuationPrice = Convert.ToDecimal(reader["ValuationPrice"]);

                Parcel parcel = new Parcel(billOfLading, senderUser, recipientUser, isSenderPay, route, type, weight, status, currentBranch, isConfirmedBranch, deliveryPrice, dispatchTime, deliveryTime, valuationPrice);
                Parcels.Add(parcel); // додаємо посилку до списку
            }
            reader.Close(); // закриваємо MySqlDataReader після обробки результатів
            DBConnection.CloseConnection(); // закриваємо з'єднання
        }

        public void GetRoutes()
        {
            Routes = new List<Route>();//ініціалізуємо список маршрутів
            DBConnection.OpenConnection();//відкриваємо з'єднання
            MySqlCommand command = new MySqlCommand("SELECT * FROM Route", DBConnection.GetConnection());//створюємо запит
            MySqlDataReader reader = command.ExecuteReader();//виконуємо запит

            List<Route> routes = new List<Route>();//ініціалізуємо допоміжний список (зберігаємо в ньому тільки початкове відділення та кінцеве)

            while (reader.Read())//зчитуємо дані
            {
                int id = Convert.ToInt32(reader["ID"]);
                Branch origin = Branches.FirstOrDefault(b => b.Id == Convert.ToInt32(reader["Origin"]));
                Branch destination = Branches.FirstOrDefault(b => b.Id == Convert.ToInt32(reader["Destination"]));
                double duration = (double)reader["Duration"];

                Route route = new Route(id, origin, destination, duration);
                routes.Add(route);//додаємо маршрут до списку
            }
            reader.Close();//закриваємо MySqlDataReader після обробки результатів

            foreach (Route route in routes)
            {
                // Отримання проміжних відділень
                MySqlCommand command2 = new MySqlCommand("SELECT BranchID FROM Route_Branch WHERE RouteID = @id", DBConnection.GetConnection());//створюємо запит
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
            DBConnection.CloseConnection();//закриваємо з'єднання
        }

        public static void InsertIntoDatabase(object obj)
        {
            DBConnection.OpenConnection(); //відкриваємо з'єднання з бд
            MySqlCommand command;
            MySqlCommand command2;

            switch (obj)
            {
                case Branch branch:
                    // Вставляємо дані про відділення в таблицю Branch
                    command = new MySqlCommand($"INSERT INTO Branch (City, Address) VALUES ('{branch.City}', '{branch.Address}')", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    break;
                case BranchAdmin branchAdmin:
                    // Вставляємо дані про адміністратора відділення в таблицю Users
                    command = new MySqlCommand($"INSERT INTO Users (FirstName, LastName, PhoneNumber, Password, Role) VALUES ('{branchAdmin.FirstName}', '{branchAdmin.LastName}', '{branchAdmin.PhoneNumber}', '{branchAdmin.Password}', 'Адміністратор відділення')", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                                               // Вставляємо дані про адміністратора відділення в таблицю BranchAdmins
                    command2 = new MySqlCommand($"INSERT INTO BranchAdmins (UserID, BranchID) VALUES (LAST_INSERT_ID(), '{branchAdmin.Branch.Id}')", DBConnection.GetConnection());
                    command2.ExecuteNonQuery(); //виконуємо запит
                    break;
                case Classes.Client client:
                    // Вставляємо дані про клієнта в таблицю Users
                    command = new MySqlCommand($"INSERT INTO Users (FirstName, LastName, PhoneNumber, Password, Role) VALUES ('{client.FirstName}', '{client.LastName}', '{client.PhoneNumber}', '{client.Password}', 'Клієнт')", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    break;
                case SystemAdmin systemAdmin:
                    // Вставляємо дані про адміністратора системи в таблицю Users
                    command = new MySqlCommand($"INSERT INTO Users (FirstName, LastName, PhoneNumber, Password, Role) VALUES ('{systemAdmin.FirstName}', '{systemAdmin.LastName}', '{systemAdmin.PhoneNumber}', '{systemAdmin.Password}', 'Адміністратор системи')", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    break;
                case Route route:
                    // Вставляємо дані про маршрут в таблицю Route
                    command = new MySqlCommand($"INSERT INTO Route (ID, Origin, Destination, Duration) VALUES ('{route.Id}', '{route.Origin.Id}', '{route.Destination.Id}', '{route.Duration}')", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    foreach (Branch branch in route.GetIntermediateBranches())
                    {
                        // Вставляємо дані про проміжні відділення в таблицю Route_Branch
                        command2 = new MySqlCommand($"INSERT INTO Route_Branch (RouteID, BranchID) VALUES (LAST_INSERT_ID(), '{branch.Id}')", DBConnection.GetConnection());
                        command2.ExecuteNonQuery(); //виконуємо запит
                    }
                    break;
                case Parcel parcel:
                    // Вставляємо дані про посилку в таблицю Parcel
                    command = new MySqlCommand($"INSERT INTO Parcel (BillOfLading, Type, Weight, Status, ValuationPrice) VALUES ('{parcel.BillOfLading}', '{parcel.Type}', '{parcel.Weight}', '{parcel.Status}', '{parcel.ValuationPrice}')", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит

                    // Вставляємо дані про відправника та отримувача в таблицю ParcelUsers
                    command = new MySqlCommand($"INSERT INTO ParcelUsers (BillOfLading, SenderUser, RecipientUser, IsSenderPay) VALUES ('{parcel.BillOfLading}', '{parcel.SenderUser.Id}', '{parcel.RecipientUser.Id}', '{parcel.IsSenderPay}')", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит

                    // Перевіряємо, чи було створено об'єкт parcel за допомогою першого конструктора
                    if (parcel.Route != null)
                    {
                        // Конвертуємо DateTime в рядок у форматі, який MySQL може правильно обробити
                        string dispatchTimeString = parcel.DispatchTime.ToString("yyyy-MM-dd HH:mm:ss");
                        string deliveryTimeString = parcel.DeliveryTime.ToString("yyyy-MM-dd HH:mm:ss");

                        // Вставляємо дані про маршрут, поточне відділення, підтвердження відділення, ціну доставки, час відправки та час доставки в таблицю ParcelRouteDelivery
                        command = new MySqlCommand($"INSERT INTO ParcelRouteDelivery (BillOfLading, Route, CurrentBranch, IsConfirmedBranch, DeliveryPrice, DispatchTime, DeliveryTime) VALUES ('{parcel.BillOfLading}', '{parcel.Route.Id}', '{parcel.CurrentBranch.Id}', '{parcel.IsConfirmedBranch}', '{parcel.DeliveryPrice}', '{dispatchTimeString}', '{deliveryTimeString}')", DBConnection.GetConnection());
                        command.ExecuteNonQuery(); //виконуємо запит
                    }
                    break;
                default:
                    throw new Exception("Невідомий тип об'єкта");
            }
            LoadData();
            DBConnection.CloseConnection(); //закриваємо з'єднання з бд
        }

        public static void UpdateDatabase(object obj)
        {
            DBConnection.OpenConnection(); //відкриваємо з'єднання з бд
            MySqlCommand command;

            switch (obj)
            {
                case User user:
                    // Оновлюємо дані про користувача в таблиці Users
                    command = new MySqlCommand($"UPDATE Users SET FirstName = '{user.FirstName}', LastName = '{user.LastName}', PhoneNumber = '{user.PhoneNumber}', Password = '{user.Password}' WHERE Id = '{user.Id}'", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    break;
                case Branch branch:
                    // Оновлюємо дані про відділення в таблиці Branch
                    command = new MySqlCommand($"UPDATE Branch SET City = '{branch.City}', Address = '{branch.Address}' WHERE Id = '{branch.Id}'", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    break;
                case Route route:
                    // Оновлюємо дані про маршрут в таблиці Route
                    command = new MySqlCommand($"UPDATE Route SET Origin = '{route.Origin.Id}', Destination = '{route.Destination.Id}', Duration = '{route.Duration}' WHERE ID = '{route.Id}'", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    break;
                case Parcel parcel:
                    // Оновлюємо дані про посилку в таблиці Parcel
                    command = new MySqlCommand($"UPDATE Parcel SET Type = '{parcel.Type}', Weight = '{parcel.Weight}', Status = '{parcel.Status}', ValuationPrice = '{parcel.ValuationPrice}' WHERE BillOfLading = '{parcel.BillOfLading}'", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит

                    // Оновлюємо дані про відправника та отримувача в таблиці ParcelUsers
                    command = new MySqlCommand($"UPDATE ParcelUsers SET SenderUser = '{parcel.SenderUser.Id}', RecipientUser = '{parcel.RecipientUser.Id}', IsSenderPay = '{parcel.IsSenderPay}' WHERE BillOfLading = '{parcel.BillOfLading}'", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит

                    // Оновлюємо дані про маршрут, поточне відділення, підтвердження відділення, ціну доставки, час відправки та час доставки в таблиці ParcelRouteDelivery
                    command = new MySqlCommand($"UPDATE ParcelRouteDelivery SET Route = '{parcel.Route.Id}', CurrentBranch = '{parcel.CurrentBranch.Id}', IsConfirmedBranch = '{parcel.IsConfirmedBranch}', DeliveryPrice = '{parcel.DeliveryPrice}', DispatchTime = '{parcel.DispatchTime}', DeliveryTime = '{parcel.DeliveryTime}' WHERE BillOfLading = '{parcel.BillOfLading}'", DBConnection.GetConnection());
                    command.ExecuteNonQuery(); //виконуємо запит
                    break;
                default:
                    throw new Exception("Невідомий тип об'єкта");
            }
            LoadData();
            DBConnection.CloseConnection(); //закриваємо з'єднання з бд
        }
    }
}
