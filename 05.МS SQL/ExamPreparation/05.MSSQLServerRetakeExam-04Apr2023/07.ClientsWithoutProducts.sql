SELECT c.[Id],
	   c.[Name],
	   CONCAT(a.[StreetName], ' ', a.[StreetNumber], ', ', a.[City], ', ', a.[PostCode], ', ', cc.[Name]) AS [Address]
FROM [Clients] AS c
	JOIN [Addresses] AS a ON c.[AddressId] = a.[Id]
	JOIN [Countries] AS cc ON a.[CountryId] = cc.[Id]
	LEFT JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId]
WHERE pc.[ProductId] IS NULL
ORDER BY c.[Id]