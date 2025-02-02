CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(30)) 
RETURNS BIT
BEGIN
	DECLARE @wordIndex TINYINT = 1
	WHILE (@wordIndex <= LEN(@word))
	BEGIN
		DECLARE @currentLetter CHAR(1)
		SET @currentLetter = SUBSTRING(@word, @wordIndex, 1)
		
		IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
		BEGIN
			RETURN 0
		END

		SET @wordIndex += 1
	END

	RETURN 1
END

GO

SELECT dbo.[ufn_IsWordComprised]('oistmiahf', 'halves')