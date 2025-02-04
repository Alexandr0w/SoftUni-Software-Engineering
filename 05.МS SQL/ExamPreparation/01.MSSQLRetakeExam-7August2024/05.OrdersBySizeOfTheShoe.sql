SELECT s.[Model] AS [ShoeModel],
	   s.[Price]
FROM [Orders] AS o
JOIN [Shoes] AS s ON o.[ShoeId] = s.[Id]
ORDER BY [Price] DESC,
	     s.[Model]