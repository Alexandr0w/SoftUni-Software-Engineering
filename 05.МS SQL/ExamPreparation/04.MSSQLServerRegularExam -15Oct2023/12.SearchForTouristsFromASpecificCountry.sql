CREATE OR ALTER PROCEDURE [usp_SearchByCountry] @country NVARCHAR(50)
AS
BEGIN
    SELECT t.[Name],
           t.[PhoneNumber],
           t.[Email],
           COUNT(b.Id) AS [CountOfBookings]
    FROM [Tourists] AS t
		JOIN [Countries] AS c ON t.[CountryId] = c.[Id]
		JOIN [Bookings] AS b ON t.[Id] = b.[TouristId]
    WHERE c.[Name] = @country
    GROUP BY t.[Name], 
	         t.[PhoneNumber], 
			 t.[Email]
    ORDER BY t.[Name], 
	         [CountOfBookings] DESC
END

GO

EXEC [usp_SearchByCountry] 'Greece'