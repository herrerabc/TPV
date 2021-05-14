create view UltimoTicket
as
select  a.idTicket, a.fecha, b.total, a.usuario, b.idDetalle, b.cantidad, b.idProducto, b.precio, c.descripcion 
from ticket a inner join detalleTicket b on a.idTicket = b.idTicket 
inner join productos c on b.idProducto = c.idProducto
where a.idTicket = (select max(x.idTicket) from ticket x)
