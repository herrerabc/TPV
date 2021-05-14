CREATE PROCEDURE D_PR_unidadMedida_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[idUnidad],
			[descripcion]
		FROM 
			[dbo].[unidadMedida]
END
