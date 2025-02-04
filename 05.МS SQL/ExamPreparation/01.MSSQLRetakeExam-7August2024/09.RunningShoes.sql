SELECT s.[Model],
	   COUNT(sz.[SizeId]) AS [CountOfSizes],
	   b.[Name] AS [BrandName]
FROM [Brands] AS b
	JOIN [Shoes] AS s On s.[BrandId] = b.[Id]
	JOIN [ShoesSizes] AS sz ON s.[Id] = sz.[ShoeId]
WHERE 
	b.[Name] = 'Nike'
	AND s.[Model] LIKE '%Run%'
GROUP BY b.[Name],
	     s.[Model] HAVING COUNT(sz.SizeId) > 5
ORDER BY s.[Model] DESC