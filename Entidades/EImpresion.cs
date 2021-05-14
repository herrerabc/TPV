using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Entidades
{
    public class EImpresion
    {
        public int idTicket { get; set; } //(int 4)  not null
        public DateTime fecha { get; set; } //(datetime 8)  not null
        public string usuario { get; set; } //(varchar 15)  not null       
        public List<EImpresionDetalle> detalle { get; set; }
    }

    public class EImpresionDetalle
    {
        public int idProducto { get; set; } //(int 4)  not null
        public string codigoBarras { get; set;}
        public string descripcion { get; set; } //(numeric 9)  not null
        public decimal cantidad { get; set; } //(numeric 9)  not null
        public decimal precio { get; set; } //(money 8)  not null
        public decimal total { get; set; } //(money 8)  not null
    }
}
