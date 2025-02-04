CREATE TABLE [NotificationEmails](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Recipient] INT FOREIGN KEY REFERENCES [Accounts](Id),
	[Subject] NVARCHAR(255) NOT NULL,
	[Body] NVARCHAR(255) NOT NULL
)
GO

CREATE OR ALTER TRIGGER [tr_NewEmailWhenNewRecordIsInserted]
ON [Logs] AFTER INSERT
AS
	INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
	SELECT [AccountId],
		   'Balance change for account: ' + CAST([AccountId] AS NVARCHAR(255)),
		   'On ' + FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt') + ' your balance was changed from '
		   + CAST([OldSum] AS NVARCHAR(255)) + ' to ' + CAST([NewSum] AS NVARCHAR(255)) + '.'
	FROM [inserted]