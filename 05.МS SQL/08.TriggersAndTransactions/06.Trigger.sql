USE [Diablo]
GO

CREATE OR ALTER TRIGGER [tr_RestrictItems]
ON [UserGameItems]
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @itemId INT = (SELECT [ItemId] FROM [inserted])
    DECLARE @gameId INT = (SELECT [UserGameId] FROM [inserted])

    DECLARE @itemLevel INT = (SELECT [MinLevel] FROM [Items] WHERE [Id] = @itemId)
    DECLARE @gameLevel INT = (SELECT [Level] FROM [UsersGames] WHERE [Id] = @gameId)

    IF (@itemLevel > @gameLevel)
        BEGIN
            THROW 50005, 'Item level is greater than game level!', 4;
        END

    INSERT INTO [UserGameItems] (ItemId, UserGameId)
    VALUES (@itemId, @gameId)
END

--This will not work since the trigger is active and game level < item level
INSERT INTO [UserGameItems]([ItemId], [UserGameId])
VALUES (1, 5)

UPDATE [UsersGames]
SET [Cash] += 50000
WHERE [GameId] = (SELECT [Games].[Id] FROM [Games] WHERE [Name] = 'Bali')
AND [UserId] IN (SELECT [Users].[Id]
FROM [Users]
WHERE [Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))

GO

CREATE OR ALTER PROCEDURE [udp_BuyItem] @userId INT, @itemId INT, @gameId INT
    AS
        BEGIN TRANSACTION
    DECLARE
        @user INT = (SELECT [Id]
                     FROM [Users]
                     WHERE [Id] = @userId)
    DECLARE
        @item INT = (SELECT [Id]
                     FROM [Items]
                     WHERE [Id] = @itemId)
    DECLARE
        @game INT = (SELECT [Id]
                     FROM [Games]
                     WHERE [Id] = @gameId)
        IF (@user IS NULL OR @item IS NULL OR @game IS NULL)
            BEGIN
                ROLLBACK;
                THROW 50001, 'Invalid user or item or game!', 1;
            END

    DECLARE
        @userCash MONEY = (SELECT [Cash]
                           FROM [UsersGames]
                           WHERE [UserId] = @userId)
    DECLARE
        @itemPrice MONEY = (SELECT [Price]
                            FROM [Items]
                            WHERE [Id] = @itemId)
        IF (@userCash - @itemPrice < 0)
            BEGIN
                ROLLBACK;
                THROW 50002, 'Not enough cash!', 2;
            END
        IF NOT (@userId IN (SELECT [UserId]
                            FROM [UsersGames]
                            WHERE [GameId] = @gameId))
            BEGIN
                ROLLBACK;
                THROW 50003, 'User does not exist in the given game!', 3;
            END

    DECLARE
        @gameName NVARCHAR(50) = (SELECT [Name]
                                  FROM [Games]
                                  WHERE [Id] = @gameId)

INSERT INTO [UserGameItems]([ItemId], [UserGameId])
VALUES (@itemId, @gameId)

UPDATE [UsersGames]
SET [Cash] -= @itemPrice
WHERE [UserId] = @userId AND GameId = @gameId
COMMIT

GO

SELECT u.[Username], 
	   g.[Name] AS [Name], 
	   ug.[Cash] AS [Cash], 
	   i.[Name] AS [Item Name] 
FROM [Users] AS u
JOIN [UsersGames] AS ug ON u.[Id] = ug.[UserId]
JOIN [UserGameItems] AS ugi ON ug.[GameId] = ugi.[UserGameId]
JOIN [Items] AS i ON ugi.[ItemId] = i.[Id]
JOIN [Games] AS g ON ug.[GameId] = g.[Id]
WHERE g.[Name] = 'Bali'