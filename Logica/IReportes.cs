using Dulceria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Logica
{
    public interface IReportes
    {
        List<EReporteVenta> getReporteVenta(string fechaIni, string fechaFin,bool devolucines, ref ETransactionResult result);
        List<EExistencias> getExistencias(ref ETransactionResult result);
    }
}
