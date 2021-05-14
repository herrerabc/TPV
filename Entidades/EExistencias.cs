using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Entidades
{
    public class EExistencias
    {
        [DisplayName("Categoria")]
        public string Unidad { get; set; }
        [DisplayName("Existencia")]
        public decimal Existencia { get; set; }
        public decimal Inversion { get; set; }
        public decimal Venta { get; set; }
        public decimal Ganancia { get; set; }
    }
}
