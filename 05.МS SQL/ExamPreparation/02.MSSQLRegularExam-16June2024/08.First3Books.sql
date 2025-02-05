SELECT TOP (3)
    b.[Title], 
    b.[YearPublished] AS [Year], 
    g.[Name] AS [Genre]
FROM [Books] AS b
	JOIN [Genres] AS g ON b.[GenreId] = g.[Id]
WHERE ([YearPublished] > 2000 AND [Title] LIKE '%a%')
	  OR
      ([YearPublished] < 1950 AND g.[Name] LIKE '%Fantasy%')
ORDER BY b.[Title] ASC, 
         b.[YearPublished] DESC
