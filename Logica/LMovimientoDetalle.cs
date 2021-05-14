using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.AccesoDatos;
using Dulceria.Entidades;

namespace Dulceria.Logica
{
    public class LMovimientoDetalle:ICatalogos 
    {
        public void Delete(object obj, ref ETransactionResult result)
        {
            DaMovimientoDetalle daLista = new DaMovimientoDetalle();
            daLista.MovimientoDetalle_Delete((EMovimientoDetalle)obj, ref result);
        }

        public object Get(object obj, ref ETransactionResult result)
        {
            DaMovimientoDetalle daLista = new DaMovimientoDetalle();
            return daLista.MovimientoDetalle_Get((EMovimientoDetalle)obj, ref result);
        }

        public List<object> GetAll(ref ETransactionResult result)
        {
            DaMovimientoDetalle daLista = new DaMovimientoDetalle();
            return daLista.MovimientoDetalle_GetAll(ref result).ToList<object>();
        }

        public object Insert(object obj, ref ETransactionResult result)
        {
            DaMovimientoDetalle daLista = new DaMovimientoDetalle();
            return daLista.MovimientoDetalle_Insert((EMovimientoDetalle)obj, ref result);
        }

        public void Update(object obj, ref ETransactionResult result)
        {
            DaMovimientoDetalle daLista = new DaMovimientoDetalle();
            daLista.MovimientoDetalle_Update((EMovimientoDetalle)obj, ref result);
        }
    }
}
