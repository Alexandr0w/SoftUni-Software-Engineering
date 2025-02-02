CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount @accountId INT, @interestRate FLOAT
AS
(
	SELECT a.[AccountHolderId] AS [Account Id],
		   ah.[FirstName] AS [First Name],
		   ah.[LastName] AS [Last Name],
		   a.[Balance] AS [Current Balance],
		   dbo.[ufn_CalculateFutureValue](a.[Balance], @interestRate, 5) AS [Balance in 5 years]
	FROM [Accounts] AS a
	JOIN [AccountHolders] AS ah ON a.[AccountHolderId] = ah.[Id]
	WHERE a.[Id] = @accountId
)
GO

EXEC [usp_CalculateFutureValueForAccount] 1, 0.1