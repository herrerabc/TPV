using Dulceria.Entidades;
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
    public class DaReportes
    {
        private string conn = "";
        public DaReportes()
        {
            conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        }
        #region SelectUltimo
        public List<EReporteVenta> ReporteVenta_get(string fecha_ini, string fecha_fin, bool devoluciones,  ref ETransactionResult _transResult)
        {
            List<EReporteVenta> lista = new List<EReporteVenta>();
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        string strSql = "";
                        if(devoluciones)
                           strSql= "SELECT * FROM Devoluciones WHERE fecha between " + fecha_ini + " and " + fecha_fin;
                        else
                            strSql = "SELECT * FROM ReporteVenta WHERE fecha between " + fecha_ini + " and " + fecha_fin;


                        transaction = sqlCon.BeginTransaction("SelectTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = strSql;
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                EReporteVenta itemFinded = new EReporteVenta();

                                itemFinded.fecha = (DateTime)reader["fecha"];
                                itemFinded.codigoProducto = (string)reader["codigoProducto"];
                                itemFinded.descripcion = (string)reader["descripcion"];
                                itemFinded.cantidad = (decimal)reader["cantidad"];
                                itemFinded.unidad = (string)reader["unidad"];
                                itemFinded.precioUnitario = (decimal)reader["precioUnitario"];
                                itemFinded.total = (decimal)reader["total"];
    

                                lista.Add(itemFinded);
                            }
                        transaction.Commit();
                        _transResult.message = "OK";
                        _transResult.result = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                _transResult.message = ex.Message;
                _transResult.result = 1;
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollBackEx)
                {
                    _transResult.rollbackMessage = rollBackEx.Message;
                    _transResult.result = 1;
                }
            }
            return lista;
        }
        public List<EExistencias> Existencia_get(ref ETransactionResult _transResult)
        {
            List<EExistencias> lista = new List<EExistencias>();
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        string strSql = "";

                        strSql = "SELECT * FROM Existencias ";

                        transaction = sqlCon.BeginTransaction("SelectTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = strSql;
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                EExistencias itemFinded = new EExistencias();

                                itemFinded.Unidad = (string)reader["Unidad"];
                                itemFinded.Existencia = (decimal)reader["Existencia"];
                                itemFinded.Inversion = (decimal)reader["Inversion"];
                                itemFinded.Venta = (decimal)reader["Venta"];
                                itemFinded.Ganancia = (decimal)reader["Ganancia"];

                                lista.Add(itemFinded);
                            }
                        transaction.Commit();
                        _transResult.message = "OK";
                        _transResult.result = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                _transResult.message = ex.Message;
                _transResult.result = 1;
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollBackEx)
                {
                    _transResult.rollbackMessage = rollBackEx.Message;
                    _transResult.result = 1;
                }
            }
            return lista;
        }
        #endregion
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
