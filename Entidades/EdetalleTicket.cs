using System;


namespace Dulceria.Entidades
{
public class EdetalleTicket
{
	public  int idDetalle { get ; set; } //(int 4)  not null
	public  int idTicket { get ; set; } //(int 4)  not null
	public  DateTime fecha { get ; set; } //(datetime 8)  not null
	public  int idProducto { get ; set; } //(int 4)  not null
	public  decimal cantidad { get ; set; } //(numeric 9)  not null
	public  decimal precio { get ; set; } //(money 8)  not null
	public  decimal total { get ; set; } //(money 8)  not null
}
} 