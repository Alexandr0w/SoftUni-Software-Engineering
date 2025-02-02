CREATE OR ALTER PROCEDURE [usp_GetHoldersWithBalanceHigherThan] @balance DECIMAL(18,4)
AS
	SELECT [FirstName], 
		   [LastName]
	FROM [AccountHolders] AS ah
	JOIN ( SELECT [AccountHolderId],
				 SUM([Balance]) AS [TotalBalance]
		   FROM [Accounts]
		   GROUP BY [AccountHolderId]
		 ) AS a
	ON ah.[Id] = a.[AccountHolderId]
	WHERE a.[TotalBalance] > @balance
	ORDER BY ah.[FirstName], 
			 ah.[LastName]
GO

EXEC [usp_GetHoldersWithBalanceHigherThan] 200