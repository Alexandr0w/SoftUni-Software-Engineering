SELECT [Title] AS [BookTitle], 
       [ISBN], 
       [YearPublished]
FROM [Books]
ORDER BY [YearPublished] DESC, 
		 [Title]
