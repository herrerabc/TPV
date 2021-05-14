using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
    public class Daticket : IDisposable
    {
        private string conn = "";
        public Daticket()
        {
            conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        }

        #region Insert
        public Eticket ticket_Insert(Eticket item, ref ETransactionResult _transResult)
        {
            Eticket itemInserted = null;
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
                        sqlCmd.CommandText = "D_PR_ticket_Insert";
                        sqlCmd.Parameters.AddWithValue("@idTicket", item.idTicket);
                        sqlCmd.Parameters.AddWithValue("@fecha", item.fecha);
                        sqlCmd.Parameters.AddWithValue("@usuario", item.usuario);
                        sqlCmd.Parameters.AddWithValue("@total", item.total);
                        sqlCmd.Parameters.AddWithValue("@cancelado", item.cancelado);
                        sqlCmd.Parameters.AddWithValue("@observacion", item.observacion);

                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new Eticket();
                                itemInserted.idTicket = (int)reader["idTicket"];
                                itemInserted.fecha = (DateTime)reader["fecha"];
                                itemInserted.usuario = (string)reader["usuario"];
                                itemInserted.total = (decimal)reader["total"];
                                itemInserted.cancelado = (bool)reader["cancelado"];
                                itemInserted.observacion = (reader["observacion"] == DBNull.Value) ? "" : (string)reader["observacion"];
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
        public List<Eticket> ticket_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<Eticket>();
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
                        sqlCmd.CommandText = "D_PR_ticket_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new Eticket();
                                item.idTicket = (int)reader["idTicket"];
                                item.fecha = (DateTime)reader["fecha"];
                                item.usuario = (string)reader["usuario"];
                                item.total = (decimal)reader["total"];
                                item.cancelado = (bool)reader["cancelado"];
                                item.observacion = (reader["observacion"] == DBNull.Value) ? "" : (string)reader["observacion"];

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
        public Eticket ticket_Get(Eticket item, ref ETransactionResult _transResult)
        {
            Eticket itemFinded = null;
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
                        sqlCmd.Parameters.AddWithValue("@idTicket", item.idTicket);
                        sqlCmd.CommandText = "D_PR_ticket_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new Eticket();
                                itemFinded.idTicket = (int)reader["idTicket"];
                                itemFinded.fecha = (DateTime)reader["fecha"];
                                itemFinded.usuario = (string)reader["usuario"];
                                itemFinded.total = (decimal)reader["total"];
                                itemFinded.cancelado = (bool)reader["cancelado"];
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
        #region SelectUltimo
        public EImpresion ticket_GetLast(ref ETransactionResult _transResult)
        {
            EImpresion ticket = new EImpresion();
            _transResult = new ETransactionResult();

            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = "D_PR_UltimoTicket";

                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

                        da.Fill(ds);

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            ticket.idTicket = (int)dr["idTicket"];
                            ticket.usuario = (string)dr["usuario"];
                            ticket.fecha = (DateTime)dr["fecha"];
                        }
                        ticket.detalle = new List<EImpresionDetalle>();

                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            EImpresionDetalle item = new EImpresionDetalle();

                            item.idProducto = (int)dr["idProducto"];
                            item.codigoBarras = (string)dr["codigoBarras"];
                            item.descripcion = (string)dr["descripcion"];
                            item.cantidad = (decimal)dr["cantidad"];
                            item.precio = (decimal)dr["precio"];
                            item.total = (decimal)dr["total"];

                            ticket.detalle.Add(item);
                        }


                        da.Dispose();

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
            return ticket;
        }
        #endregion

        #region Select Ticket de Venta
        public EImpresion ticket_GetVenta(int ticket_id, ref ETransactionResult _transResult)
        {
            EImpresion ticket = new EImpresion();
            _transResult = new ETransactionResult();

            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "D_PR_TicketById";
                        sqlCmd.Parameters.AddWithValue("@idTicket", ticket_id);

                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

                        da.Fill(ds);

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            ticket.idTicket = (int)dr["idTicket"];
                            ticket.usuario = (string)dr["usuario"];
                            ticket.fecha = (DateTime)dr["fecha"];
                        }
                        ticket.detalle = new List<EImpresionDetalle>();

                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            EImpresionDetalle item = new EImpresionDetalle();

                            item.idProducto = (int)dr["idProducto"];
                            item.codigoBarras = (string)dr["codigoBarras"];
                            item.descripcion = (string)dr["descripcion"];
                            item.cantidad = (decimal)dr["cantidad"];
                            item.precio = (decimal)dr["precio"];
                            item.total = (decimal)dr["total"];

                            ticket.detalle.Add(item);
                        }


                        da.Dispose();

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
            return ticket;
        }
        #endregion
        #region Delete
        public void ticket_Delete(Eticket item, ref ETransactionResult _transResult)
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
                        sqlCmd.CommandText = "D_PR_ticket_Delete";
                        sqlCmd.Parameters.AddWithValue("@idTicket", item.idTicket);
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
        public Eticket ticket_Update(Eticket item, ref ETransactionResult _transResult)
        {
            Eticket itemUpdated = null;
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
                        sqlCmd.CommandText = "D_PR_ticket_Update";
                        sqlCmd.Parameters.AddWithValue("@idTicket", item.idTicket);
                        sqlCmd.Parameters.AddWithValue("@fecha", item.fecha);
                        sqlCmd.Parameters.AddWithValue("@usuario", item.usuario);
                        sqlCmd.Parameters.AddWithValue("@total", item.total);
                        sqlCmd.Parameters.AddWithValue("@cancelado", item.cancelado);
                        sqlCmd.Parameters.AddWithValue("@observacion", item.observacion);

                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new Eticket();
                                itemUpdated.idTicket = (int)reader["idTicket"];
                                itemUpdated.fecha = (DateTime)reader["fecha"];
                                itemUpdated.usuario = (string)reader["usuario"];
                                itemUpdated.total = (decimal)reader["total"];
                                itemUpdated.cancelado = (bool)reader["cancelado"];
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
        #region Rollback
        public void ticket_RollBack(int idTicket, int idMovimiento, ref ETransactionResult _transResult)
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
                        transaction = sqlCon.BeginTransaction("UpdateTransaction");
                        sqlCmd.Transaction = transaction;
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = "D_PR_Venta_RollBack";
                        sqlCmd.Parameters.AddWithValue("@idTicket", idTicket);
                        sqlCmd.Parameters.AddWithValue("@idMovimietno", idMovimiento);                        
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}