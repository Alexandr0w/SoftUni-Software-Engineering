USE [Diablo]
GO

DECLARE @userGameID INT = (
    SELECT ug.[Id]
    FROM [UsersGames] AS ug
    JOIN [Users] AS u ON u.[Id] = ug.[UserId]
    JOIN [Games] AS g ON g.[Id] = ug.[GameId]
    WHERE g.[Name] = 'Safflower' AND u.[Username] = 'Stamat'
)

DECLARE @totalItemCost DECIMAL(18,4)

DECLARE @minLevelOne INT = 11
DECLARE @maxLevelOne INT = 12
DECLARE @availablePlayerCash DECIMAL(18,4) = (
    SELECT [Cash]
    FROM [UsersGames]
    WHERE [Id] = @userGameID
)

SET @totalItemCost = (
    SELECT SUM([Price])
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevelOne AND @maxLevelOne
)

IF(@availablePlayerCash >= @totalItemCost)
BEGIN
    BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @totalItemCost
    WHERE [Id] = @userGameID

    INSERT INTO [UserGameItems]
    SELECT [Id], @userGameID
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevelOne AND @maxLevelOne

    COMMIT TRANSACTION
END

DECLARE @minLevelTwo INT = 19
DECLARE @maxLevelTwo INT = 21
SET @availablePlayerCash = (
    SELECT [Cash]
    FROM [UsersGames]
    WHERE [Id] = @userGameID
)

SET @totalItemCost = (
    SELECT SUM([Price])
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevelTwo AND @maxLevelTwo
)

IF(@availablePlayerCash >= @totalItemCost)
BEGIN
    BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @totalItemCost
    WHERE [Id] = @userGameID

    INSERT INTO [UserGameItems]
    SELECT [Id], @userGameID
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevelTwo AND @maxLevelTwo

    COMMIT TRANSACTION
END

SELECT i.[Name] AS [Item Name]
FROM [UserGameItems] AS [ugi]
JOIN [Items] AS i ON i.[Id] = ugi.[ItemId]
JOIN [UsersGames] AS ug on ug.[Id] = ugi.[UserGameId]
JOIN [Games] AS g on g.[Id] = ug.[GameId]
JOIN [Users] AS U on u.[Id] = ug.[UserId]
WHERE g.[Name] = 'Safflower' AND u.[Username] = 'Stamat'
ORDER BY i.[Name]