CREATE PROCEDURE D_PR_ticket_Delete
		--Parameters
			@idTicket int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[ticket]
		WHERE 
			[idTicket] = @idTicket

END
