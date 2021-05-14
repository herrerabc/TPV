CREATE PROCEDURE D_PR_ticket_Insert
		--Parameters
			@idTicket int,
			@fecha datetime,
			@usuario varchar(15),
			@total money,
			@observacion varchar(250) = null,
			@cancelado bit


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[ticket]
		(
			[idTicket],
			[fecha],
			[usuario],
			[total],
			[observacion],
			[cancelado]

		)
		VALUES 
		(
			@idTicket,
			@fecha,
			@usuario,
			@total,
			@observacion,
			@cancelado

		)


END
