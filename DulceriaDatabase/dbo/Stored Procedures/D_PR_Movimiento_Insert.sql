CREATE PROCEDURE D_PR_Movimiento_Insert
		--Parameters
			@idMovimiento int,
			@fecha datetime,
			@usuario varchar(15),
			@idTipoMovimiento varchar(4),
			@observacion varchar(250)

AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[Movimiento]
		(
			[idMovimiento],
			[fecha],
			[usuario],
			[idTipoMovimiento],
			[observacion]

		)
		VALUES 
		(
			@idMovimiento,
			@fecha,
			@usuario,
			@idTipoMovimiento,
			@observacion
		)


END
