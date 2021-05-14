CREATE PROCEDURE D_PR_Movimiento_Update
		--Parameters

			@idMovimiento int,
			@fecha datetime,
			@usuario varchar(15),
			@idTipoMovimiento varchar(4),
			@observacion varchar(250)


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[Movimiento]
		SET
			[idMovimiento] = @idMovimiento,
			[fecha] = @fecha,
			[usuario] = @usuario,
			[idTipoMovimiento] = @idTipoMovimiento,
			[observacion] = @observacion

		WHERE 
			[idMovimiento] = @idMovimiento


END
