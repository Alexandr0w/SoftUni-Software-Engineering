SELECT c.[CountryName],
       co.[ContinentName],
       CASE WHEN COUNT(r.[RiverName]) = 0 THEN 0 ELSE COUNT(r.[RiverName]) END AS [RiversCount],
       CASE WHEN COUNT(r.[RiverName]) = 0 THEN 0 ELSE SUM(r.[Length]) END AS [TotalLength]
FROM [Countries] AS c
	LEFT JOIN [CountriesRivers] cr ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN [Rivers] r ON cr.[RiverId] = r.[Id]
	LEFT JOIN [Continents] co ON c.[ContinentCode] = co.[ContinentCode]
GROUP BY c.[CountryName], 
         co.[ContinentName]
ORDER BY [RiversCount] DESC, 
         [TotalLength] DESC, 
		 c.[CountryName]