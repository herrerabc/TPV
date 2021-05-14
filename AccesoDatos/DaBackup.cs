using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dulceria.AccesoDatos
{
    public class DaBackup : IDisposable
    {
        private string conn = "";
        public DaBackup()
        {
            conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        }
        public void Backup(string directorio, ref ETransactionResult _transResult)
        {
            
            _transResult = new ETransactionResult();
            
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        string database = sqlCon.Database;

                        string sql = "BACKUP DATABASE [" + database + "] TO DISK='" + directorio + "\\" + "DB_TPV_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".bak'";

                       
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = sql;

                        sqlCmd.ExecuteNonQuery();
                                                
                        _transResult.message = "OK";
                        _transResult.result = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _transResult.message = ex.Message;
                _transResult.result = 1;                
            }            
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
