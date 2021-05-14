CREATE PROCEDURE D_PR_unidadMedida_Insert
		--Parameters
			@idUnidad int,
			@descripcion varchar(15)


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[unidadMedida]
		(
			[idUnidad],
			[descripcion]

		)
		VALUES 
		(
			@idUnidad,
			@descripcion

		)


END
