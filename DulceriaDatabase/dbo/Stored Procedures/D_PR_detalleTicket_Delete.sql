CREATE PROCEDURE D_PR_detalleTicket_Delete
		--Parameters
			@idDetalle int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[detalleTicket]
		WHERE 
			[idDetalle] = @idDetalle

END
