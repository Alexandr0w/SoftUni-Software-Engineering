CREATE DATABASE [CarRental]
GO

USE [CarRental]
GO

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[DailyRate] DECIMAL(2, 1),
	[WeeklyRate] DECIMAL(2, 1),
	[MountlyRate] DECIMAL(2, 1),
	[WeekendRate] DECIMAL(2, 1)
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MountlyRate], [WeekendRate])
VALUES
('Small', 3.4, 5.4, 2.3, 5),
('SUV', 3.4, 5.4, 2.3, 5),
('Medium', 3.4, NULL, NULL, NULL)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[PlateNumber] NVARCHAR(10) NOT NULL,
	[Manufacturer] NVARCHAR(20) NOT NULL,
	[Model] NVARCHAR(20) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] IMAGE,
	[Condition] VARCHAR(20) NOT NULL,
	[Available] BIT NOT NULL
)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], 
[CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES
('ÂÍ2599ÀÂ', 'BMW', 'M5', 2019, 2, 4, NULL, 'Good', 1),
('ÂÍ7797ÀÂ', 'Mercedes', 'A180', 2005, 3, 4, NULL, 'Good', 0),
('ÂÍ2510ÀÊ', 'Honda', 'FR-V', 2005, 1, 4, NULL, 'Good', 0)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Title] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
VALUES
('Alexander', 'Yordanov', 'Something', NULL),
('Milena', 'Borisova', 'Something', NULL),
('Miroslav', 'Dimitrov', 'Something', 'Something')

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] NVARCHAR(40) NOT NULL,
	[Address] NVARCHAR(40) NOT NULL,
	[City] NVARCHAR(70) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
	VALUES
('094343', 'Alexander Yordanov', 'str. Something', 'Sofia', 1424, NULL),
('754235', 'Milena Borisova', 'str. Something', 'Vidin', 3700, 'Something'),
('743646', 'Miroslav Dimitrov', 'str. Something', 'Varna', 9000, 'Something')

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] INT NOT NULL,
	[TaxRate] INT NOT NULL,
	[OrderStatus] VARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], 
[KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], 
[OrderStatus], [Notes])
VALUES
(2, 2, 2, 54, 1424, 1535, 43, '2000-03-05', '2000-03-17', 2, 4, 4, 'Done', NULL),
(3, 3, 3, 154, 5353, 5656, 446, '2000-12-15', '2000-12-17', 6, 6, 10, 'Done', NULL),
(1, 1, 1, 75, 536446, 546644, 545, '1999-03-15', '1999-04-17', 12, 7, 3, 'Done', 'Something')