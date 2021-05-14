CREATE PROCEDURE D_PR_MovimientoDetalle_Insert
		--Parameters
			@idDetalle int,
			@idMovimiento int,
			@idProducto int,
			@cantidad numeric(12,4),
			@tipoAfectacion char(1)


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[MovimientoDetalle]
		(
			[idDetalle],
			[idMovimiento],
			[idProducto],
			[cantidad],
			[tipoAfectacion]

		)
		VALUES 
		(
			@idDetalle,
			@idMovimiento,
			@idProducto,
			@cantidad,
			@tipoAfectacion

		)


END
