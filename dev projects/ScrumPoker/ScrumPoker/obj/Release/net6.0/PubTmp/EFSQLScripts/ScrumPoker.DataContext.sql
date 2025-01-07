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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250107181727_InitialCreate')
BEGIN
    CREATE TABLE [Game] (
        [Id] int NOT NULL IDENTITY,
        [gameCode] nvarchar(max) NOT NULL,
        [isVotingOpen] bit NOT NULL,
        [RowVersion] rowversion NOT NULL,
        CONSTRAINT [PK_Game] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250107181727_InitialCreate')
BEGIN
    CREATE TABLE [Users] (
        [userId] int NOT NULL IDENTITY,
        [userName] nvarchar(max) NOT NULL,
        [passwordHash] nvarchar(max) NOT NULL,
        [userRole] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([userId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250107181727_InitialCreate')
BEGIN
    CREATE TABLE [Votes] (
        [Id] int NOT NULL IDENTITY,
        [playerId] int NOT NULL,
        [storyPoints] int NOT NULL,
        [role] int NOT NULL,
        [RowVersion] rowversion NOT NULL,
        [GameId] int NULL,
        CONSTRAINT [PK_Votes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Votes_Game_GameId] FOREIGN KEY ([GameId]) REFERENCES [Game] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250107181727_InitialCreate')
BEGIN
    CREATE INDEX [IX_Votes_GameId] ON [Votes] ([GameId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20250107181727_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250107181727_InitialCreate', N'6.0.14');
END;
GO

COMMIT;
GO

