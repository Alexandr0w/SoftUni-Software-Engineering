SELECT DISTINCT u.[Username] AS [Username],
                g.[Name] AS [Game],
                MAX(c.[Name]) AS [Character],
                SUM([is].[Strength]) + MAX(gs.[Strength]) + MAX(cs.[Strength]) AS [Strength],
                SUM([is].[Defence]) + MAX(gs.[Defence]) + MAX(cs.[Defence]) AS [Defence],
                SUM([is].[Speed]) + MAX(gs.[Speed]) + MAX(cs.[Speed]) AS [Speed],
                SUM([is].[Mind]) + MAX(gs.[Mind]) + MAX(cs.[Mind]) AS [Mind],
                SUM([is].[Luck]) + MAX(gs.[Luck]) + MAX(cs.[Luck]) AS [Luck]
FROM [Users] AS u
	LEFT JOIN [UsersGames] ug ON u.[Id] = ug.[UserId]
	LEFT JOIN [Games] g ON ug.[GameId] = g.[Id]
	LEFT JOIN [Characters] c ON ug.[CharacterId] = c.[Id]
	LEFT JOIN [Statistics] cs ON c.[StatisticId] = cs.[Id]
	LEFT JOIN [UserGameItems] ugi ON ug.[Id] = ugi.[UserGameId]
	LEFT JOIN [Items] i ON ugi.[ItemId] = i.[Id]
	LEFT JOIN [Statistics] [is] ON i.[StatisticId] = [is].[Id]
	LEFT JOIN [GameTypes] gt ON g.[GameTypeId] = gt.[Id]
	LEFT JOIN [Statistics] gs ON gt.[BonusStatsId] = gs.[Id]
GROUP BY u.[Username], 
	     g.[Name]
ORDER BY [Strength] DESC,
         [Defence] DESC,
         [Speed] DESC,
         [Mind] DESC,
         [Luck] DESC