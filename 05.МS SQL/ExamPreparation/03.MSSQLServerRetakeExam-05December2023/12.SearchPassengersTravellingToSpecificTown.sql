CREATE OR ALTER PROCEDURE [usp_SearchByTown] @townName NVARCHAR(30)
AS
BEGIN
	SELECT p.[Name] AS [PassangerName],
		   t.[DateOfDeparture],
		   tr.[HourOfDeparture]
	FROM [Tickets] AS t
		JOIN [Trains] AS tr ON t.[TrainId] = tr.[Id]
		JOIN [Towns] AS tw ON tr.[ArrivalTownId] = tw.Id
		JOIN [Passengers] AS p ON t.[PassengerId] = p.[Id]
	WHERE tw.[Name] = @townName
	ORDER BY t.[DateOfDeparture] DESC,
	         p.[Name]
END

GO

EXEC [usp_SearchByTown] 'Berlin'