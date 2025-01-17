CREATE DATABASE [University]
GO

USE [University]
GO

CREATE TABLE [Majors] (
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(64) NOT NULL
)

CREATE TABLE [Students] (
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] INT NOT NULL,
	[StudentName] NVARCHAR(64) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments] (
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATETIME NOT NULL,
	[PaymentAmount] DECIMAL(10,2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)

CREATE TABLE [Subjects] (
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] NVARCHAR(64) NOT NULL
)

CREATE TABLE [Agenda] (
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]), 
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
	CONSTRAINT PK_Agenda PRIMARY KEY ([StudentID], [SubjectID])
)