CREATE PROCEDURE [dbo].[D_PR_detalleTicket_byIdTicket]
	@idTicket int
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[idDetalle],
			[idTicket],
			[fecha],
			[idProducto],
			[cantidad],
			[precio],
			[total]
		FROM 
			[dbo].[detalleTicket]
		WHERE [idTicket] = @idTicket
END