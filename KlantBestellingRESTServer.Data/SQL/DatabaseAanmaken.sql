--DROP DATABASE [KlantBestellingenRESTServerDb];
--CREATE DATABASE [KlantBestellingenRESTServerDb];
USE [KlantBestellingenRESTServerDb];
GO
CREATE TABLE [dbo].[Klant]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Naam] NVARCHAR(100) NOT NULL, 
    [Adres] NVARCHAR(250) NOT NULL
);
GO
CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Naam] NVARCHAR(100) NOT NULL
);
GO
CREATE TABLE [dbo].[Bestelling]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [KlantId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Aantal] INT NOT NULL,
	CONSTRAINT [FK_Bestelling_Klant] FOREIGN KEY ([KlantId]) REFERENCES [dbo].[Klant] ([Id]),
    CONSTRAINT [FK_Bestelling_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);
GO