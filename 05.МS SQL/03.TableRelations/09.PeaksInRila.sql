USE [Geography]
GO

SELECT [MountainRange]
	  ,[PeakName]
	  ,[Elevation]
FROM [Peaks] AS p
JOIN [Mountains]
	AS m ON m.Id = p.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC