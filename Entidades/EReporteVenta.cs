using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Entidades
{
    public class EReporteVenta
    {
        public System.DateTime fecha { get; set; }
        public string codigoProducto { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public string unidad { get; set; }
        public decimal precioUnitario { get; set; }
        public Nullable<decimal> total { get; set; }
    }
}
