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
	Employees.LastName + ', ' + Employees.FirstName AS Empleado, Shippers.CompanyName AS [Compañía transportista], 
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
	@Id int, 
	@Cliente nvarchar(40),
	@FPedido bit,
	@FPedidoNull bit,
	@FPedidoIni datetime,
	@FPedidoFin datetime,
	@FRequerido bit,
	@FRequeridoNull bit,
	--@FRequerido nvarchar(1),
	@FRequeridoIni datetime,
	@FRequeridoFin datetime,
	@FEnvio bit,
	@FEnvioNull bit,
	--@FEnvio nvarchar(1),
	@FEnvioIni datetime,
	@FEnvioFin datetime,
	@Empleado nvarchar(31),
	@CompañiaT nvarchar(40),
	@Dirigidoa nvarchar(40)
AS
BEGIN
	SELECT Orders.OrderID AS Id, Customers.CompanyName AS Cliente, Customers.ContactName AS [Nombre de contacto], 
	Orders.OrderDate AS [Fecha de pedido], Orders.RequiredDate AS [Fecha requerido], Orders.ShippedDate AS [Fecha de envío],
	Employees.LastName + ', ' + Employees.FirstName AS Empleado, Shippers.CompanyName AS [Compañía transportista], 
	Orders.ShipName AS [Dirigido a] 
	FROM Orders INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID 
	INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID 
	INNER JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID 
	WHERE
	(@Id = 0 OR Orders.OrderID = @Id) 
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
	ORDER BY OrderID DESC
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
CREATE OR ALTER   PROCEDURE [dbo].[SP_CATEGORIAS_SELECCIONAR]
AS
	SELECT 0 AS Id, '«--- Seleccione ---»' AS Categoria
	UNION ALL
	Select CategoryId As Id, CategoryName + ', ' + Convert(nvarchar(30), Description) As Categoria From Categories
-----------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------

*/