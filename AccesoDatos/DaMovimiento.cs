using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
    public class DaMovimiento : IDisposable
    {
        private string conn = "";
        public DaMovimiento()
        {
            conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        }

        #region Insert
        public EMovimiento Movimiento_Insert(EMovimiento item, ref ETransactionResult _transResult)
        {
            EMovimiento itemInserted = null;
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        transaction = sqlCon.BeginTransaction("InsertTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "D_PR_Movimiento_Insert";
                        sqlCmd.Parameters.AddWithValue("@idMovimiento", item.idMovimiento);
                        sqlCmd.Parameters.AddWithValue("@fecha", item.fecha);
                        sqlCmd.Parameters.AddWithValue("@usuario", item.usuario);
                        sqlCmd.Parameters.AddWithValue("@idTipoMovimiento", item.idTipoMovimiento);
                        sqlCmd.Parameters.AddWithValue("@observacion", item.observacion);

                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new EMovimiento();
                                itemInserted.idMovimiento = (int)reader["idMovimiento"];
                                itemInserted.fecha = (DateTime)reader["fecha"];
                                itemInserted.usuario = (string)reader["usuario"];
                                itemInserted.idTipoMovimiento = (string)reader["idTipoMovimiento"];
                                item.observacion = (reader["observacion"] == DBNull.Value) ? "" : (string)reader["observacion"];
                            }
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
            return itemInserted;
        }
        #endregion


        #region SelectAll
        public List<EMovimiento> Movimiento_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<EMovimiento>();
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
                        sqlCmd.CommandText = "D_PR_Movimiento_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EMovimiento();
                                item.idMovimiento = (int)reader["idMovimiento"];
                                item.fecha = (DateTime)reader["fecha"];
                                item.usuario = (string)reader["usuario"];
                                item.idTipoMovimiento = (string)reader["idTipoMovimiento"];
                                item.observacion = (reader["observacion"] == DBNull.Value) ? "": (string)reader["observacion"];
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
        public EMovimiento Movimiento_Get(EMovimiento item, ref ETransactionResult _transResult)
        {
            EMovimiento itemFinded = null;
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
                        sqlCmd.Parameters.AddWithValue("@idMovimiento", item.idMovimiento);
                        sqlCmd.CommandText = "D_PR_Movimiento_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new EMovimiento();
                                itemFinded.idMovimiento = (int)reader["idMovimiento"];
                                itemFinded.fecha = (DateTime)reader["fecha"];
                                itemFinded.usuario = (string)reader["usuario"];
                                itemFinded.idTipoMovimiento = (string)reader["idTipoMovimiento"];
                                itemFinded.observacion = (reader["observacion"] == DBNull.Value) ? "" : (string)reader["observacion"];
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
        #region Delete
        public void Movimiento_Delete(EMovimiento item, ref ETransactionResult _transResult)
        {

            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        transaction = sqlCon.BeginTransaction("DeleteTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "D_PR_Movimiento_Delete";
                        sqlCmd.Parameters.AddWithValue("@idMovimiento", item.idMovimiento);
                        sqlCmd.ExecuteNonQuery();
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
        }
        #endregion

        #region Update
        public EMovimiento Movimiento_Update(EMovimiento item, ref ETransactionResult _transResult)
        {
            EMovimiento itemUpdated = null;
            _transResult = new ETransactionResult();
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        transaction = sqlCon.BeginTransaction("UpdateTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "D_PR_Movimiento_Update";
                        sqlCmd.Parameters.AddWithValue("@idMovimiento", item.idMovimiento);
                        sqlCmd.Parameters.AddWithValue("@fecha", item.fecha);
                        sqlCmd.Parameters.AddWithValue("@usuario", item.usuario);
                        sqlCmd.Parameters.AddWithValue("@idTipoMovimiento", item.idTipoMovimiento);
                        sqlCmd.Parameters.AddWithValue("@observacion", item.observacion);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new EMovimiento();
                                itemUpdated.idMovimiento = (int)reader["idMovimiento"];
                                itemUpdated.fecha = (DateTime)reader["fecha"];
                                itemUpdated.usuario = (string)reader["usuario"];
                                itemUpdated.idTipoMovimiento = (string)reader["idTipoMovimiento"];
                                itemUpdated.observacion = (reader["observacion"] == DBNull.Value) ? "" : (string)reader["observacion"];
                            }
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
            return itemUpdated;
        }
        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}