CREATE PROCEDURE D_PR_detalleTicket_Insert
		--Parameters
			@idDetalle int,
			@idTicket int,
			@fecha datetime,
			@idProducto int,
			@cantidad numeric(12,4),
			@precio money,
			@total money


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[detalleTicket]
		(
			[idDetalle],
			[idTicket],
			[fecha],
			[idProducto],
			[cantidad],
			[precio],
			[total]

		)
		VALUES 
		(
			@idDetalle,
			@idTicket,
			@fecha,
			@idProducto,
			@cantidad,
			@precio,
			@total

		)


END
