CREATE TABLE [dbo].[Software]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    [SaleDetailId] INT NOT NULL, 
    [IsEnabled] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Software_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id), 
    CONSTRAINT [FK_Software_ToSaleDetail] FOREIGN KEY (SaleDetailId) REFERENCES SaleDetail(Id),
)
