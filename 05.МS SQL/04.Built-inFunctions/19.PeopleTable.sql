CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(64) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)

INSERT INTO [People] 
	VALUES
		('Alexander', '1999-05-25 00:00:00.000'),
		('Milena', '1980-01-02 00:00:00.000'),
		('Luboslav', '2010-07-10 00:00:00.000'),
		('Sonya', '1961-02-22 00:00:00.000')

SELECT [Name],
    DATEDIFF(YEAR, [Birthdate], GETDATE()) - 
    CASE 
        WHEN MONTH([Birthdate]) > MONTH(GETDATE()) 
            OR (MONTH([Birthdate]) = MONTH(GETDATE()) AND DAY([Birthdate]) > DAY(GETDATE()))
        THEN 1 
        ELSE 0 
    END AS [Age in Year],
    DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months],
    DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days],
    DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM [People]
