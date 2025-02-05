SELECT t.[Name] AS [Town],
	   rs.[Name] AS [RailwayStation]
FROM [RailwayStations] AS rs
	LEFT JOIN [TrainsRailwayStations] AS trs ON rs.[Id] = trs.[RailwayStationId] 
	JOIN [Towns] AS t ON rs.[TownId] = t.[Id]
WHERE trs.[TrainId] IS NULL
ORDER BY t.[Name],
	     rs.[Name]