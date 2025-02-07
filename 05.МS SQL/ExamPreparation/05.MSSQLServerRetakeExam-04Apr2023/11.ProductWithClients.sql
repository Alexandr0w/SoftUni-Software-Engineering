CREATE OR ALTER FUNCTION [udf_ProductWithClients](@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @totalProductClient INT =
	(
		SELECT COUNT(pc.[ClientId])
		FROM [Products] AS p
			JOIN [ProductsClients] AS pc ON p.[Id] = pc.[ProductId]
		WHERE p.[Name] = @name
	)
	RETURN @totalProductClient
END

GO

SELECT dbo.[udf_ProductWithClients]('DAF FILTER HU12103X') AS [Output]