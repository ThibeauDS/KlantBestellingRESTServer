DELETE FROM [dbo].[Klant];
GO
DBCC CHECKIDENT ('Klant', RESEED, 0);
GO
DELETE FROM [dbo].[Bestelling];
GO
DBCC CHECKIDENT ('Bestelling', RESEED, 0);
GO