DROP DATABASE IF EXISTS `logistics`;
CREATE DATABASE `logistics`;
USE logistics;

#таблиця для збереження інформації про користувачів
CREATE TABLE Users (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(255) CHECK (LENGTH(FirstName) >= 2 AND FirstName NOT REGEXP '[0-9]'),
    LastName VARCHAR(255) CHECK (LENGTH(LastName) >= 2 AND LastName NOT REGEXP '[0-9]'),
    PhoneNumber CHAR(10) UNIQUE CHECK (PhoneNumber REGEXP '^[0-9]{10}$'),
    `Password` VARCHAR(255) CHECK (LENGTH(`Password`) >= 8 AND `Password` NOT LIKE '% %'),
    `Role` ENUM('Клієнт','Адміністратор відділення','Адміністратор системи')
);

#таблиця для збереження інформації про відділення
CREATE TABLE Branch (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    City ENUM('Київ', 'Харків', 'Львів', 'Одеса', 'Тернопіль', 'Дніпро'),
    Address VARCHAR(255)
);

#таблиця яка закріплює адміністратора відділення за конкретним відділенням
CREATE TABLE BranchAdmins (
    UserID INT,
    BranchID INT,
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (BranchID) REFERENCES Branch(ID)
);

#таблиця яка створює маршрут з початковим та кінцевим пунктом призначення
CREATE TABLE Route (
    ID INT PRIMARY KEY,
    Origin INT,
    Destination INT,
    Duration TIME,
    FOREIGN KEY (Origin) REFERENCES Branch(ID),
    FOREIGN KEY (Destination) REFERENCES Branch(ID)
);

#таблиця яка додає проміжні віддімення для маршрутів
CREATE TABLE Route_Branch (
    RouteID INT,
    BranchID INT,
    FOREIGN KEY (RouteID) REFERENCES Route(ID),
    FOREIGN KEY (BranchID) REFERENCES Branch(ID)
);

#таблиця яка створює групу посилок з одною ттн
CREATE TABLE ParcelGroup (
    BillOfLading CHAR(14) PRIMARY KEY CHECK (LENGTH(TRIM(BillOfLading)) = 14),
    SenderUser INT,
    RecipientUser INT,
    Route INT,
    CurrentBranch INT,
    DeliveryPrice DECIMAL(10,2),  -- Ціна за доставку
    DispatchTime TIMESTAMP,
    DeliveryTime TIMESTAMP,
    FOREIGN KEY (SenderUser) REFERENCES Users(ID),
    FOREIGN KEY (RecipientUser) REFERENCES Users(ID),
    FOREIGN KEY (Route) REFERENCES Route(ID),
    FOREIGN KEY (CurrentBranch) REFERENCES Route(ID)
);

#таблиця яка містить інформацію про посилку
CREATE TABLE Package (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Weight DECIMAL(10,2),
    Status ENUM('Створено', 'Підтверджено', 'В_дорозі', 'Доставлено', 'Забрали', 'Втрачено'),
    Type ENUM('Документи', 'Посилка', 'ВеликийВантаж'),
    BillOfLading CHAR(14),
    ValuationPrice DECIMAL(10,2),  -- Оціночна вартість
    FOREIGN KEY (BillOfLading) REFERENCES ParcelGroup(BillOfLading)
);