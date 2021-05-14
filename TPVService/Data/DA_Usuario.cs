using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TPVService.Entities;

namespace TPVService.Data
{
    public class DA_Usuario
    {
        private string conn = "";
        public DA_Usuario()
        {
            conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        }
        #region SelectAll
        public List<Usuario> usuarios_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<Usuario>();
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        transaction = sqlCon.BeginTransaction("SelectAllTranstaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "D_PR_usuarios_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new Usuario();
                                
                                item.usuario = (string)reader["usuario"];
                                item.passwd = (string)reader["passwd"];
                                item.nombre = (string)reader["nombre"];
                                item.apellidoP = (string)reader["apellidoP"];
                                item.apellidoM = (string)reader["apellidoM"];
                                item.roll = (string)reader["roll"];
                                item.estatus = reader["estatus"] == DBNull.Value ? null : (bool?)reader["estatus"];
                                list.Add(item);
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
            return list;
        }
        #endregion


        #region Select
        public Usuario usuarios_Get(Usuario item, ref ETransactionResult _transResult)
        {
            Usuario itemFinded = null;
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        transaction = sqlCon.BeginTransaction("SelectTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@usuario", item.usuario);
                        sqlCmd.CommandText = "D_PR_usuarios_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new Usuario();
                                itemFinded.usuario = (string)reader["usuario"];
                                itemFinded.passwd = (string)reader["passwd"];
                                itemFinded.nombre = (string)reader["nombre"];
                                itemFinded.apellidoP = (string)reader["apellidoP"];
                                itemFinded.apellidoM = (string)reader["apellidoM"];
                                itemFinded.roll = (string)reader["roll"];
                                itemFinded.estatus = reader["estatus"] == DBNull.Value ? null : (bool?)reader["estatus"];
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
            return itemFinded;
        }
        #endregion
    }
}