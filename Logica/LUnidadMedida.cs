using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.Entidades;
using Dulceria.AccesoDatos;

namespace Dulceria.Logica
{
    public class LUnidadMedida : ICatalogos
    {
        public void Delete(object obj, ref ETransactionResult result)
        {
            DaunidadMedida daLista = new DaunidadMedida();
            daLista.unidadMedida_Delete((EunidadMedida)obj, ref result);
        }

        public object Get(object obj, ref ETransactionResult result)
        {
            DaunidadMedida daLista = new DaunidadMedida();
            return daLista.unidadMedida_Get((EunidadMedida)obj, ref result);
        }

        public List<object> GetAll(ref ETransactionResult result)
        {
            DaunidadMedida daLista = new DaunidadMedida();
            return daLista.unidadMedida_GetAll(ref result).ToList<object>();
        }

        public object Insert(object obj, ref ETransactionResult result)
        {
            DaunidadMedida daLista = new DaunidadMedida();
            return daLista.unidadMedida_Insert((EunidadMedida)obj, ref result);
        }

        public void Update(object obj, ref ETransactionResult result)
        {
            DaunidadMedida daLista = new DaunidadMedida();
            daLista.unidadMedida_Update((EunidadMedida)obj, ref result);
        }
    }
}
