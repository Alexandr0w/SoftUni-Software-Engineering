SELECT u.[Username],
	   u.[Email],
	   CAST(AVG(s.[Price]) AS DECIMAL(5, 2)) AS [AvgPrice]
FROM [Orders] AS o
	JOIN [Users] AS u ON o.[UserId] = u.[Id]
	JOIN [Shoes] AS s ON o.[ShoeId] = s.[Id]
GROUP BY u.[Username],
	     u.[Email] HAVING COUNT(*) > 2
ORDER BY [AvgPrice] DESC