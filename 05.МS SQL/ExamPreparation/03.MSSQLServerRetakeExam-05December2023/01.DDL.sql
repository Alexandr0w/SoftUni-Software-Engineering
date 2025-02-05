CREATE DATABASE [RailwaysDb]
GO

USE [RailwaysDb]
GO

CREATE TABLE [Passengers](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [RailwayStations](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [Trains](
	[Id] INT PRIMARY KEY IDENTITY,
	[HourOfDeparture] VARCHAR(5) NOT NULL,
	[HourOfArrival] VARCHAR(5) NOT NULL,
	[DepartureTownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL,
	[ArrivalTownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [TrainsRailwayStations](
	[TrainId] INT NOT NULL,
	[RailwayStationId] INT NOT NULL,
	CONSTRAINT [PK_TrainsRailwayStations] PRIMARY KEY ([TrainId], [RailwayStationId]),
    	CONSTRAINT [FK_TrainsRailwayStations_Trains] FOREIGN KEY ([TrainId]) REFERENCES [Trains]([Id]),
    	CONSTRAINT [FK_TrainsRailwayStations_RailwayStations] FOREIGN KEY ([RailwayStationId]) REFERENCES [RailwayStations]([Id])
)

CREATE TABLE [MaintenanceRecords](
	[Id] INT PRIMARY KEY IDENTITY,
	[DateOfMaintenance] DATE NOT NULL,
	[Details] VARCHAR(2000) NOT NULL,
	[TrainId] INT FOREIGN KEY REFERENCES [Trains]([Id]) NOT NULL
)

CREATE TABLE [Tickets](
	[Id] INT PRIMARY KEY IDENTITY,
	[Price] DECIMAL(18, 2) NOT NULL,
	[DateOfDeparture] DATE NOT NULL,
	[DateOfArrival] DATE NOT NULL,
	[TrainId] INT FOREIGN KEY REFERENCES [Trains]([Id]) NOT NULL,
	[PassengerId] INT FOREIGN KEY REFERENCES [Passengers]([Id]) NOT NULL
)
