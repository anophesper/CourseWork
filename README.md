# Створення програми для логістичних послуг

## Концепція та суть роботи

Цей курсовий проєкт, під назвою “Express Post”, є важливим інструментом для глибокого вивчення та розуміння логістичних систем. Він був розроблений з метою моделювання комплексної системи доставки пакунків, включаючи різні класи, що представляють ключові компоненти цієї системи. Ці класи взаємодіють для забезпечення плавного та ефективного процесу доставки.
Кожен клас виконує свою унікальну роль, допомагаючи моделювати різні аспекти процесу доставки. Крім того, проєкт включає різні ролі користувачів, що дозволяє моделювати взаємодію між ними та системою.
В загальному контексті, цей курсовий проєкт є цінним ресурсом для вивчення та розуміння, як ефективно організувати роботу в такій важливій сфері, як логістика.

## Діаграма Класів

![Діаграма Класів](https://github.com/anophesper/CourseWork/blob/master/UML-Diagram.svg)

## Детальний опис класів

### **IBranchAdmin**
- **MarkArrival(Parcel parcel)**: void
- **MarkDeparture(Parcel parcel)**: void

### **User (Абстрактний клас)**
- **ID:** Унікальний ідентифікатор користувача (int).
- **FirstName:** Ім'я користувача (String).
- **LastName:** Прізвище користувача (String).
- **PhoneNumber:** Номер телефону користувача (String).
- **Password:** Пароль користувача (String).

### **BranchAdmin (Наслідується від User, IBranchAdmin)**
- **Branch:** Відділення, за яким закріплений адміністратор (Branch).

### **SystemAdmin (Наслідується від User)**
- Немає додаткових атрибутів або асоціацій.

### **Client (Наслідується від User)**
- **Packages:** Список пакунків, що належать клієнту (List<ParcelGroup>).

### **Branch**
- **ID:** Унікальний ідентифікатор відділення (int).
- **City:** Місто де знаходиться відділення (Cities).
- **Address:** Адреса відділення (String).
- **ArrivedPackages:** Список пакунків, що прибули в відділення (List<ParcelGroup>).
- **PackagesToSend:** Список пакунків, що мають бути відправлені (List<ParcelGroup>).
- **GetBranchById(int id)**: static Branch

### **Route**
- **ID:** Унікальний ідентифікатор маршруту (int).
- **OriginBranch:** Початкове відділення маршруту (Branch).
- **DestinationBranch:** Кінцеве відділення маршруту (Branch).
- **SearchRoute(Branch origin, Branch destination)**: static Route
- **SearchRoute(int id)**: static Route

### **Parcel**
- **BillOfLading:** Унікальний ідентифікатор пакунка - ТТН (String).
- **SenderUser:** Відправник пакунка (User).
- **RecipientUser:** Отримувач пакунка (User).
- **IsSenderPay:** Чи оплачує відправник доставку (bool).
- **Route:** Маршрут (Route).
- **Type:** Тип пакунка (TypeP).
- **Weight:** Вага пакунка (float).
- **Status:** Статус пакунка (Enum.Status).
- **CurrentBranch:** Поточне відділення, де знаходиться пакунок (Branch).
- **IsConfirmedBranch:** Чи підтверджено відділення (bool).
- **DeliveryPrice:** Ціна за доставку (decimal).
- **DispatchTime:** Час відправки (DateTime).
- **DeliveryTime:** Час доставки (DateTime).
- **ValuationPrice:** Оціночна вартість пакунка (decimal).
- **GenerateBillOfLading()**: static string

#### Enums
- **Cities:** Київ, Харків, Львів, Одеса, Тернопіль, Дніпро
- **PackageType:** Документи, Посилка, Великий вантаж.
- **Status:** Створено, В дорозі, Доставлено, Забрали, Втрачено.

### **DBConnection**
- **connection**: static MySqlConnection
- **OpenConnection()**: static void
- **CloseConnection()**: static void
- **GetConnection()**: static MySqlConnection

### **DB_DataManager**
- **Users**: List<User>
- **Branches**: List<Branch>
- **Parcels**: List<Parcel>
- **Routes**: List<Route>
- **UsersInfo**: List<UserInfo>
- **LoadData**: static Action
- **GetUsers()**: void
- **AddParcelsToClients(List<UserInfo> usersInfo)**: void
- **GetBranchForUser(int userId)**: Branch
- **GetBranches()**: void
- **GetParcels()**: void
- **GetRoutes()**: void
- **InsertIntoDatabase(object obj)**: static void
- **UpdateDatabase(object obj)**: static void
- **DeleteFromDatabase(object obj)**: static void

### **UserInfo**
- **ID**: int
- **FirstName**: string
- **LastName**: string
- **PhoneNumber**: string
- **Password**: string
- **Role**: string
- **UserInfo(int id, string firstName, string lastName, string phoneNumber, string password, string role)**: конструктор
