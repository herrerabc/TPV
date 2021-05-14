CREATE PROCEDURE D_PR_productos_Insert
		--Parameters
			@idProducto int,
			@idUnidad int = NULL ,
			@descripcion varchar(50),
			@codigoBarras varchar(40),
			@precio money,
			@precioReal money,
			@cantidad numeric(12,4),
			@estado bit


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[productos]
		(
			[idProducto],
			[idUnidad],
			[descripcion],
			[codigoBarras],
			[precio],
			[precioReal],
			[cantidad],
			[estado]


		)
		VALUES 
		(
			@idProducto,
			@idUnidad,
			@descripcion,
			@codigoBarras,
			@precio,
			@precioReal,
			@cantidad,
			@estado

		)


END
