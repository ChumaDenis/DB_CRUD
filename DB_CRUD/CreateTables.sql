use DB_CRUD
CREATE TABLE dbo.Users (
    UserID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Login VARCHAR(20) NOT NULL UNIQUE,
    Password VARCHAR(50),
    FirstName VARCHAR(40),
    LastName VARCHAR(40),
    DateOfBirth DATE,
    Gender CHAR(1) CHECK (Gender IN ('M', 'F'))
);

CREATE TABLE dbo.Orders (
    OrderID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    OrderDate DATE,
    OrderCost MONEY,
    ItemsDescription VARCHAR(1000),
    ShippingAddress VARCHAR(1000),
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE NO ACTION,
    CONSTRAINT UC_UserOrderDate UNIQUE (UserID, OrderDate)
);

