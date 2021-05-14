using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.Entidades;
using Dulceria.AccesoDatos;

namespace Dulceria.Logica
{
    public class LUsuarios : ICatalogos
    {
        public void Delete(object obj, ref ETransactionResult result)
        {
            Dausuarios daLista = new Dausuarios();
            daLista.usuarios_Delete((Eusuarios)obj, ref result);
        }

        public object Get(object obj, ref ETransactionResult result)
        {
            Dausuarios daLista = new Dausuarios();
            return daLista.usuarios_Get((Eusuarios)obj, ref result);
        }

        public List<object> GetAll(ref ETransactionResult result)
        {
            Dausuarios daLista = new Dausuarios();
            return daLista.usuarios_GetAll(ref result).ToList<object>();
        }

        public object Insert(object obj, ref ETransactionResult result)
        {
            Dausuarios daLista = new Dausuarios();
            return daLista.usuarios_Insert((Eusuarios)obj, ref result);
        }

        public void Update(object obj, ref ETransactionResult result)
        {
            Dausuarios daLista = new Dausuarios();
            daLista.usuarios_Update((Eusuarios)obj, ref result);
        }
    }
}
