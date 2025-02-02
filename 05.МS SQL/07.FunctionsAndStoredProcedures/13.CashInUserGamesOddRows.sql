USE [Diablo]
GO

CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN 
SELECT SUM([Cash]) AS [SumCash]
FROM
(
    SELECT ug.[GameId],
           ug.[Cash],
           ROW_NUMBER() OVER(ORDER BY ug.[Cash] DESC) AS [NumberOfRow]
    FROM [UsersGames] AS ug
    JOIN [Games] AS g ON g.[Id] = ug.[GameId]
    WHERE g.[Name] = @gameName
    GROUP BY ug.[GameId], 
			 ug.[Cash]
) AS tab
WHERE tab.[NumberOfRow] % 2 = 1

GO

SELECT * 
FROM dbo.[ufn_CashInUsersGames]('Love in a mist')