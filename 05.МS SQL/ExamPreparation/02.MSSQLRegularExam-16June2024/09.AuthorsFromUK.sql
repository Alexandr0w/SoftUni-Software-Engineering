SELECT a.[Name] AS [Author], 
	   c.[Email], 
	   c.[PostAddress] AS [Address]
FROM [Contacts] AS c
	JOIN [Authors] AS a ON c.[Id] = a.[ContactId]
WHERE [PostAddress] LIKE '%UK%'
ORDER BY a.[Name]