SELECT TOP (10)
	u.[Id] AS [UserId],
	u.[FullName] AS [FullName],
	SUM(s.[Price]) AS [TotalSpent]
FROM [Orders] AS o
	JOIN [Users] AS u ON o.[UserId] = u.[Id]
	JOIN [Shoes] AS s ON o.[ShoeId] = s.[Id]
GROUP BY u.[Id],
	     u.[FullName]
ORDER BY [TotalSpent] DESC, 
	     u.[FullName]