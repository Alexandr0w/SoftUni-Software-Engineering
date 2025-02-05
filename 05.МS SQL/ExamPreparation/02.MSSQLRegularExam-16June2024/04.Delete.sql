DELETE 
FROM [LibrariesBooks]
WHERE [BookId] IN (
	SELECT [Id] 
	FROM [Books] 
	WHERE [AuthorId] IN (
		SELECT [Id] 
		FROM [Authors] 
		WHERE [Name] = 'Alex Michaelides'
	)
)

DELETE 
FROM [Books]
WHERE [AuthorId] IN (
	SELECT [Id] 
	FROM [Authors] 
	WHERE [Name] = 'Alex Michaelides'
)

DELETE 
FROM [Authors]
WHERE [Name] = 'Alex Michaelides'
