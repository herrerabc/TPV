CREATE PROCEDURE D_PR_tipoMovimiento_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[idTipoMovimiento],
			[descripcion]
		FROM 
			[dbo].[tipoMovimiento]
END
