SELECT l.[Name] AS [LeagueName],
	   ROUND(CAST(SUM(m.[HomeTeamGoals] + m.[AwayTeamGoals]) AS FLOAT) / COUNT(m.[Id]), 2) AS [AvgScoringRate]
FROM [Matches] AS m
	JOIN [Leagues] AS l ON m.[LeagueId] = l.[Id]
GROUP BY l.[Name]
ORDER BY [AvgScoringRate] DESC