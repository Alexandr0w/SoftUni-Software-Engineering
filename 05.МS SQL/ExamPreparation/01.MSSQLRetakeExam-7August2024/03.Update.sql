UPDATE [Shoes]
SET [Price] = [Price] * 1.15
WHERE [BrandId] IN (
	SELECT [Id] 
	FROM [Brands] 
	WHERE [Name] = 'Nike'
)