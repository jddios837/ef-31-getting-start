CREATE TABLE [Clans] (
    [Id] int NOT NULL IDENTITY,
    [ClanName] nvarchar(max) NULL,
    CONSTRAINT [PK_Clans] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Samurais] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ClanId] int NULL,
    CONSTRAINT [PK_Samurais] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Samurais_Clans_ClanId] FOREIGN KEY ([ClanId]) REFERENCES [Clans] ([Id]) ON DELETE NO ACTION
);
GO


CREATE TABLE [Quotes] (
    [Id] int NOT NULL IDENTITY,
    [Text] nvarchar(max) NULL,
    [SamuraiId] int NOT NULL,
    CONSTRAINT [PK_Quotes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Quotes_Samurais_SamuraiId] FOREIGN KEY ([SamuraiId]) REFERENCES [Samurais] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Quotes_SamuraiId] ON [Quotes] ([SamuraiId]);
GO


CREATE INDEX [IX_Samurais_ClanId] ON [Samurais] ([ClanId]);
GO


