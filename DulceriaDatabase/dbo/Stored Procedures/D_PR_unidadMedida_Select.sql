CREATE PROCEDURE D_PR_unidadMedida_Select
		--Parameters
			@idUnidad int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[idUnidad],
			[descripcion]
		FROM 
			[dbo].[unidadMedida]
		WHERE 
			[idUnidad] = @idUnidad
END
