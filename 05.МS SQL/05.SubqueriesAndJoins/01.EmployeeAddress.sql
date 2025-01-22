SELECT TOP(5) 
	e.[EmployeeId], 
	e.[JobTitle], 
	a.[AddressId], 
	a.[AddressText] 
FROM [Employees] AS e
JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
ORDER BY [AddressId]