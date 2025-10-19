IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [Role] nvarchar(max) NOT NULL,
    [FullName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [IdNumber] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250828180720_InitialCreate', N'9.0.8');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250828183053_CreateAllTables', N'9.0.8');

CREATE TABLE [Investments] (
    [InvestmentId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [AmountInvested] decimal(18,2) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [ReturnRate] float NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Investments] PRIMARY KEY ([InvestmentId]),
    CONSTRAINT [FK_Investments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);

CREATE TABLE [Messages] (
    [MessageId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Subject] nvarchar(max) NOT NULL,
    [Body] nvarchar(max) NOT NULL,
    [SentAt] datetime2 NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([MessageId]),
    CONSTRAINT [FK_Messages_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);

CREATE TABLE [Reports] (
    [ReportId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [FilePath] nvarchar(max) NOT NULL,
    [Notes] nvarchar(max) NOT NULL,
    [DateGenerated] datetime2 NOT NULL,
    CONSTRAINT [PK_Reports] PRIMARY KEY ([ReportId]),
    CONSTRAINT [FK_Reports_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);

CREATE INDEX [IX_Investments_UserId] ON [Investments] ([UserId]);

CREATE INDEX [IX_Messages_UserId] ON [Messages] ([UserId]);

CREATE INDEX [IX_Reports_UserId] ON [Reports] ([UserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251019195130_InitDatabase', N'9.0.8');

COMMIT;
GO

