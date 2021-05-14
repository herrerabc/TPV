CREATE PROCEDURE [dbo].[D_PR_TicketById]
	@idTicket int
as
Begin
	
	Select a.idTicket, a.fecha, b.nombre + ' ' + b.apellidoP + ' ' + b.apellidoM as usuario
	from ticket a 
	left join usuarios b on a.usuario =b.usuario
	where a.idTicket = @idTicket

	Select a.idProducto, a.cantidad, a.precio, a.total, b.codigoBarras, b.descripcion
	From detalleTicket a
	inner join productos b on a.idProducto = b.idProducto
	where a.idTicket  = @idTicket
End