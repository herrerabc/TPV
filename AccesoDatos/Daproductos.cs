using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
    public class Daproductos : IDisposable
    {
        private string conn = "";
        public Daproductos()
        {
            conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        }

        #region Insert
        public Eproductos productos_Insert(Eproductos item, ref ETransactionResult _transResult)
        {
            Eproductos itemInserted = null;
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
                        sqlCmd.CommandText = "D_PR_productos_Insert";
                        sqlCmd.Parameters.AddWithValue("@idProducto", item.idProducto);
                        sqlCmd.Parameters.AddWithValue("@idUnidad", item.idUnidad);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        sqlCmd.Parameters.AddWithValue("@codigoBarras", item.codigoBarras);
                        sqlCmd.Parameters.AddWithValue("@precio", item.precio);
                        sqlCmd.Parameters.AddWithValue("@precioReal", item.precioReal);
                        sqlCmd.Parameters.AddWithValue("@cantidad", item.cantidad);
                        sqlCmd.Parameters.AddWithValue("@estado", item.estado);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemInserted = new Eproductos();
                                itemInserted.idProducto = (int)reader["idProducto"];
                                itemInserted.idUnidad = reader["idUnidad"] == DBNull.Value ? null : (int?)reader["idUnidad"];
                                itemInserted.descripcion = (string)reader["descripcion"];
                                itemInserted.codigoBarras = (string)reader["codigoBarras"];
                                itemInserted.precio = (decimal)reader["precio"];
                                itemInserted.precioReal = (decimal)reader["precioReal"];
                                itemInserted.cantidad = (decimal)reader["cantidad"];
                                itemInserted.estado = (bool)reader["estado"];
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
        public List<Eproductos> productos_GetAll(ref ETransactionResult _transResult)
        {
            var list = new List<Eproductos>();
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
                        sqlCmd.CommandText = "D_PR_productos_SelectAll";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var item = new Eproductos();
                                item.idProducto = (int)reader["idProducto"];
                                item.idUnidad = reader["idUnidad"] == DBNull.Value ? null : (int?)reader["idUnidad"];
                                item.descripcion = (string)reader["descripcion"];
                                item.codigoBarras = (string)reader["codigoBarras"];
                                item.precio = (decimal)reader["precio"];
                                item.precioReal = (decimal)reader["precioReal"];
                                item.cantidad = (decimal)reader["cantidad"];
                                item.estado = (bool)reader["estado"];
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
        public Eproductos productos_Get(Eproductos item, ref ETransactionResult _transResult)
        {
            Eproductos itemFinded = null;
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
                        sqlCmd.Parameters.AddWithValue("@idProducto", item.idProducto);
                        sqlCmd.CommandText = "D_PR_productos_Select";
                        using (var reader = sqlCmd.ExecuteReader())
                            while (reader.Read())
                            {
                                itemFinded = new Eproductos();
                                itemFinded.idProducto = (int)reader["idProducto"];
                                itemFinded.idUnidad = reader["idUnidad"] == DBNull.Value ? null : (int?)reader["idUnidad"];
                                itemFinded.descripcion = (string)reader["descripcion"];
                                itemFinded.codigoBarras = (string)reader["codigoBarras"];
                                itemFinded.precio = (decimal)reader["precio"];
                                itemFinded.precioReal = (decimal)reader["precioReal"];
                                itemFinded.cantidad = (decimal)reader["cantidad"];
                                itemFinded.estado  = (bool)reader["estado"];
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
        public void productos_Delete(Eproductos item, ref ETransactionResult _transResult)
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
                        sqlCmd.CommandText = "D_PR_productos_Delete";
                        sqlCmd.Parameters.AddWithValue("@idProducto", item.idProducto);
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
        public Eproductos productos_Update(Eproductos item, ref ETransactionResult _transResult)
        {
            Eproductos itemUpdated = null;
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
                        sqlCmd.CommandText = "D_PR_productos_Update";
                        sqlCmd.Parameters.AddWithValue("@idProducto", item.idProducto);
                        sqlCmd.Parameters.AddWithValue("@idUnidad", item.idUnidad);
                        sqlCmd.Parameters.AddWithValue("@descripcion", item.descripcion);
                        sqlCmd.Parameters.AddWithValue("@codigoBarras", item.codigoBarras);
                        sqlCmd.Parameters.AddWithValue("@precio", item.precio);
                        sqlCmd.Parameters.AddWithValue("@precioReal", item.precioReal);
                        sqlCmd.Parameters.AddWithValue("@cantidad", item.cantidad);
                        sqlCmd.Parameters.AddWithValue("@estado", item.estado);
                        using (var reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemUpdated = new Eproductos();
                                itemUpdated.idProducto = (int)reader["idProducto"];
                                itemUpdated.idUnidad = reader["idUnidad"] == DBNull.Value ? null : (int?)reader["idUnidad"];
                                itemUpdated.descripcion = (string)reader["descripcion"];
                                itemUpdated.codigoBarras = (string)reader["codigoBarras"];
                                itemUpdated.precio = (decimal)reader["precio"];
                                itemUpdated.precioReal = (decimal)reader["precioReal"];
                                itemUpdated.cantidad = (decimal)reader["cantidad"];
                                itemUpdated.estado = (bool)reader["estado"];
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