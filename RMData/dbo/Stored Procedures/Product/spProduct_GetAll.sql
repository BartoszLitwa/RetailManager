CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
begin
	set nocount on;

	SELECT Product.Id, Product.ProductName, Product.[Description], Product.RetailPrice, Product.QuantityInStock, Product.TaxId
	FROM [dbo].[Product]
	ORDER BY ProductName;
end