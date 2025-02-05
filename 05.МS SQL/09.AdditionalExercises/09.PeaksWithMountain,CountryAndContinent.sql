SELECT p.[PeakName], 
       m.[MountainRange], 
	   c.[CountryName], 
	   co.[ContinentName]
FROM [Countries] AS c
	JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
	JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
	JOIN [Continents] AS co ON c.[ContinentCode] = co.[ContinentCode]
ORDER BY p.[PeakName], 
         c.[CountryName]