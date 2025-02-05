DELETE 
FROM [Tickets]
WHERE [TrainId] IN (
    SELECT [Id] 
    FROM [Trains] 
    WHERE [DepartureTownId] = (
		SELECT [Id] 
		FROM [Towns]
		WHERE [Name] = 'Berlin'
	)
)

DELETE 
FROM [MaintenanceRecords]
WHERE [TrainId] IN (
    SELECT [Id] 
    FROM [Trains] 
    WHERE [DepartureTownId] = (
		SELECT [Id] 
		FROM [Towns]
		WHERE [Name] = 'Berlin'
	)
)

DELETE 
FROM [TrainsRailwayStations]
WHERE [TrainId] IN (
    SELECT [Id] 
    FROM [Trains] 
    WHERE [DepartureTownId] = (
		SELECT [Id] 
		FROM [Towns]
		WHERE [Name] = 'Berlin'
	)
)

DELETE 
FROM [Trains]
WHERE [DepartureTownId] = (
	SELECT [Id]
	FROM [Towns]
	WHERE [Name] = 'Berlin'
)