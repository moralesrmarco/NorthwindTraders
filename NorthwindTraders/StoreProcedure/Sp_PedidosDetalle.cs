/*
 * ----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOSDETALLE_INSERTAR]
	@OrderId int,
	@ProductId int,
	@UnitPrice money,
	@Quantity smallint,
	@Discount real
AS
BEGIN
		INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount)
		Values (
			@OrderId,
			@ProductId,
			@UnitPrice,
			@Quantity,
			@Discount
		)
END
----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOSDETALLE_ELIMINAR]
	@OrderId int,
	@ProductId int
AS
	DELETE [Order Details]
	WHERE OrderID = @OrderId AND ProductID = @ProductId
----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOSDETALLE_ACTUALIZAR]
	@OrderId int,
	@ProductId int,
	@Quantity smallint,
	@Discount real
AS
BEGIN
		UPDATE [Order Details] SET
			Quantity = @Quantity,
			Discount = @Discount
		WHERE OrderID = @OrderId AND ProductID = @ProductId
END
----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOSDETALLE_PRODUCTOS]
	@PedidoId int
AS
	SELECT ROW_NUMBER() OVER(ORDER BY [Order Details].ProductID Asc) AS Id, [Order Details].ProductID AS [Id Producto], 
	Products.ProductName AS Producto, [Order Details].UnitPrice AS Precio, 
	[Order Details].Quantity AS Cantidad, [Order Details].Discount AS Descuento, 
	([Order Details].UnitPrice * [Order Details].Quantity) * (1 - [Order Details].Discount) As Importe
	FROM [Order Details] INNER JOIN Products ON [Order Details].ProductID = Products.ProductID
	WHERE [Order Details].OrderID = @PedidoId
*/