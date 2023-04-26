create table Brand(
BrandId int primary key identity(1,1),
Name varchar(20),
Description varchar(20)
)

CREATE TABLE Mobile (
    MobileID INT PRIMARY KEY identity(1,1),
    BrandID INT,
    Model VARCHAR(50),
    Description VARCHAR(500),
    Price DECIMAL(10, 2),
    CONSTRAINT FK_Mobile_BrandID FOREIGN KEY (BrandID) REFERENCES Brand(BrandID)
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY identity(1,1),
    Name VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(200)
);

CREATE TABLE Purchase (
    PurchaseID INT PRIMARY KEY identity(1,1),
    CustomerID INT,
    MobileID INT,
    PurchaseDate DATE,
    PurchasePrice DECIMAL(10, 2),
    Discount DECIMAL(10, 2),
    FinalPrice DECIMAL(10, 2),
    CONSTRAINT FK_Purchase_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    CONSTRAINT FK_Purchase_MobileID FOREIGN KEY (MobileID) REFERENCES Mobile(MobileID)
);

