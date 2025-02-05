SELECT i.[Name], 
	   i.[Price], 
	   i.[MinLevel], 
	   s.[Strength], 
	   s.[Defence], 
	   s.[Speed], 
	   s.[Luck], 
	   s.[Mind]
FROM [Items] AS i
	LEFT JOIN [Statistics] AS s ON i.[StatisticId] = s.[Id]
WHERE s.[Mind] > (SELECT SUM([Mind]) / COUNT([Mind])
                 FROM [Statistics] AS s
                 WHERE s.[Id] IN (SELECT [StatisticId] FROM [Items]))
  AND s.[Luck] > (SELECT SUM([Luck]) / COUNT([Luck])
                 FROM [Statistics] AS s
                 WHERE s.Id IN (SELECT [StatisticId] FROM [Items]))
 AND s.[Speed] > (SELECT SUM([Speed]) / COUNT([Speed])
                 FROM [Statistics] AS s
                 WHERE s.[Id] IN (SELECT [StatisticId] FROM [Items]))
ORDER BY i.[Name]