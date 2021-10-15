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
GO