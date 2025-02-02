USE [Bank]
GO

CREATE OR ALTER PROCEDURE [usp_GetHoldersFullName]
AS
(
	SELECT
		CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
	FROM [AccountHolders]
)
GO

EXEC [usp_GetHoldersFullName]