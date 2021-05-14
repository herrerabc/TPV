using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Entidades
{
    public class EUltimoTicket
    {
        public int idTicket { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public string usuario { get; set; }
        public int idDetalle { get; set; }
        public decimal cantidad { get; set; }
        public int idProducto { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
    }
}
