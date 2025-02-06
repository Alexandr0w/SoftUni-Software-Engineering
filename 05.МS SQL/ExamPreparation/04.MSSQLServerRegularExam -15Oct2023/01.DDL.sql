CREATE DATABASE [TouristAgency]
GO

USE [TouristAgency]
GO

CREATE TABLE [Countries](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Destinations](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Rooms](
	[Id] INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	[Price] DECIMAL(18, 2) NOT NULL,
	[BedCount] INT NOT NULL
	CHECK([BedCount] > 0 AND [BedCount] <= 10)
)

CREATE TABLE [Hotels](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[DestinationId] INT FOREIGN KEY REFERENCES [Destinations]([Id]) NOT NULL
)

CREATE TABLE [Tourists](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Email] VARCHAR(80) NULL,
	[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id]) NOT NULL
)

CREATE TABLE [Bookings](
	[Id] INT PRIMARY KEY IDENTITY,
	[ArrivalDate] DATETIME2 NOT NULL,
	[DepartureDate] DATETIME2 NOT NULL,
	[AdultsCount] INT NOT NULL,
	CHECK([AdultsCount] >= 1 AND [AdultsCount] <= 10),
	[ChildrenCount] INT NOT NULL,
	CHECK([ChildrenCount] >= 0 AND [ChildrenCount] <= 9),
	[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]) NOT NULL,
	[HotelId] INT FOREIGN KEY REFERENCES [Hotels]([Id]) NOT NULL,
	[RoomId] INT FOREIGN KEY REFERENCES [Rooms]([Id]) NOT NULL
)

CREATE TABLE [HotelsRooms](
	[HotelId] INT NOT NULL,
	[RoomId] INT NOT NULL,
	CONSTRAINT [PK_HotelsRooms] PRIMARY KEY ([HotelId], [RoomId]),
	CONSTRAINT [FK_HotelsRooms_Hotels] FOREIGN KEY ([HotelId]) REFERENCES [Hotels]([Id]),
	CONSTRAINT [FK_HotelsRooms_Rooms] FOREIGN KEY ([RoomId]) REFERENCES [Rooms]([Id])
)