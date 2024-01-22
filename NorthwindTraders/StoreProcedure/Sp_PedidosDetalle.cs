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
*/