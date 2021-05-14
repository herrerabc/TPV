CREATE PROCEDURE D_PR_MovimientoDetalle_Delete
		--Parameters
			@idDetalle int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[MovimientoDetalle]
		WHERE 
			[idDetalle] = @idDetalle

END
