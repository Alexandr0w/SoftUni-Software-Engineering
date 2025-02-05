SELECT t.[ID] AS [TrainID],
       dt.[Name] AS [DepartureTown],
       m.Details
FROM [MaintenanceRecords] AS m
	JOIN [Trains] AS t ON m.[TrainID] = t.[Id]
	JOIN [Towns] AS dt ON t.[DepartureTownId] = dt.[Id]
WHERE 
    m.[Details] LIKE '%inspection%'
ORDER BY t.[Id]
