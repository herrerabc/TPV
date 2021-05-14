using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Logica
{
    public interface ICatalogos
    {
        List<object> GetAll(ref ETransactionResult result);
        object Get(object obj, ref ETransactionResult result);
        object Insert(object obj, ref ETransactionResult result);
        void Update(object obj, ref ETransactionResult result);
        void Delete(object obj, ref ETransactionResult result);        
    }
}
