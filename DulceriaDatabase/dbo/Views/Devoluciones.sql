CREATE VIEW [dbo].[Devoluciones]
as
select a.fecha, codigoBarras codigoProducto, Upper(c.descripcion) descripcion, round(sum(case when c.idUnidad = 2 then b.cantidad else b.cantidad/1000 end),2) cantidad, 
case when c.idUnidad = 1 then 'Kilogramos' 
	 when c.idUnidad = 2 then 'Piezas'
	 when c.idUnidad = 3 then 'Litros'
	 when c.idUnidad = 4 then 'Metros' end unidad,
b.precio precioUnitario, sum(b.total)  total
from ticket a
inner join detalleTicket b on a.idTicket = b.idTicket 
inner join productos c on b.idProducto = c.idProducto
Where a.cancelado = 1
Group by a.fecha, codigoBarras,c.descripcion, c.idUnidad, b.precio
