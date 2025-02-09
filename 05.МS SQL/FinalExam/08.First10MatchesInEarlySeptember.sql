SELECT TOP 10
    t.[Name] AS [HomeTeamName],
    ts.[Name] AS [AwayTeamName],
    l.[Name] AS [LeagueName],
    FORMAT(m.[MatchDate], 'yyyy-MM-dd') AS [MatchDate]
FROM [Matches] AS m
	JOIN [Teams] AS t ON m.[HomeTeamId] = t.[Id]
	JOIN [Teams] AS ts ON m.[AwayTeamId] = ts.[Id]
	JOIN [Leagues] AS l ON m.[LeagueId] = l.[Id]
WHERE m.[MatchDate] BETWEEN '2024-09-01' AND '2024-09-15'
	AND l.[Id] % 2 = 0  
ORDER BY m.[MatchDate], 
		 t.[Name]