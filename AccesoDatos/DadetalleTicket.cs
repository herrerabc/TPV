using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
    public class DadetalleTicket : IDisposable
    {
        private string conn = "";
        public DadetalleTicket()
        {
            conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        }

        #region Insert
        public EdetalleTicket detalleTicket_Insert(EdetalleTicket item, ref ETransactionResult _transResult)
        {
            EdetalleTicket itemInserted = null;
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
                        sqlCmd.CommandText = "D_PR_detalleTicket_Insert";
                        sqlCmd.Parameters.AddWithValue("@idDetalle", item.idDetalle);
                        sqlCmd.Parameters.AddWithValue("@idTicket", item.idTicket);
                        sqlCmd.Parameters.AddWithValue("@fecha", item.fecha);
                        sqlCmd.Parameters.AddWithValue("@idProducto", item.idProducto);
                        sqlCmd.Parameters.AddWithValue("@cantidad", item.cantidad);
                        sqlCmd.Parameters.AddWithValue("@precio", item.precio);
                        sqlCmd.Parameters.AddWithValue("@total", item.total);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new EdetalleTicket();
                                itemInserted.idDetalle = (int)reader["idDetalle"];
                                itemInserted.idTicket = (int)reader["idTicket"];
                                itemInserted.fecha = (DateTime)reader["fecha"];
                                itemInserted.idProducto = (int)reader["idProducto"];
                                itemInserted.cantidad = (decimal)reader["cantidad"];
                                itemInserted.precio = (decimal)reader["precio"];
                                itemInserted.total = (decimal)reader["total"];
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
        public List<EdetalleTicket> detalleTicket_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<EdetalleTicket>();
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
                        sqlCmd.CommandText = "D_PR_detalleTicket_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EdetalleTicket();
                                item.idDetalle = (int)reader["idDetalle"];
                                item.idTicket = (int)reader["idTicket"];
                                item.fecha = (DateTime)reader["fecha"];
                                item.idProducto = (int)reader["idProducto"];
                                item.cantidad = (decimal)reader["cantidad"];
                                item.precio = (decimal)reader["precio"];
                                item.total = (decimal)reader["total"];
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

        #region SelectAll
        public List<EdetalleTicket> detalleTicket_GetByIdTicket(Eticket enc, ref ETransactionResult _transResult)
        {
            var list = new List<EdetalleTicket>();
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
                        sqlCmd.CommandText = "D_PR_detalleTicket_byIdTicket";
                        sqlCmd.Parameters.AddWithValue("@idTicket", enc.idTicket);


                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new EdetalleTicket();
                                item.idDetalle = (int)reader["idDetalle"];
                                item.idTicket = (int)reader["idTicket"];
                                item.fecha = (DateTime)reader["fecha"];
                                item.idProducto = (int)reader["idProducto"];
                                item.cantidad = (decimal)reader["cantidad"];
                                item.precio = (decimal)reader["precio"];
                                item.total = (decimal)reader["total"];
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
        public EdetalleTicket detalleTicket_Get(EdetalleTicket item, ref ETransactionResult _transResult)
        {
            EdetalleTicket itemFinded = null;
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
                        sqlCmd.Parameters.AddWithValue("@idDetalle", item.idDetalle);
                        sqlCmd.CommandText = "D_PR_detalleTicket_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new EdetalleTicket();
                                itemFinded.idDetalle = (int)reader["idDetalle"];
                                itemFinded.idTicket = (int)reader["idTicket"];
                                itemFinded.fecha = (DateTime)reader["fecha"];
                                itemFinded.idProducto = (int)reader["idProducto"];
                                itemFinded.cantidad = (decimal)reader["cantidad"];
                                itemFinded.precio = (decimal)reader["precio"];
                                itemFinded.total = (decimal)reader["total"];
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
        public void detalleTicket_Delete(EdetalleTicket item, ref ETransactionResult _transResult)
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
                        sqlCmd.CommandText = "D_PR_detalleTicket_Delete";
                        sqlCmd.Parameters.AddWithValue("@idDetalle", item.idDetalle);
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
        public EdetalleTicket detalleTicket_Update(EdetalleTicket item, ref ETransactionResult _transResult)
        {
            EdetalleTicket itemUpdated = null;
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
                        sqlCmd.CommandText = "D_PR_detalleTicket_Update";
                        sqlCmd.Parameters.AddWithValue("@idDetalle", item.idDetalle);
                        sqlCmd.Parameters.AddWithValue("@idTicket", item.idTicket);
                        sqlCmd.Parameters.AddWithValue("@fecha", item.fecha);
                        sqlCmd.Parameters.AddWithValue("@idProducto", item.idProducto);
                        sqlCmd.Parameters.AddWithValue("@cantidad", item.cantidad);
                        sqlCmd.Parameters.AddWithValue("@precio", item.precio);
                        sqlCmd.Parameters.AddWithValue("@total", item.total);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new EdetalleTicket();
                                itemUpdated.idDetalle = (int)reader["idDetalle"];
                                itemUpdated.idTicket = (int)reader["idTicket"];
                                itemUpdated.fecha = (DateTime)reader["fecha"];
                                itemUpdated.idProducto = (int)reader["idProducto"];
                                itemUpdated.cantidad = (decimal)reader["cantidad"];
                                itemUpdated.precio = (decimal)reader["precio"];
                                itemUpdated.total = (decimal)reader["total"];
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