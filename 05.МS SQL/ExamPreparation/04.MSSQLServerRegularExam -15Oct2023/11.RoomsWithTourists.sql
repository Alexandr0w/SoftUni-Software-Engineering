CREATE OR ALTER FUNCTION [udf_RoomsWithTourists](@roomType NVARCHAR(30)) 
RETURNS INT
AS 
BEGIN
	DECLARE @totalTourists INT

	SELECT @totalTourists = SUM([AdultsCount] + [ChildrenCount])
	FROM [Bookings] AS b
		JOIN [Rooms] AS r ON b.[RoomId] = r.[Id]
	WHERE r.[Type] = @roomType

	RETURN @totalTourists
END

GO

SELECT dbo.[udf_RoomsWithTourists]('Double Room') AS [Output]