CREATE OR ALTER PROCEDURE usp_SearchByShoeSize @shoeSize DECIMAL(5, 2)
AS
BEGIN
	SELECT s.[Model] AS [ModelName],
		   u.[FullName] AS [UserFullName],
		   CASE 
				WHEN s.Price < 100 THEN 'Low'
				WHEN s.Price BETWEEN 100 AND 200 THEN 'Medium'
				ELSE 'High'
			END AS [PriceLevel],
		   b.[Name] AS [BrandName],
		   ss.[EU] AS SizeEU
	FROM [Shoes] AS s
		JOIN [Orders] AS o ON s.[Id] = o.[ShoeId]
		JOIN [Users] AS u ON o.[UserId] = u.[Id]
		JOIN [Brands] AS b ON s.[BrandId] = b.[Id]
		JOIN [Sizes] AS ss ON o.[SizeId] = ss.[Id]
		JOIN [ShoesSizes] AS sz ON sz.[ShoeId] = s.[Id] AND o.[SizeId] = sz.[SizeId]
	WHERE ss.[EU] = @shoeSize
	ORDER BY b.[Name],
		     u.[FullName]
END

GO

EXEC [usp_SearchByShoeSize] 40.00