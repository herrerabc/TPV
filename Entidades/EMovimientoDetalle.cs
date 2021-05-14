using System;


namespace Dulceria.Entidades
{
    public class EMovimientoDetalle
    {
	    public  int idDetalle { get ; set; } //(int 4)  not null
	    public  int idMovimiento { get ; set; } //(int 4)  not null
	    public  int idProducto { get ; set; } //(int 4)  not null
	    public  decimal cantidad { get ; set; } //(numeric 9)  not null
	    public  string tipoAfectacion { get ; set; } //(char 1)  not null
    }
} 