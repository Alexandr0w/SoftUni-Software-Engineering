CREATE OR ALTER PROCEDURE [usp_EmployeesBySalaryLevel] @salaryLevel VARCHAR(20)
AS
(
	SELECT [FirstName],
		   [LastName]
	FROM [Employees]
	WHERE dbo.[ufn_GetSalaryLevel]([Salary]) = @salaryLevel
)
GO

EXEC [usp_EmployeesBySalaryLevel] 'High'