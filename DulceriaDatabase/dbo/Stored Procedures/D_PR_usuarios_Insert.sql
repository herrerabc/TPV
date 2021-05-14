CREATE PROCEDURE D_PR_usuarios_Insert
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

		INSERT INTO [dbo].[usuarios]
		(
			[usuario],
			[passwd],
			[nombre],
			[apellidoP],
			[apellidoM],
			[roll],
			[estatus]

		)
		VALUES 
		(
			@usuario,
			@passwd,
			@nombre,
			@apellidoP,
			@apellidoM,
			@roll,
			@estatus

		)


END
