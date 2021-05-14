CREATE PROCEDURE D_PR_MovimientoDetalle_Select
		--Parameters
			@idDetalle int

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
		WHERE 
			[idDetalle] = @idDetalle
END
