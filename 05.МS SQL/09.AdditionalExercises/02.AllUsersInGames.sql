SELECT g.[Name] AS [Game],
	   gt.[Name] AS [Game Type],
	   u.[Username] AS [Username],
	   ug.[Level] AS [Level],
	   ug.[Cash] AS [Cash],
	   c.[Name] AS [Character]
FROM [Users] AS u
	LEFT JOIN [UsersGames] AS ug ON u.[Id] = ug.[UserId]
	LEFT JOIN [Games] AS g ON ug.[GameId] = g.[Id]
	LEFT JOIN [Characters] AS c ON ug.[CharacterId] = c.[Id]
    LEFT JOIN [GameTypes] AS gt ON g.[GameTypeId] = gt.[Id]
ORDER BY ug.[Level] DESC, 
		 u.[Username], 
		 g.[Name]