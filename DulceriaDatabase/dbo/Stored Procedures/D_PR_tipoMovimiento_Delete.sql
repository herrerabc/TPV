CREATE PROCEDURE D_PR_tipoMovimiento_Delete
		--Parameters
			@idTipoMovimiento varchar(4)


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[tipoMovimiento]
		WHERE 
			[idTipoMovimiento] = @idTipoMovimiento

END
