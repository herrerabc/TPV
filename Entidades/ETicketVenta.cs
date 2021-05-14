using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Entidades
{
    public class ETicketVenta
    {
        public int Producto { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad  { get; set; }
        public decimal Precio { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }     
    }
}
