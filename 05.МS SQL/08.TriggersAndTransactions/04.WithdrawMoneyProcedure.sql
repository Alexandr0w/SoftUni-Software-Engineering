CREATE OR ALTER PROCEDURE [usp_WithdrawMoney] @AccountId INT, @MoneyAmount DECIMAL(18, 4)
AS
	IF(@MoneyAmount > 0.0000)
		UPDATE [Accounts]
		SET [Balance] -= @MoneyAmount
		WHERE [Id] = @AccountId