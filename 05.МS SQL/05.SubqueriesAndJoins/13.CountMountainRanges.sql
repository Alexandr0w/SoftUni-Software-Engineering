SELECT 
	c.[CountryCode], 
	COUNT(*) AS [MountainRanges]
FROM [Countries] AS c 
JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode] 
JOIN [Mountains] AS m ON m.[Id] = mc.[MountainId] 
WHERE c.[CountryName] IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.[CountryCode]