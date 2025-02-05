CREATE OR ALTER FUNCTION [udf_GenreFilter](@genre NVARCHAR(30))
RETURNS TABLE
AS
RETURN
(
    SELECT b.[Id] AS [BookId],
		   b.[Title] AS [BookTitle],
           b.[YearPublished] AS [YearPublished],
           b.[ISBN],
		   a.[Name] AS [Author],
           l.[Name] AS [LibraryName]
    FROM [Books] AS b
		JOIN [LibrariesBooks] AS lb ON b.[Id] = lb.[BookId]
		JOIN [Libraries] AS l ON lb.[LibraryId] = l.[Id]
		JOIN [Genres] AS g ON b.[GenreId] = g.[Id]
		JOIN [Authors] AS a ON b.[AuthorId] = a.[Id]
    WHERE g.[Name] = @genre
)

GO

SELECT *
FROM dbo.[udf_GenreFilter]('Fiction')
