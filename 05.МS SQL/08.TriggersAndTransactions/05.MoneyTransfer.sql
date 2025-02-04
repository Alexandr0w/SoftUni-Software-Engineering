CREATE OR ALTER PROCEDURE [usp_TransferMoney] @SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4)
AS
BEGIN
    BEGIN TRANSACTION; 

    IF(@Amount < 0) 
    BEGIN
        THROW 50001, 'Invalid Amount', 1;
    END

    BEGIN TRY
        EXEC [usp_DepositMoney] @ReceiverId, @Amount;
        EXEC [usp_WithdrawMoney] @SenderId, @Amount;

        COMMIT TRANSACTION; 
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;  
        THROW; 
    END CATCH
END