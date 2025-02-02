CREATE OR ALTER PROCEDURE [usp_GetTownsStartingWith] @initialString VARCHAR(50)
AS 
(
	SELECT [Name]
	FROM [Towns]
	WHERE SUBSTRING([Name], 1, LEN(@initialString)) = @initialString
)
GO

EXEC [usp_GetTownsStartingWith] b