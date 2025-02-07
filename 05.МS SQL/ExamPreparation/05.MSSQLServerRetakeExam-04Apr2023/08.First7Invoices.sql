SELECT TOP (7)
	i.[Number],
	i.[Amount],
	c.[Name] AS [Client]
FROM [Invoices] AS i
	JOIN [Clients] AS c ON i.[ClientId] = c.[Id]
WHERE [IssueDate] < CONVERT(DATETIME2, '2023-01-01') AND i.[Currency] = 'EUR'
OR i.[Amount] > 500 AND SUBSTRING(c.[NumberVAT], 1, 2) = 'DE'
ORDER BY i.[Amount] DESC,
		 i.[Number]