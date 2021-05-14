CREATE PROCEDURE D_PR_usuarios_Update
		--Parameters

			@usuario varchar(15),
			@passwd varchar(20),
			@nombre varchar(25),
			@apellidoP varchar(25),
			@apellidoM varchar(25),
			@roll varchar(10),
			@estatus bit = NULL 


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[usuarios]
		SET
			[usuario] = @usuario,
			[passwd] = @passwd,
			[nombre] = @nombre,
			[apellidoP] = @apellidoP,
			[apellidoM] = @apellidoM,
			[roll] = @roll,
			[estatus] = @estatus

		WHERE 
			[usuario] = @usuario


END
