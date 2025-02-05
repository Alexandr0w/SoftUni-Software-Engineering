CREATE TABLE [Monasteries](
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
	[CountryCode] CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode) NOT NULL
)

GO

INSERT INTO [Monasteries]([Name], [CountryCode]) VALUES
	('Rila Monastery “St. Ivan of Rila”', 'BG'),
	('Bachkovo Monastery “Virgin Mary”', 'BG'),
	('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
	('Kopan Monastery', 'NP'),
	('Thrangu Tashi Yangtse Monastery', 'NP'),
	('Shechen Tennyi Dargyeling Monastery', 'NP'),
	('Benchen Monastery', 'NP'),
	('Southern Shaolin Monastery', 'CN'),
	('Dabei Monastery', 'CN'),
	('Wa Sau Toi', 'CN'),
	('Lhunshigyia Monastery', 'CN'),
	('Rakya Monastery', 'CN'),
	('Monasteries of Meteora', 'GR'),
	('The Holy Monastery of Stavronikita', 'GR'),
	('Taung Kalat Monastery', 'MM'),
	('Pa-Auk Forest Monastery', 'MM'),
	('Taktsang Palphug Monastery', 'BT'),
	('Sümela Monastery', 'TR')

GO

ALTER TABLE [Countries]
ADD [IsDeleted] BIT

GO

UPDATE [Countries]
SET [Countries].[IsDeleted] = 0

GO

UPDATE [Countries]
SET [Countries].[IsDeleted] = 1
WHERE [CountryCode] IN (
    SELECT c.[CountryCode]
        FROM [Countries] AS c
    JOIN
	(
        SELECT cr.[CountryCode],
               COUNT(cr.[RiverId]) AS [RiverCount]
            FROM [Countries] AS c
				JOIN [CountriesRivers] AS cr on cr.[CountryCode] = c.[CountryCode]
            GROUP BY cr.[CountryCode]
            ) AS [rivers] ON c.[CountryCode] = [rivers].[CountryCode]
        WHERE [RiverCount] > 3
    )

GO

SELECT m.[Name],
	   c.[CountryName] AS [Country]
FROM [Monasteries] AS m
	JOIN [Countries] AS c on c.[CountryCode] = m.[CountryCode]
WHERE [IsDeleted] = 0
ORDER BY m.[Name]