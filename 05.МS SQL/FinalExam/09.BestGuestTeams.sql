SELECT t.[Id],
	   t.[Name],
	   SUM(m.[AwayTeamGoals]) AS [TotalAwayGoals]
FROM [Matches] AS m
	JOIN [Teams] AS t ON m.[AwayTeamId] = t.[Id]
GROUP BY t.[Id],
	     t.[Name]
HAVING SUM(m.[AwayTeamGoals]) >= 6
ORDER BY [TotalAwayGoals] DESC,
         t.[Name]