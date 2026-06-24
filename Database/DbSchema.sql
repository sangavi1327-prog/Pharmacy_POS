-- Database Schema for SmartMed Pharmacy

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Admin')
BEGIN
    CREATE TABLE [Admin] (
        AdminID INT IDENTITY PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL,
        Password NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Customer')
BEGIN
    CREATE TABLE [Customer] (
        CustomerID INT IDENTITY PRIMARY KEY,
        FullName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        Phone NVARCHAR(20) NULL,
        Address NVARCHAR(200) NULL,
        Username NVARCHAR(50) NOT NULL,
        Password NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Medicine')
BEGIN
    CREATE TABLE [Medicine] (
        MedicineID INT IDENTITY PRIMARY KEY,
        MedicineName NVARCHAR(100) NOT NULL,
        Category NVARCHAR(100) NOT NULL,
        Dosage NVARCHAR(100) NULL,
        Price DECIMAL(10,2) NOT NULL,
        Stock INT NOT NULL,
        Supplier NVARCHAR(100) NULL,
        ExpiryDate DATE NOT NULL,
        Discount DECIMAL(5,2) DEFAULT 0.00
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Orders')
BEGIN
    CREATE TABLE [Orders] (
        OrderID INT IDENTITY PRIMARY KEY,
        CustomerID INT NOT NULL,
        OrderDate DATETIME NOT NULL,
        TotalAmount DECIMAL(10,2) NOT NULL,
        Status NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'OrderItems')
BEGIN
    CREATE TABLE [OrderItems] (
        OrderItemID INT IDENTITY PRIMARY KEY,
        OrderID INT NOT NULL,
        MedicineID INT NOT NULL,
        Quantity INT NOT NULL,
        Price DECIMAL(10,2) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Prescription')
BEGIN
    CREATE TABLE [Prescription] (
        PrescriptionID INT IDENTITY PRIMARY KEY,
        CustomerID INT NOT NULL,
        FilePath NVARCHAR(300) NOT NULL,
        UploadDate DATETIME NOT NULL
    );
END;
