DROP DATABASE IF EXISTS `logistics`;
CREATE DATABASE `logistics`;
USE logistics;

#таблиця для збереження інформації про користувачів
CREATE TABLE Users (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL CHECK (LENGTH(FirstName) >= 2 AND FirstName NOT REGEXP '[0-9]'),
    LastName VARCHAR(255) NOT NULL CHECK (LENGTH(LastName) >= 2 AND LastName NOT REGEXP '[0-9]'),
    PhoneNumber CHAR(10) UNIQUE NOT NULL CHECK (PhoneNumber REGEXP '^[0-9]{10}$'),
    `Password` VARCHAR(255) NOT NULL CHECK (LENGTH(`Password`) >= 8 AND `Password` NOT LIKE '% %'),
    `Role` ENUM('Клієнт','Адміністратор відділення','Адміністратор системи') NOT NULL
);

#таблиця для збереження інформації про відділення
CREATE TABLE Branch (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    City ENUM('Київ', 'Харків', 'Львів', 'Одеса', 'Тернопіль', 'Дніпро') NOT NULL,
    Address VARCHAR(255) NOT NULL
);

#таблиця яка закріплює адміністратора відділення за конкретним відділенням
CREATE TABLE BranchAdmins (
    UserID INT NOT NULL,
    BranchID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (BranchID) REFERENCES Branch(ID)
);

#таблиця яка створює маршрут з початковим та кінцевим пунктом призначення
CREATE TABLE Route (
    ID INT PRIMARY KEY,
    Origin INT NOT NULL,
    Destination INT NOT NULL,
    Duration TIME NOT NULL,
    FOREIGN KEY (Origin) REFERENCES Branch(ID),
    FOREIGN KEY (Destination) REFERENCES Branch(ID)
);

#таблиця яка додає проміжні віддімення для маршрутів
CREATE TABLE Route_Branch (
    RouteID INT NOT NULL,
    BranchID INT NOT NULL,
    FOREIGN KEY (RouteID) REFERENCES Route(ID),
    FOREIGN KEY (BranchID) REFERENCES Branch(ID)
);

#таблиця яка створює групу посилок з одною ттн
CREATE TABLE ParcelGroup (
    BillOfLading CHAR(14) PRIMARY KEY NOT NULL CHECK (LENGTH(TRIM(BillOfLading)) = 14),
    SenderUser INT NOT NULL,
    RecipientUser INT NOT NULL,
    Route INT NOT NULL,
    CurrentBranch INT NOT NULL,
    DeliveryPrice DECIMAL(10,2) NOT NULL,  -- Ціна за доставку
    DispatchTime TIMESTAMP NOT NULL,
    DeliveryTime TIMESTAMP NOT NULL,
    FOREIGN KEY (SenderUser) REFERENCES Users(ID),
    FOREIGN KEY (RecipientUser) REFERENCES Users(ID),
    FOREIGN KEY (Route) REFERENCES Route(ID),
    FOREIGN KEY (CurrentBranch) REFERENCES Branch(ID)
);

#таблиця яка містить інформацію про посилку
CREATE TABLE Package (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Weight DECIMAL(10,2) NOT NULL,
    Status ENUM('Створено', 'Підтверджено', 'В_дорозі', 'Доставлено', 'Забрали', 'Втрачено') NOT NULL,
    Type ENUM('Документи', 'Посилка', 'ВеликийВантаж') NOT NULL,
    BillOfLading CHAR(14) NOT NULL,
    ValuationPrice DECIMAL(10,2) NOT NULL,  -- Оціночна вартість
    FOREIGN KEY (BillOfLading) REFERENCES ParcelGroup(BillOfLading)
);