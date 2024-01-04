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
	@FPedidoIni datetime,
	@FPedidoFin datetime,
	@FRequerido bit,
	--@FRequerido nvarchar(1),
	@FRequeridoIni datetime,
	@FRequeridoFin datetime,
	@FEnvio bit,
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
	AND (@FRequerido = 0 OR Orders.RequiredDate BETWEEN @FRequeridoIni AND @FRequeridoFin)
	AND (@FEnvio = 0 OR Orders.ShippedDate BETWEEN @FEnvioIni AND @FEnvioFin)
	AND (@Empleado = '' OR Employees.LastName + ' ' + Employees.FirstName LIKE '%' + @Empleado + '%' ) 
	AND (@CompañiaT = '' OR Shippers.CompanyName LIKE '%' + @CompañiaT + '%')
	AND (@Dirigidoa = '' OR Orders.ShipName LIKE '%' + @Dirigidoa + '%')
	ORDER BY OrderID DESC
	--AND (@FPedido = '' OR Orders.OrderDate BETWEEN @FPedidoIni AND DATEADD(ms,1,@FPedidoFin))
END
-----------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------

*/