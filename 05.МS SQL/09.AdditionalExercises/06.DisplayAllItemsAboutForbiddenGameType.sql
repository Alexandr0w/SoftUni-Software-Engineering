SELECT i.[Name], 
       i.[Price], 
	   i.[MinLevel], 
	   gt.[Name]
FROM [Items] AS i
	LEFT JOIN [GameTypeForbiddenItems] AS gtfi ON i.[Id] = gtfi.[ItemId]
	LEFT JOIN [GameTypes] AS gt ON gtfI.[GameTypeId] = gt.[Id]
ORDER BY gt.[Name] DESC, 
         i.[Name]