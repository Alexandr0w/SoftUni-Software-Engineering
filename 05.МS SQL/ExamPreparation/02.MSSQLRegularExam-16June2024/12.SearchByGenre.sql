CREATE OR ALTER PROCEDURE [usp_SearchByGenre] @genreName NVARCHAR(30)
AS
BEGIN
	SELECT b.[Title], 
		   b.[YearPublished] AS [Year], 
		   b.[ISBN], 
           a.[Name] AS [Author], 
           g.[Name] AS [Genre]
    FROM [Books] AS b
		JOIN [Authors] AS a ON b.[AuthorId] = a.[Id]
		JOIN [Genres] AS g ON b.[GenreId] = g.[Id]
    WHERE g.[Name] = @genreName
    ORDER BY b.[Title]
END

GO

EXEC [usp_SearchByGenre] 'Fantasy'

