CREATE TABLE [dbo].[System_Users]
(
	[Id] INT NOT NULL IDENTITY ,
	[UserName] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(MAX) NOT NULL,
	[RegistrationDate] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[Email] NVARCHAR(50) NOT NULL,
	PRIMARY KEY ([Id])
)
GO
CREATE INDEX [IX_System_Users_UserName] ON [dbo].[System_Users] ([UserName])
GO
INSERT INTO [dbo].[System_Users]
	([UserName], [Password], [Email])
VALUES
	('admin', 'password', 'admin@ukr.net')
GO