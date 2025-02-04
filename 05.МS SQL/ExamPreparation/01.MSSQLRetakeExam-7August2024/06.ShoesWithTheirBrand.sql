SELECT b.[Name] AS [BrandName],
       s.[Model] AS [ShoeModel]
FROM [Shoes] AS s
JOIN [Brands] AS b ON s.[BrandId] = b.[Id]
ORDER BY b.[Name],
	     s.[Model]