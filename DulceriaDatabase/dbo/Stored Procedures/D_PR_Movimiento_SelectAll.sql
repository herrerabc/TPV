CREATE PROCEDURE D_PR_Movimiento_SelectAll
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
END
