CREATE PROCEDURE D_PR_productos_Delete
		--Parameters
			@idProducto int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[productos]
		WHERE 
			[idProducto] = @idProducto

END
