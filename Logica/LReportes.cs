using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.Entidades;
using Dulceria.AccesoDatos;

namespace Dulceria.Logica
{
    public class LReportes : IReportes
    {
        public List<EExistencias> getExistencias(ref ETransactionResult result)
        {
            DaReportes daReportes = new DaReportes();

            return daReportes.Existencia_get(ref result);
        }

        public List<EReporteVenta> getReporteVenta(string fechaIni, string fechaFin,bool devoluciones, ref ETransactionResult result)
        {
            DaReportes daReportes = new DaReportes();

            return daReportes.ReporteVenta_get(fechaIni, fechaFin, devoluciones,  ref result);
        }
    }
}
