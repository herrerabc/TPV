CREATE PROCEDURE D_PR_MovimientoDetalle_Update
		--Parameters

			@idDetalle int,
			@idMovimiento int,
			@idProducto int,
			@cantidad numeric(12,4),
			@tipoAfectacion char(1)


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[MovimientoDetalle]
		SET
			[idDetalle] = @idDetalle,
			[idMovimiento] = @idMovimiento,
			[idProducto] = @idProducto,
			[cantidad] = @cantidad,
			[tipoAfectacion] = @tipoAfectacion

		WHERE 
			[idDetalle] = @idDetalle


END
