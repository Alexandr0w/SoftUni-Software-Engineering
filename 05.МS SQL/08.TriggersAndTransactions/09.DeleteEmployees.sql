USE [SoftUni]
GO

CREATE TABLE [DeletedEmployees](
	[EmployeeId] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(50),
	[LastName] VARCHAR(50),
	[MiddleName] VARCHAR(50),
	[JobTitle] VARCHAR(50),
	[DepartmentID] INT,
	[Salary] MONEY
)
GO

CREATE OR ALTER TRIGGER [tr_DeletedEmployees]
ON [Employees] FOR DELETE
AS
BEGIN
    INSERT INTO [Deleted_Employees]([FirstName], [LastName], [MiddleName], [JobTitle], [DepartmentId], [Salary])
    SELECT d.[FirstName], 
		   d.[LastName], 
		   d.[MiddleName], 
		   d.[JobTitle], 
		   d.[DepartmentID], 
		   d.[Salary] 
	FROM [deleted] AS d
END