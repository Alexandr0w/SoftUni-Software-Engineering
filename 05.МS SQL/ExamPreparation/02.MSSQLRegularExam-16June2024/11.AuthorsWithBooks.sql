CREATE OR ALTER FUNCTION udf_AuthorsWithBooks (@name NVARCHAR(255))
RETURNS INT
AS
BEGIN
    DECLARE @totalBooks INT;

    SELECT @totalBooks = COUNT(*)
    FROM [Books] AS b
    JOIN [LibrariesBooks] AS lb ON b.[Id] = lb.[BookId]
    JOIN [Authors] AS a ON b.[AuthorId] = a.[Id]
    WHERE a.[Name] = @name;

    RETURN @totalBooks;
END

GO

SELECT dbo.[udf_AuthorsWithBooks]('J.K. Rowling') AS [Output]
