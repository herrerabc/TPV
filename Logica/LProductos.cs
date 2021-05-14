using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dulceria.Entidades;
using Dulceria.AccesoDatos;

namespace Dulceria.Logica
{
    public class LProductos : ICatalogos
    {
        public void Delete(object obj, ref ETransactionResult result)
        {
            Daproductos daLista = new Daproductos();
            daLista.productos_Delete((Eproductos)obj, ref result);
        }

        public object Get(object obj, ref ETransactionResult result)
        {
            Daproductos daLista = new Daproductos();
            return (Eproductos)daLista.productos_Get((Eproductos)obj, ref result);
        }

        public List<object> GetAll( ref ETransactionResult result)
        {
            Daproductos daLista = new Daproductos();
            return daLista.productos_GetAll(ref result).ToList<object>();
        }

        public object Insert(object obj, ref ETransactionResult result)
        {
            Daproductos daLista = new Daproductos();
            return (Eproductos)daLista.productos_Insert((Eproductos)obj, ref result);
        }

        public void Update(object obj, ref ETransactionResult result)
        {
            Daproductos daLista = new Daproductos();
            daLista.productos_Update((Eproductos)obj, ref result);
        }
    }
}
