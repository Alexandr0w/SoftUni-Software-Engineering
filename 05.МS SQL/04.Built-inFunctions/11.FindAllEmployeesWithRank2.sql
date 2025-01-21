--01.Solution with View
CREATE VIEW [V_EmployeesRankedByEmployeeID]
AS
(
	SELECT [EmployeeID]
		  ,[FirstName]
		  ,[LastName]
		  ,[Salary]
		  ,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	 FROM [Employees]
    WHERE [Salary] BETWEEN 10000 AND 50000
)
GO

SELECT *
FROM [dbo].[V_EmployeesRankedByEmployeeID]
WHERE [Rank] = 2
ORDER BY [Salary] DESC

--02.Solution without View (for Judge)!
SELECT *
FROM (
	SELECT [EmployeeID]
		  ,[FirstName]
		  ,[LastName]
		  ,[Salary]
		  ,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) 
	    AS [Rank]
	  FROM [Employees]
	 WHERE [Salary] BETWEEN 10000 AND 50000
	 ) 
   AS [Table]
WHERE [Rank] = 2
ORDER BY [Salary] DESC