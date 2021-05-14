CREATE PROCEDURE D_PR_MovimientoDetalle_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[idDetalle],
			[idMovimiento],
			[idProducto],
			[cantidad],
			[tipoAfectacion]
		FROM 
			[dbo].[MovimientoDetalle]
END
