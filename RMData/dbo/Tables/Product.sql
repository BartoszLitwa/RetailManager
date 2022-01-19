CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [RetailPrice] MONEY NOT NULL,
    [QuantityInStock] INT NOT NULL DEFAULT 1,
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [TaxId] int NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Product_ToTaxRate] FOREIGN KEY (TaxId) REFERENCES TaxRate(Id), 
)
