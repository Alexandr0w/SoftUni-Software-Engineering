UPDATE [PlayerStats]
SET [Goals] = [Goals] + 1
WHERE [PlayerId] IN (
    SELECT p.[Id]
    FROM [Players] AS p
		JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
		JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
		JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
    WHERE p.[Position] = 'Forward' AND l.[Name] = 'La Liga'
)