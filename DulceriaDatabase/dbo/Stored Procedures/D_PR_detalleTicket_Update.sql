CREATE PROCEDURE D_PR_detalleTicket_Update
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

		UPDATE [dbo].[detalleTicket]
		SET
			[idDetalle] = @idDetalle,
			[idTicket] = @idTicket,
			[fecha] = @fecha,
			[idProducto] = @idProducto,
			[cantidad] = @cantidad,
			[precio] = @precio,
			[total] = @total

		WHERE 
			[idDetalle] = @idDetalle


END
