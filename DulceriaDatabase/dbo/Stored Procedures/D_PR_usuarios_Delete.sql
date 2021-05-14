CREATE PROCEDURE D_PR_usuarios_Delete
		--Parameters
			@usuario varchar(15)


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[usuarios]
		WHERE 
			[usuario] = @usuario

END
