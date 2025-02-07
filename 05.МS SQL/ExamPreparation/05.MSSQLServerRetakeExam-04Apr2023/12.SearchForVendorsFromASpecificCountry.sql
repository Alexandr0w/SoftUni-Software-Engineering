CREATE OR ALTER PROCEDURE [usp_SearchByCountry] @country VARCHAR(10)
AS
BEGIN
	SELECT v.[Name] AS [Vendor],
		   v.[NumberVAT] AS [VAT],
		   CONCAT(a.[StreetName], ' ', a.[StreetNumber]) AS [Street Info],
		   CONCAT(a.[City], ' ', a.[PostCode]) AS [City Info]
	FROM [Vendors] AS v
		JOIN [Addresses] AS a ON v.[AddressId] = a.[Id]
		JOIN [Countries] AS c ON c.[Id] = a.[CountryId]
	WHERE c.[Name] = @country
	ORDER BY v.[Name], 
	         a.[City]
END

GO

EXEC [usp_SearchByCountry] 'France'