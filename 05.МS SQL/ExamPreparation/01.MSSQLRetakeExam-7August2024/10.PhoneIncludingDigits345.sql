SELECT u.[FullName],
       u.[PhoneNumber],
	   s.[Price] AS [OrderPrice],
	   s.[Id] AS [ShoeId],
	   b.[Id] AS [BrandId],
	   CONCAT_WS('/', CONCAT(ss.EU, 'EU'), 
					  CONCAT(ss.US, 'US'),
					  CONCAT(ss.UK, 'UK')) AS [ShoeSize]
FROM [Orders] AS o
	JOIN [Users] AS u ON o.[UserId] = u.[Id]
	JOIN [Shoes] AS s ON o.[ShoeId] = s.[Id]
	JOIN [ShoesSizes] AS sz ON sz.[ShoeId] = s.[Id] AND sz.[SizeId] = o.[SizeId]
	JOIN [Sizes] AS ss ON sz.[SizeId] = ss.[Id]
	JOIN [Brands] AS b ON s.[BrandId] = b.[Id]
WHERE u.[PhoneNumber] LIKE '%345%'
ORDER BY s.[Model]