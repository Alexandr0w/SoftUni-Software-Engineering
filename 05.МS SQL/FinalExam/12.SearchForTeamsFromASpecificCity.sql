CREATE OR ALTER PROCEDURE [usp_SearchTeamsByCity] @cityName NVARCHAR(50)
AS
BEGIN 
	SELECT t.[Name] AS [TeamName],
		   l.[Name] AS [LeagueName],
		   t.[City]
	FROM [Teams] AS t
		JOIN [Leagues] AS l ON t.[LeagueId] = l.[Id]
	WHERE t.[City] = @cityName
	ORDER BY t.[Name]
END

GO

EXEC [usp_SearchTeamsByCity] 'London'