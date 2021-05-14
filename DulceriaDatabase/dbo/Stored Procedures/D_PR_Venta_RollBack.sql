CREATE PROCEDURE [dbo].[D_PR_Venta_RollBack]
	@idTicket int,
	@idMovimiento int
AS
Begin
	DELETE detalleTicket WHERE idTicket = @idTicket
	DELETE ticket WHERE idTicket = @idTicket

	DELETE MovimientoDetalle WHERE idMovimiento = @idMovimiento
	DELETE Movimiento WHERE idMovimiento = @idMovimiento
End
