SELECT TOP (3)
	   t.[Id] AS [TrainId],
	   t.[HourOfDeparture],
	   ti.[Price] AS [TicketPrice],
	   tw.[Name] AS [Destination]
FROM [Trains] AS t
	JOIN [Tickets] AS ti ON t.[Id] = ti.[TrainId]
	JOIN [Towns] AS tw ON t.[ArrivalTownId] = tw.[Id]
WHERE t.[HourOfDeparture] LIKE '08:%'
  AND ti.[Price] > 50.00
ORDER BY ti.[Price]
