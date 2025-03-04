SELECT * 
FROM (SELECT u.[Username], 
		     g.[Name] as [Game], 
	         COUNT(i.[Name]) AS [Item Count], 
			 SUM(i.[Price]) AS [Items Price] 
FROM [Users] AS u
	LEFT JOIN [UsersGames] ug ON u.[Id] = ug.[UserId]
	LEFT JOIN [UserGameItems] ugi ON ug.[Id] = ugi.[UserGameId]
	LEFT JOIN [Items] i ON ugi.[ItemId] = i.[Id]
	LEFT JOIN [Games] g ON ug.[GameId] = g.[Id]
GROUP BY u.[Username], 
	     g.[Name]) AS [Query]
WHERE [Item Count] >= 10
ORDER BY [Item Count] DESC, 
		 [Items Price] DESC, 
		 [Username]