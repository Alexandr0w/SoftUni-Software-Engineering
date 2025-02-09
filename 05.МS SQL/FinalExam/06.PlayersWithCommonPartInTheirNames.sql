SELECT p.[Name],
	   t.[City]
FROM [Players] AS p
	JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
	JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
WHERE p.[Name] LIKE '%Aaron%'
ORDER BY p.[Name]
