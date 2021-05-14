CREATE PROCEDURE D_PR_ticket_Update
		--Parameters

			@idTicket int,
			@fecha datetime,
			@usuario varchar(15),
			@total money,
			@cancelado bit,
			@observacion varchar(250) = null


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[ticket]
		SET
			[idTicket] = @idTicket,
			[fecha] = @fecha,
			[usuario] = @usuario,
			[total] = @total,
			[observacion] = @observacion,
			[cancelado] = @cancelado

		WHERE 
			[idTicket] = @idTicket


END
