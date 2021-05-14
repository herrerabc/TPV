CREATE PROCEDURE D_PR_unidadMedida_Update
		--Parameters

			@idUnidad int,
			@descripcion varchar(15)


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[unidadMedida]
		SET
			[idUnidad] = @idUnidad,
			[descripcion] = @descripcion

		WHERE 
			[idUnidad] = @idUnidad


END
