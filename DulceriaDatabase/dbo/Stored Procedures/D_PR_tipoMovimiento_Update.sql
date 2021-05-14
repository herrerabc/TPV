CREATE PROCEDURE D_PR_tipoMovimiento_Update
		--Parameters

			@idTipoMovimiento varchar(4),
			@descripcion varchar(40)


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[tipoMovimiento]
		SET
			[idTipoMovimiento] = @idTipoMovimiento,
			[descripcion] = @descripcion

		WHERE 
			[idTipoMovimiento] = @idTipoMovimiento


END
