CREATE OR ALTER FUNCTION [udf_TownsWithTrains](@name NVARCHAR(100))
RETURNS INT
AS
BEGIN 
	DECLARE @TotalTrains INT

    SELECT @TotalTrains = (
        SELECT COUNT(*)
        FROM [Trains] AS t
			JOIN [Towns] dt ON t.[DepartureTownId] = dt.[Id]
			JOIN [Towns] tw ON t.[ArrivalTownId] = tw.[Id]
        WHERE dt.[Name] = @name OR tw.[Name] = @name
    )

    RETURN @TotalTrains
END

GO

SELECT dbo.[udf_TownsWithTrains]('Paris') AS [Output]