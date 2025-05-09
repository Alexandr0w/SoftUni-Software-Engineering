SELECT 
	[ContinentCode], 
	[CurrencyCode], 
Usage FROM (
    SELECT 
		c.[ContinentCode],
        c.[CurrencyCode],
       DENSE_RANK() OVER (PARTITION BY c.[ContinentCode] ORDER BY COUNT(c.[CurrencyCode]) DESC) AS [Ranking],
       COUNT([CurrencyCode]) AS [Usage]
FROM [Countries] AS c
GROUP BY c.[ContinentCode], c.[CurrencyCode]
              ) AS [Query]
WHERE Usage > 1 AND [Ranking] = 1
ORDER BY [ContinentCode]