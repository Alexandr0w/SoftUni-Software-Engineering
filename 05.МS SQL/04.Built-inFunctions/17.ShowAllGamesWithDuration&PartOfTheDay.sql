SELECT [g].[Name],
	  CASE
			WHEN DATEPART(HOUR, [g].[Start]) BETWEEN 0 AND 11 THEN 'Morning'
			WHEN DATEPART(HOUR, [g].[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
			ELSE 'Evening'
	  END
   AS [Part of the Day],
	  CASE
			WHEN [g].[Duration] <= 3 THEN 'Extra Short'
			WHEN [g].[Duration] BETWEEN 4 AND 6 THEN 'Short'
			WHEN [g].[Duration] > 6 THEN 'Long'
			ELSE 'Extra Long'
	  END
   AS [Duration]
 FROM [Games]
 AS [g]
 ORDER BY [g].[Name]
		 ,[Duration]
		 ,[Part of the Day]