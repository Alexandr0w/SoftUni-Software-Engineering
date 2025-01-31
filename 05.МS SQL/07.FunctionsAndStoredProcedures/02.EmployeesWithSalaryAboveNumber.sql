CREATE OR ALTER PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @minSalary DECIMAL(18, 4)
AS (
		SELECT [FirstName],
			   [LastName]
		FROM [Employees]
		WHERE [Salary] >= @minSalary
   )
GO

EXEC [usp_GetEmployeesSalaryAboveNumber] 35000