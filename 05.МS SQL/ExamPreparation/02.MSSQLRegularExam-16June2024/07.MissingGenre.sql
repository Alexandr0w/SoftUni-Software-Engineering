SELECT l.[Name] AS [LibraryName],
	   c.[Email]
FROM [Libraries] AS l
	JOIN [Contacts] AS c ON l.[ContactId] = c.[Id]
WHERE l.[Id] NOT IN (
	SELECT lb.[LibraryId]
	FROM [LibrariesBooks] AS lb
		JOIN [Books] AS b ON lb.[BookId] = b.[Id]
		WHERE b.[GenreId] = (SELECT [Id] FROM [Genres] WHERE [Name] = 'Mystery')
)
ORDER BY l.[Name]