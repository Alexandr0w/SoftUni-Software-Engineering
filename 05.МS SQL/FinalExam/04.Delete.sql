--Variant 1
DELETE 
FROM [PlayerStats]
WHERE [PlayerId] IN (
    SELECT p.[Id] 
	FROM [Players] AS p
		JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
		JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
		JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
    WHERE l.[Name] = 'Eredivisie' AND p.[Name] IN ('Luuk de Jong', 'Josip Sutalo')
)

DELETE 
FROM [PlayersTeams]
WHERE [PlayerId] IN (
    SELECT p.[Id] 
	FROM [Players] AS p
		JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
		JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
		JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
    WHERE l.[Name] = 'Eredivisie' AND p.[Name] IN ('Luuk de Jong', 'Josip Sutalo')
)

DELETE 
FROM [Players]
WHERE [Id] IN (
    SELECT p.[Id] 
	FROM [Players] AS p
		JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
		JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
		JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
    WHERE l.[Name] = 'Eredivisie' AND p.[Name] IN ('Luuk de Jong', 'Josip Sutalo')
)

--Variant 2 (optimized)
DECLARE @PlayersToDelete TABLE ([PlayerId] INT)

INSERT INTO @PlayersToDelete ([PlayerId])
SELECT p.[Id]
FROM [Players] AS p
  JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
  JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
  JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
WHERE l.[Name] = 'Eredivisie' AND p.[Name] IN ('Luuk de Jong', 'Josip Sutalo')

DELETE FROM [PlayerStats]
WHERE [PlayerId] IN (SELECT [PlayerId] FROM @PlayersToDelete)

DELETE FROM [PlayersTeams]
WHERE [PlayerId] IN (SELECT [PlayerId] FROM @PlayersToDelete)

DELETE FROM [Players]
WHERE [Id] IN (SELECT [PlayerId] FROM @PlayersToDelete)
