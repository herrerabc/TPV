CREATE PROCEDURE D_PR_ticket_SelectAll
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
END
