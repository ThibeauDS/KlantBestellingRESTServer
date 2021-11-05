USE [master];

ALTER DATABASE [KlantBestellingenRESTServerDb] SET OFFLINE WITH ROLLBACK IMMEDIATE;
ALTER DATABASE [KlantBestellingenRESTServerDb] SET ONLINE;

DROP DATABASE [KlantBestellingenRESTServerDb];

CREATE DATABASE [KlantBestellingenRESTServerDb];

USE [KlantBestellingenRESTServerDb];
GO
CREATE TABLE [dbo].[Klant]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Naam] NVARCHAR(100) NOT NULL, 
    [Adres] NVARCHAR(250) NOT NULL
);
GO;
CREATE TABLE [dbo].[Bestelling]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [KlantId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Aantal] INT NOT NULL,
	CONSTRAINT [FK_Bestelling_Klant] FOREIGN KEY ([KlantId]) REFERENCES [dbo].[Klant] ([Id])
);
GO;