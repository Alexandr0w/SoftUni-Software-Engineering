DECLARE @itemPrice MONEY = (
	SELECT SUM([Price])
    FROM [Items]
    WHERE [Id] IN (51, 71, 157, 184, 197, 223)
)

DECLARE @userId INT = (
	SELECT TOP 1 [Id]
	FROM [Users]
	WHERE [Username] = 'Alex'
)

DECLARE @gameId    INT = (
	SELECT TOP 1 [Id]
	FROM [Games]
	WHERE [Name] = 'Edinburgh'
)

DECLARE @userGameId INT = (
	SELECT TOP 1 [Id]
	FROM [UsersGames]
	WHERE [UserId] = @userId
	AND [GameId] = @gameId
)

UPDATE [UsersGames]
SET [Cash] -= @itemPrice
WHERE [UserId] = @userId
  AND [GameId] = @gameId

INSERT INTO [UserGameItems] ([ItemId], [UserGameId])
SELECT [Id], @userGameId
FROM [Items]
WHERE [Id] IN (51, 71, 157, 184, 197, 223)

SELECT u.[Username], 'Edinburgh' AS [Name], 
       ug.[Cash] AS [Cash], 
       i.[Name]
FROM [UsersGames] AS ug
    LEFT JOIN [Users] u ON ug.[UserId] = u.[Id]
    LEFT JOIN [UserGameItems] ugi ON ugi.[UserGameId] = ug.[Id]
    LEFT JOIN [Items] i ON ugi.[ItemId] = i.[Id]
WHERE ug.[GameId] = 221
ORDER BY i.[Name]
