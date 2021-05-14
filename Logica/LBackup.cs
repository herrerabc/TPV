using Dulceria.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.Logica
{
    public class LBackup
    {
        public void setBackup(string directorio, ref ETransactionResult res)
        {
            DaBackup db = new DaBackup();

            db.Backup(directorio, ref res);
        }
    }
}
