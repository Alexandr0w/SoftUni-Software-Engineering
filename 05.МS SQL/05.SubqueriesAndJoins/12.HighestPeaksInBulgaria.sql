SELECT
	c.[CountryCode],
	m.[MountainRange],
	p.[PeakName],
	p.[Elevation]
FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	LEFT JOIN [Peaks] AS p ON mc.[MountainId] = p.[MountainId]
	LEFT JOIN [Mountains] AS m ON p.[MountainId] = m.[Id]
WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC