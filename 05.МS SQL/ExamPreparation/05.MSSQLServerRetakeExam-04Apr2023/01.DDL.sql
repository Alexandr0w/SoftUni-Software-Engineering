CREATE DATABASE [Accounting]
GO

USE [Accounting]
GO

CREATE TABLE [Countries](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Addresses](
	[Id] INT PRIMARY KEY IDENTITY,
	[StreetName] NVARCHAR(20) NOT NULL,
	[StreetNumber] INT NULL,
	[PostCode] INT NOT NULL,
	[City] VARCHAR(25) NOT NULL,
	[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Vendors](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[NumberVAT] NVARCHAR(15) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [Clients](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[NumberVAT] NVARCHAR(15) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Products](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	[Price] DECIMAL(18, 2) NOT NULL,
	[CategoryId] INT NOT NULL,
	[VendorId] INT NOT NULL,
	CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
	CONSTRAINT [FK_Products_Vendors] FOREIGN KEY ([VendorId]) REFERENCES [Vendors]([Id])
)

CREATE TABLE [Invoices](
	[Id] INT PRIMARY KEY IDENTITY,
	[Number] INT UNIQUE NOT NULL,
	[IssueDate] DATETIME2 NOT NULL,
	[DueDate] DATETIME2 NOT NULL,
	[Amount] DECIMAL(18, 2) NOT NULL,
	[Currency] VARCHAR(5) NOT NULL,
	[ClientId] INT NOT NULL,
	CONSTRAINT [FK_Invoices_Clients] FOREIGN KEY ([ClientId]) REFERENCES [Clients]([Id])
)

CREATE TABLE [ProductsClients](
	[ProductId] INT NOT NULL,
	[ClientId] INT NOT NULL,
	CONSTRAINT [PK_ProductsClients] PRIMARY KEY ([ProductId], [ClientId]),
	CONSTRAINT [FK_ProductsClients_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]),
	CONSTRAINT [FK_ProductsClients_Clients] FOREIGN KEY ([ClientId]) REFERENCES [Clients]([Id])
)