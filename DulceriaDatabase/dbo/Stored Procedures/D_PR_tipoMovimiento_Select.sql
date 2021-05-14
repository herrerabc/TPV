CREATE PROCEDURE D_PR_tipoMovimiento_Select
		--Parameters
			@idTipoMovimiento varchar(4)

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[idTipoMovimiento],
			[descripcion]
		FROM 
			[dbo].[tipoMovimiento]
		WHERE 
			[idTipoMovimiento] = @idTipoMovimiento
END
