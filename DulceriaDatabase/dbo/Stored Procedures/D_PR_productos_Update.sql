CREATE PROCEDURE D_PR_productos_Update
		--Parameters

			@idProducto int,
			@idUnidad int = NULL ,
			@descripcion varchar(50),
			@codigoBarras varchar(40),
			@precioReal money,
			@precio money,
			@cantidad numeric(12,4),
			@estado bit


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[productos]
		SET
			[idProducto] = @idProducto,
			[idUnidad] = @idUnidad,
			[descripcion] = @descripcion,
			[codigoBarras] = @codigoBarras,
			[precio] = @precio,
			[precioReal] = @precioReal,
			[cantidad] = @cantidad,
			[estado] = @estado

		WHERE 
			[idProducto] = @idProducto


END
