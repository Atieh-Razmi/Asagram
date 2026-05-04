CREATE TABLE [BankAccounts] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(60) NOT NULL,
    [BankName] nvarchar(100) NULL,
    [ShabaNumber] varchar(26) NULL,
    [CardNumber] varchar(16) NULL,
    [PhoneNumber] varchar(15) NULL,
    [Address] nvarchar(250) NULL,
    [AccountNumber] varchar(30) NULL,
    CONSTRAINT [PK_BankAccounts] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Files] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(250) NOT NULL,
    [Data] varbinary(max) NOT NULL,
    [ContentType] varchar(100) NOT NULL,
    [FileType] int NOT NULL,
    CONSTRAINT [PK_Files] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Projects] (
    [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [Title] nvarchar(60) NOT NULL,
    [StartTime] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Province] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_Province] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Roles] (
    [Id] uniqueidentifier NOT NULL,
    [RoleName] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [RefreshToken] nvarchar(max) NULL,
    [RefreshTokenExpiryTime] datetime2 NOT NULL,
    [Gender] int NULL,
    [NationalCode] nvarchar(max) NULL,
    [UserUnit] nvarchar(max) NULL,
    [StartTime] datetime2 NOT NULL,
    [IP] nvarchar(max) NULL,
    [IsActive] bit NOT NULL,
    [Status] bit NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [ProfileImageId] uniqueidentifier NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Files_ProfileImageId] FOREIGN KEY ([ProfileImageId]) REFERENCES [Files] ([Id]) ON DELETE SET NULL
);
GO


CREATE TABLE [Programs] (
    [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [Title] varchar(60) NOT NULL,
    [ProjectId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Programs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Programs_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [City] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(60) NOT NULL,
    [ProvinceId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_City_Province_ProvinceId] FOREIGN KEY ([ProvinceId]) REFERENCES [Province] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [UserRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Customers] (
    [Id] uniqueidentifier NOT NULL,
    [Title] varchar(100) NOT NULL,
    [Address] varchar(150) NOT NULL,
    [Email] varchar(150) NULL,
    [PostalCode] varchar(50) NULL,
    [CityId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Customers_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [City] ([Id]) ON DELETE NO ACTION
);
GO


CREATE TABLE [Contacts] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(60) NULL,
    [LastName] nvarchar(60) NULL,
    [Email] nvarchar(100) NULL,
    [Description] nvarchar(250) NULL,
    [CityId] uniqueidentifier NOT NULL,
    [CustomerId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [City] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Contacts_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE NO ACTION
);
GO


CREATE TABLE [PhoneNumbers] (
    [Id] uniqueidentifier NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [ContactId] uniqueidentifier NULL,
    [CustomerId] uniqueidentifier NULL,
    CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PhoneNumbers_Contacts_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Contacts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PhoneNumbers_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_City_ProvinceId] ON [City] ([ProvinceId]);
GO


CREATE INDEX [IX_Contacts_CityId] ON [Contacts] ([CityId]);
GO


CREATE INDEX [IX_Contacts_CustomerId] ON [Contacts] ([CustomerId]);
GO


CREATE INDEX [IX_Customers_CityId] ON [Customers] ([CityId]);
GO


CREATE INDEX [IX_PhoneNumbers_ContactId] ON [PhoneNumbers] ([ContactId]);
GO


CREATE INDEX [IX_PhoneNumbers_CustomerId] ON [PhoneNumbers] ([CustomerId]);
GO


CREATE INDEX [IX_Programs_ProjectId] ON [Programs] ([ProjectId]);
GO


CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);
GO


CREATE UNIQUE INDEX [IX_Users_ProfileImageId] ON [Users] ([ProfileImageId]) WHERE [ProfileImageId] IS NOT NULL;
GO


