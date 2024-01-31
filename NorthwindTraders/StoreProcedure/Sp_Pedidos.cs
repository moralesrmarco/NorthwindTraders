/*
 * 
USE [Northwind]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER   PROCEDURE [dbo].[SP_PEDIDOS_LISTAR20]
AS
BEGIN
	SELECT TOP 20 Orders.OrderID AS Id, Customers.CompanyName AS Cliente, Customers.ContactName AS [Nombre de contacto], 
	Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío],
	Employees.LastName + ', ' + Employees.FirstName AS Vendedor, Shippers.CompanyName AS [Compañía transportista], 
	Orders.ShipName AS [Dirigido a] 
	FROM Orders INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID 
	INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID 
	INNER JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID 
	ORDER BY OrderID DESC
END
-----------------------------------------------------------------------------------------------------
USE [Northwind]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOS_BUSCAR]
	@IdInicial int,
	@IdFinal int,
	@Cliente nvarchar(40),
	@FPedido bit,
	@FPedidoNull bit,
	@FPedidoIni datetime,
	@FPedidoFin datetime,
	@FRequerido bit,
	@FRequeridoNull bit,
	@FRequeridoIni datetime,
	@FRequeridoFin datetime,
	@FEnvio bit,
	@FEnvioNull bit,
	@FEnvioIni datetime,
	@FEnvioFin datetime,
	@Empleado nvarchar(31),
	@CompañiaT nvarchar(40),
	@Dirigidoa nvarchar(40),
	@Producto nvarchar(40) = ''
AS
BEGIN
	SELECT DISTINCT Orders.OrderID AS Id, Customers.CompanyName AS Cliente, Customers.ContactName AS [Nombre de contacto], Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], 
                         Orders.ShippedDate AS [Fecha de envío], Employees.LastName + ', ' + Employees.FirstName AS Empleado, Shippers.CompanyName AS [Compañía transportista], Orders.ShipName AS [Dirigido a]
	FROM Products RIGHT OUTER JOIN
                         [Order Details] ON Products.ProductID = [Order Details].ProductID RIGHT OUTER JOIN
                         Orders ON [Order Details].OrderID = Orders.OrderID LEFT OUTER JOIN
                         Employees ON Orders.EmployeeID = Employees.EmployeeID LEFT OUTER JOIN
                         Shippers ON Orders.ShipVia = Shippers.ShipperID LEFT OUTER JOIN
                         Customers ON Orders.CustomerID = Customers.CustomerID
	WHERE
	(@IdInicial = 0 OR Orders.OrderID BETWEEN @IdInicial AND @IdFinal) 
	AND (@Cliente = '' OR Customers.CompanyName LIKE '%' + @Cliente + '%') 
	AND (@FPedido = 0 OR Orders.OrderDate BETWEEN @FPedidoIni AND @FPedidoFin)
	AND (@FPedidoNull = 0 OR Orders.OrderDate IS NULL)
	AND (@FRequerido = 0 OR Orders.RequiredDate BETWEEN @FRequeridoIni AND @FRequeridoFin)
	AND (@FRequeridoNull = 0 OR Orders.RequiredDate IS NULL)
	AND (@FEnvio = 0 OR Orders.ShippedDate BETWEEN @FEnvioIni AND @FEnvioFin)
	AND (@FEnvioNull = 0 OR Orders.ShippedDate IS NULL)
	AND (@Empleado = '' OR Employees.LastName + ' ' + Employees.FirstName LIKE '%' + @Empleado + '%' ) 
	AND (@CompañiaT = '' OR Shippers.CompanyName LIKE '%' + @CompañiaT + '%')
	AND (@Dirigidoa = '' OR Orders.ShipName LIKE '%' + @Dirigidoa + '%')
	AND (@Producto = '' OR Products.ProductName LIKE '%' + @Producto + '%')
	ORDER BY Orders.OrderID DESC
	--AND (@FPedido = '' OR Orders.OrderDate BETWEEN @FPedidoIni AND DATEADD(ms,1,@FPedidoFin))
END
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_CLIENTES_SELECCIONAR
AS
	SELECT '0' AS Id, '«--- Seleccione ---»' AS Cliente
	UNION ALL
	SELECT CustomerID AS Id, CompanyName AS Cliente FROM Customers
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_EMPLEADOS_SELECCIONAR
AS
	SELECT 0 AS Id, '«--- Seleccione ---»' AS Empleado
	UNION ALL
	SELECT EmployeeID AS Id, LastName + ', ' + FirstName As Empleado FROM Employees
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_TRANSPORTISTAS_SELECCIONAR
AS
	SELECT 0 AS Id, '«--- Seleccione ---»' AS Transportista
	UNION ALL
	SELECT ShipperId AS Id, CompanyName as Transportista from Shippers
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_CATEGORIAS_SELECCIONAR]
AS
	SELECT 0 AS Id, '«--- Seleccione ---»' AS Categoria
	UNION ALL
	Select CategoryId As Id, CategoryName + '   --->>  ' + Convert(nvarchar(50), Description) As Categoria From Categories
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PRODUCTOS_SELECCIONAR]
	@Categoria int
AS
	SELECT 0 AS Id, '«--- Seleccione ---»' AS Producto
	UNION ALL
	Select ProductId As Id,  ProductName As Producto 
	From Products
	Where CategoryId = @Categoria And Discontinued = 'FALSE'
	Order by Producto
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOS_INSERTAR]
	@OrderId int output,
	@CustomerId nchar(5),
	@EmployeeId int,
	@OrderDate datetime,
	@RequiredDate datetime,
	@ShippedDate datetime,
	@ShipVia int,
	@Freight money, 
	@ShipName nvarchar(40),
	@ShipAddress nvarchar(60),
	@ShipCity nvarchar(15),
	@ShipRegion nvarchar(15),
	@ShipPostalCode nvarchar(10),
	@ShipCountry nvarchar(15),
	@lstOrderDetails OrderDetails READONLY
As
Begin
	Begin try
		Begin transaction
			Insert into Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry)
			Values (@CustomerId, @EmployeeId, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)
			Set @OrderId = SCOPE_IDENTITY()
			Insert into [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount)
			Select @OrderId, ProductId, UnitPrice, Quantity, Discount From @lstOrderDetails
		Commit transaction
	End try
	Begin catch
		--Debe llevar el punto y coma
		Rollback transaction;
		Throw;
	End catch
End
-----------------------------------------------------------------------------------------------------
Create Type [dbo].[OrderDetails] As TABLE
(
    Id int not null,
    ProductID int not null,
    UnitPrice decimal(18,2) not null,
    Quantity smallint not null,
    Discount real not null
	Primary Key (Id)
)
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_PEDIDOS_LISTAR1
	@PedidoId int
AS
	SELECT CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, 
	ShipCity, ShipRegion, ShipPostalCode, ShipCountry
	FROM Orders
	WHERE OrderID = @PedidoId
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_DETALLEPEDIDOS_PRODUCTOS_LISTAR1
	@PedidoId int
AS
	SELECT [Order Details].ProductID AS [Id Producto], Products.ProductName AS Producto, [Order Details].UnitPrice AS Precio, 
	[Order Details].Quantity AS Cantidad, [Order Details].Discount AS Descuento
	FROM [Order Details] INNER JOIN Products ON [Order Details].ProductID = Products.ProductID
	WHERE [Order Details].OrderID = @PedidoId
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOS_ACTUALIZAR]
	@OrderId int,
	@CustomerId nchar(5),
	@EmployeeId int,
	@OrderDate datetime,
	@RequiredDate datetime,
	@ShippedDate datetime,
	@ShipVia int,
	@Freight money, 
	@ShipName nvarchar(40),
	@ShipAddress nvarchar(60),
	@ShipCity nvarchar(15),
	@ShipRegion nvarchar(15),
	@ShipPostalCode nvarchar(10),
	@ShipCountry nvarchar(15)
As
Begin
	Begin try
		Begin transaction
			UPDATE Orders SET
			CustomerID = @CustomerId,
			EmployeeID = @EmployeeId,
			OrderDate = @OrderDate,
			RequiredDate =@RequiredDate,
			ShippedDate = @ShippedDate,
			ShipVia = @ShipVia,
			Freight = @Freight,
			ShipName = @ShipName,
			ShipAddress = @ShipAddress,
			ShipCity = @ShipCity,
			ShipRegion = @ShipRegion,
			ShipPostalCode = @ShipPostalCode,
			ShipCountry = @ShipCountry
			WHERE OrderID = @OrderId
		Commit transaction
	End try
	Begin catch
		--Debe llevar el punto y coma
		Rollback transaction;
		Throw;
	End catch
End
-----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[SP_PEDIDOS_ELIMINAR]
	@OrderId int
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE [Order Details] WHERE OrderID = @OrderId
			DELETE Orders WHERE OrderID = @OrderId
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		-- Debe llevar el punto y coma
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END
-----------------------------------------------------------------------------------------------------

*/