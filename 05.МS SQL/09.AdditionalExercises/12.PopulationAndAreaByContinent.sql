SELECT co.[ContinentName],
       SUM(c.[AreaInSqKm]) AS [CountriesArea],
       SUM(CAST(c.[Population] AS BIGINT)) AS [CountriesPopulation]
FROM [Continents] AS co
	LEFT JOIN [Countries] AS c ON co.[ContinentCode] = c.[ContinentCode]
GROUP BY co.[ContinentName]
ORDER BY [CountriesPopulation] DESC