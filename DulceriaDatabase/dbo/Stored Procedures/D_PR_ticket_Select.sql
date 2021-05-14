CREATE PROCEDURE D_PR_ticket_Select
		--Parameters
			@idTicket int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[idTicket],
			[fecha],
			[usuario],
			[total],
			[observacion],
			[cancelado]
		FROM 
			[dbo].[ticket]
		WHERE 
			[idTicket] = @idTicket
END
