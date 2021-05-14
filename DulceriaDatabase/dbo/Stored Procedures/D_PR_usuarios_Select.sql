CREATE PROCEDURE D_PR_usuarios_Select
		--Parameters
			@usuario varchar(15)

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[usuario],
			[passwd],
			[nombre],
			[apellidoP],
			[apellidoM],
			[roll],
			[estatus]
		FROM 
			[dbo].[usuarios]
		WHERE 
			[usuario] = @usuario
END
