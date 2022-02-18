CREATE DATABASE Webshop
GO

USE Webshop
GO


CREATE TABLE [PostalCodes] (
  [id] int IDENTITY,
  [city] varchar(50),
  [postalCode] varchar(6),
  [country] varchar(50),
  PRIMARY KEY ([id])
);



CREATE TABLE [Shipments] (
  [id] int IDENTITY,
  [companyName] varchar(100),
  [freight] int,
  PRIMARY KEY ([id])
);



CREATE TABLE [Categories] (
  [id] int IDENTITY,
  [categoryName] varchar(50),
  PRIMARY KEY ([id])
);



CREATE TABLE [SubCategories] (
  [id] int IDENTITY,
  [categoryId] int,
  [subCategoryName] varchar(50),
  PRIMARY KEY ([id]),
  CONSTRAINT [FK_SubCategories.categoryId]
    FOREIGN KEY ([categoryId])
      REFERENCES [Categories]([id])
);


CREATE TABLE [Suppliers] (
  [id] int IDENTITY,
  [name] varchar(50),
  [address] varchar(100),
  [phone] varchar(15),
  [postalCodeId] int,
  PRIMARY KEY ([id]),
  CONSTRAINT [FK_Suppliers.postalCodeId]
    FOREIGN KEY ([postalCodeId])
      REFERENCES [PostalCodes]([id])
);



CREATE TABLE [Products] (
  [id] int IDENTITY,
  [productName] varchar (100),
  [supplierId] int,
  [subCategoryId] int,
  [description] text,
  [unitPrice] float,
  [unitInStock] int,
  [size] varchar(5),
  [color] varchar(30),
  PRIMARY KEY ([id]),
  CONSTRAINT [FK_Products.supplierId]
    FOREIGN KEY ([supplierId])
      REFERENCES [Suppliers]([id]),
  CONSTRAINT [FK_Products.subCategoryId]
    FOREIGN KEY ([subCategoryId])
      REFERENCES [SubCategories]([id])
);



CREATE TABLE [Users] (
  [id] int IDENTITY,
  [firstName] varchar(50),
  [lastName] varchar(50),
  [address] varchar(100),
  [phone] varchar(15),
  [email] varchar(50),
  [admin] bit,
  [postalCodeId] int,
  [username] varchar(50) unique,
  [password] varchar(64), 
  PRIMARY KEY ([id]),
  CONSTRAINT [FK_Users.postalCodeId]
    FOREIGN KEY ([postalCodeId])
      REFERENCES [PostalCodes]([id])
);



CREATE TABLE [Payments] (
  [id] int IDENTITY,
  [paymentType] varchar(50),
  PRIMARY KEY ([id])
);



CREATE TABLE [Orders] (
  [id] int IDENTITY,
  [orderDate] datetime,
  [total] float,
  [billDate] datetime,
  [userId] int,
  [paymentId] int,
  [shipmentId] int,
  [tax] float,
  [shippedDate] date,
  PRIMARY KEY ([id]),
  CONSTRAINT [FK_Orders.userId]
    FOREIGN KEY ([userId])
      REFERENCES [Users]([id]),
  CONSTRAINT [FK_Orders.shipmentId]
    FOREIGN KEY ([shipmentId])
      REFERENCES [Shipments]([id]),
  CONSTRAINT [FK_Orders.paymentId]
    FOREIGN KEY ([paymentId])
      REFERENCES [Payments]([id])
);



CREATE TABLE [OrderDetails] (
  [orderId] int,
  [productId] int,
  [quantity] int,
  PRIMARY KEY ([orderId], [productId]),
  CONSTRAINT [FK_OrderDetails.orderId]
    FOREIGN KEY ([orderId])
      REFERENCES [Orders]([id]),
  CONSTRAINT [FK_OrderDetails.productId]
    FOREIGN KEY ([productId])
      REFERENCES [Products]([id])
);


