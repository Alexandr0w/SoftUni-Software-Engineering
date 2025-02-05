SELECT tw.[Name] AS [TownName],
       COUNT(ti.[Id]) AS [PassengersCount]
FROM [Tickets] AS ti
	JOIN [Trains] AS tr ON tr.[Id] = ti.[TrainId]
	JOIN [Towns] AS tw ON tw.[Id] = tr.[ArrivalTownId]
WHERE ti.[Price] > 76.99
GROUP BY tw.[Name]
ORDER BY tw.[Name]