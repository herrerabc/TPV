Create procedure D_PR_UltimoTicket
as
Begin
	declare @ticket_id int

	select @ticket_id = max(idTicket) from ticket where cancelado = 0

	Select a.idTicket, a.fecha, b.nombre + ' ' + b.apellidoP + ' ' + b.apellidoM as usuario
	from ticket a 
	left join usuarios b on a.usuario =b.usuario
	where a.idTicket = @ticket_id 

	Select a.idProducto, a.cantidad, a.precio, a.total, b.codigoBarras, b.descripcion
	From detalleTicket a
	inner join productos b on a.idProducto = b.idProducto
	where a.idTicket  = @ticket_id
End