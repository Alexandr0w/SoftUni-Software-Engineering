SELECT c.[Name] AS [Client],
	   MAX(p.[Price]) AS [Price],
	   c.[NumberVAT] AS [VAT Number]
FROM [ProductsClients] AS pc
	JOIN [Clients] AS c ON pc.[ClientId] = c.[Id]
	JOIN [Products] AS p ON pc.[ProductId] = p.[Id]
WHERE c.[Name] NOT LIKE '%KG%'
GROUP BY c.[Name],
	     c.[NumberVAT]
ORDER BY MAX(p.[Price]) DESC