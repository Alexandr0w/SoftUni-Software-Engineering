USE [SoftUni]
GO

CREATE OR ALTER PROCEDURE [usp_AssignProject] @employeeId INT, @projectID INT
AS
BEGIN TRANSACTION
    DECLARE @projectsForGivenEmployee INT = (
        SELECT COUNT([EmployeeID])
        FROM [EmployeesProjects]
        WHERE [EmployeeID] = @employeeId
    )

    IF(@projectsForGivenEmployee >= 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1);
    END

    INSERT INTO [EmployeesProjects] 
	VALUES (@employeeId, @projectID)
COMMIT TRANSACTION