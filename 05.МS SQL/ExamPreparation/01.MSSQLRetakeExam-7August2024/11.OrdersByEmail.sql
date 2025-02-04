CREATE OR ALTER FUNCTION udf_OrdersByEmail(@email NVARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	FROM [Orders] AS o
		JOIN [Users] AS u On o.[UserId] = u.[Id]
	WHERE u.Email = @email

	RETURN @result
END

GO

SELECT dbo.[udf_OrdersByEmail]('sstewart@example.com') AS [Output]