CREATE PROCEDURE D_PR_productos_Select
		--Parameters
			@idProducto int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[idProducto],
			[idUnidad],
			[descripcion],
			[codigoBarras],
			[precio],
			[precioReal],
			[cantidad],
			[estado]
		FROM 
			[dbo].[productos]
		WHERE 
			[idProducto] = @idProducto
END
