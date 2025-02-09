SELECT p.[Id],
	   p.[Name],
	   p.[Position]
FROM [Players] AS p
	JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
	JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
WHERE t.[City] = 'London'
ORDER BY p.[Name]