CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
('Pesho', '123456', NULL, GETDATE(), NULL),
('Gosho', '12345678', NULL, GETUTCDATE(), 0),
('Sasho', '1234', NULL, NULL, 1),
('Ivan', '123456789', NULL, NULL, 0),
('Mariq', '123', NULL, GETDATE(), 1)