# Створення програми для логістичних послуг

## Концепція та суть роботи

Цей курсовий проєкт створений для моделювання системи доставки пакунків. Він включає різні класи, які представляють різні компоненти системи. Класи взаємодіють один з одним для забезпечення плавного та ефективного процесу доставки. Кожен з цих класів виконує важливу роль у системі доставки пакунків, допомагаючи моделювати різні аспекти процесу доставки. Крім того, цей проєкт також включає в себе різні ролі користувачів, що дозволяє моделювати взаємодію між ними. Загалом, цей курсовий проєкт є цінним ресурсом для вивчення та розуміння, як ефективно організувати роботу такої структури як пошта.

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

### **PackageGroup**
- **BillOfLading:** Унікальний ідентифікатор групи пакунків - ТТН (String).
- **Sender:** Відправник пакунків (User).
- **Recipient:** Отримувач пакунків (User).
- **Route:** Маршрут (Route).
- **Packages:** Посилки закріплені за ТТН (List<Package>).
- **DeliveryPrice:** Ціна за достовку (Double).
- **Date:** Дата відправки пакунка (DateTime).
- **DeliveryDate:** Дата доставки пакунка (DateTime).

### **Package**
- **ID:** Унікальний ідентифікатор пакунка (int).
- **Weight:** Вага пакунка (float).
- **Status:** Статус пакунка (Enum Status).
- **Type:** Тип пакунка (Enum PackageType).
- **ValuationPrice:** Оціночна вартість пакунка (float).
- **GenerateBillOfLading()**: static string

#### Enums
- **Cities:** Київ, Харків, Львів, Одеса, Тернопіль, Дніпро
- **PackageType:** Документи, Посилка, Великий вантаж.
- **Status:** Створено, Підтверджено, В дорозі, Доставлено, Забрали, Втрачено.

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
