/*
CREATE OR ALTER VIEW VW_PRODUCTOSPORENCIMADELPRECIOPROMEDIO
AS
	SELECT ProductName As Producto, UnitPrice As Precio
	FROM Products
	WHERE (UnitPrice > (SELECT AVG(UnitPrice) AS [Precio promedio] FROM Products))
*/