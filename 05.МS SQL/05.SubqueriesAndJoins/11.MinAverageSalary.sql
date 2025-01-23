SELECT 
	MIN(avs.[MinAverageSalary]) AS [MinAverageSalary]
	FROM 
	(
		SELECT 
			AVG([Salary]) AS [MinAvgSalary]
		FROM [Employees]
		GROUP BY [DepartmentID]
	) AS avs