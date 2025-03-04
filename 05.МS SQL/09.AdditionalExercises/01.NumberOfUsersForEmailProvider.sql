USE [Diablo]
GO

SELECT [Email Provider], 
	   COUNT(*) AS [Number Of Users]
FROM (SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users) AS [Query]
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC, 
	     [Email Provider]