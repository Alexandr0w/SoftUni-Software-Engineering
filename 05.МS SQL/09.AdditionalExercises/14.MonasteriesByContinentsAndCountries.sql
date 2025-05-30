﻿UPDATE [Countries]
SET [CountryName] = 'Burma'
WHERE [CountryName] = 'Myanmar'

INSERT INTO [Monasteries]([Name], [CountryCode])
SELECT 'Hanga Abbey', [CountryCode]
FROM [Countries]
WHERE [CountryName] = 'Tanzania'

INSERT INTO [Monasteries]([Name], [CountryCode])
SELECT 'Myin-Tin-Daik', [CountryCode]
FROM [Countries]
WHERE [CountryName] = 'Myanmar'

SELECT cc.[ContinentName],
       c.[CountryName],
       COUNT(m.[Id]) AS [MonasteriesCount]
FROM [Countries] AS c
	LEFT JOIN [Continents] AS cc ON cc.[ContinentCode] = c.[ContinentCode]
	LEFT JOIN [Monasteries] AS m ON m.[CountryCode] = c.[CountryCode]
WHERE c.[IsDeleted] = 0
GROUP BY cc.[ContinentName], 
         c.[CountryName]
ORDER BY [MonasteriesCount] DESC, 
         c.[CountryName]