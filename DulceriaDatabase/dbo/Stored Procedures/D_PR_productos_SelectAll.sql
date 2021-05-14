CREATE PROCEDURE D_PR_productos_SelectAll
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
END
