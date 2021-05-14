CREATE PROCEDURE D_PR_Movimiento_Select
		--Parameters
			@idMovimiento int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[idMovimiento],
			[fecha],
			[usuario],
			[idTipoMovimiento],
			[observacion]
		FROM 
			[dbo].[Movimiento]
		WHERE 
			[idMovimiento] = @idMovimiento
END
