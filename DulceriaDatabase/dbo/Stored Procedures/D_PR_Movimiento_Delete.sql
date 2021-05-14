CREATE PROCEDURE D_PR_Movimiento_Delete
		--Parameters
			@idMovimiento int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[Movimiento]
		WHERE 
			[idMovimiento] = @idMovimiento

END
