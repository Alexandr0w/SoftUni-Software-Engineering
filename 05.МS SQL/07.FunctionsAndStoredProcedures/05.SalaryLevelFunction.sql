CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20)
BEGIN
    DECLARE @salaryLevel VARCHAR(20)

    IF (@salary < 30000)
        SET @salaryLevel = 'Low'
    ELSE IF (@salary BETWEEN 30000 AND 50000)
        SET @salaryLevel = 'Average'
    ELSE
        SET @salaryLevel = 'High'
RETURN @salaryLevel
END

GO

SELECT [FirstName],
       [LastName],
       [Salary],
       dbo.[ufn_GetSalaryLevel]([Salary]) AS [Salary Level]
  FROM [Employees]