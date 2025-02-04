CREATE OR ALTER PROCEDURE [usp_DepositMoney] @AccountId INT, @MoneyAmount DECIMAL(18, 4)
AS
    IF(@MoneyAmount > 0.0000)
        UPDATE [Accounts]
        SET [Balance] += @MoneyAmount
        WHERE [Id] = @AccountId

GO

EXEC [usp_DepositMoney] 1, -10
