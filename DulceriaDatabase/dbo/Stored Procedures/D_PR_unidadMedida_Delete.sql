CREATE PROCEDURE D_PR_unidadMedida_Delete
		--Parameters
			@idUnidad int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[unidadMedida]
		WHERE 
			[idUnidad] = @idUnidad

END
