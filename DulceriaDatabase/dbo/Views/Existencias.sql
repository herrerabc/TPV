Create view Existencias
as
select UPPER(b.descripcion) Unidad,sum(cantidad) Existencia, 
	sum(cantidad * precioReal) Inversion, sum(cantidad * precio) Venta
	, sum(cantidad * precio)  - sum(cantidad * precioReal) Ganancia 
from productos a
inner join unidadMedida b on a.idUnidad= b.idUnidad
where a.estado = 1
group by b.descripcion
