CREATE PROCEDURE D_PR_usuarios_SelectAll
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
END
