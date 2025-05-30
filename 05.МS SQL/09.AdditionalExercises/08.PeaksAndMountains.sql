USE [Geography]
GO

SELECT p.[PeakName], 
       m.[MountainRange], 
	   p.[Elevation]
FROM [Peaks] AS p
	LEFT JOIN [Mountains] AS m ON p.[MountainId] = m.[Id]
ORDER BY p.[Elevation] DESC, 
         p.[PeakName]