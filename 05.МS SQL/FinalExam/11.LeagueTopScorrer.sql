CREATE OR ALTER FUNCTION [udf_LeagueTopScorer](@leagueName NVARCHAR(50))
RETURNS @TopScorers TABLE
(
    [PlayerName] NVARCHAR(100),
    [Goals] INT
)
AS
BEGIN
    DECLARE @MaxGoalCount INT

    SELECT @MaxGoalCount = MAX(ps.[Goals])
    FROM [PlayerStats] AS ps
		JOIN [Players] AS p ON ps.[PlayerId] = p.[Id]
		JOIN [PlayersTeams] AS pt ON p.[Id] = pt.[PlayerId]
		JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
		JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
    WHERE l.[Name] = @leagueName
    INSERT INTO @TopScorers ([PlayerName], [Goals])
    SELECT p.[Name] AS [PlayerName], 
		   ps.[Goals]
    FROM [PlayerStats] AS ps
		JOIN [Players] AS p ON ps.[PlayerId] = p.[Id]
		JOIN PlayersTeams pt ON p.Id = pt.[PlayerId]
		JOIN [Teams] AS t ON pt.[TeamId] = t.[Id]
		JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
    WHERE l.[Name] = @leagueName
		AND ps.[Goals] = @MaxGoalCount

    RETURN
END

GO

SELECT *
FROM dbo.[udf_LeagueTopScorer]('Serie A')