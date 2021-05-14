CREATE PROCEDURE D_PR_tipoMovimiento_Insert
		--Parameters
			@idTipoMovimiento varchar(4),
			@descripcion varchar(40)


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[tipoMovimiento]
		(
			[idTipoMovimiento],
			[descripcion]

		)
		VALUES 
		(
			@idTipoMovimiento,
			@descripcion

		)


END
