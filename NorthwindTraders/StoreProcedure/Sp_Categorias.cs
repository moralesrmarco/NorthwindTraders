using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.StoreProcedure
{
    internal class Sp_Categorias
    {
    }
}
/*
 * ---------------------------------------------------------------------------------------------------
USE [Northwind]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CATEGORIAS_LISTAR]
	@top100 Bit = 1 
AS
BEGIN
	If @top100 = 1
	BEGIN
		SELECT Categories.CategoryID as Id, Categories.CategoryName as Categoría, Categories.Description as [Descripción], Categories.Picture as Foto
		FROM Categories
		ORDER BY CategoryID DESC
	END
	ELSE
	BEGIN 
		SELECT TOP 20 Categories.CategoryID as Id, Categories.CategoryName as Categoría, Categories.Description as [Descripción], Categories.Picture as Foto
		FROM Categories
		ORDER BY CategoryID DESC
	END
END 
---------------------------------------------------------------------------------------------------
USE [Northwind]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CATEGORIAS_BUSCAR]
	@Id int,
	@Categoria nvarchar(15)
AS
BEGIN
	SELECT Categories.CategoryID as Id, Categories.CategoryName as Categoría, Categories.Description as Descripción, 
	Categories.Picture as Foto
	FROM Categories
	WHERE
	(@Id = 0 OR Categories.CategoryID = @Id) AND 
	(@Categoria = '' OR Categories.CategoryName LIKE '%' + @Categoria + '%')
	ORDER BY Categories.CategoryID DESC
END
---------------------------------------------------------------------------------------------------
USE [Northwind]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CATEGORIAS_ELIMINAR]
	@Id int
as
	Delete Categories
	where CategoryID = @Id
---------------------------------------------------------------------------------------------------
USE [Northwind]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CATEGORIAS_INSERTAR]
    @Categoria NVARCHAR(15),
    @Descripcion NVARCHAR(max),
	@Foto image,
    @Id INT OUTPUT
as
	INSERT INTO Categories
	(CategoryName, Description, Picture)
	VALUES(@Categoria, @Descripcion, @Foto)
    SET @Id = @@IDENTITY
---------------------------------------------------------------------------------------------------


 */