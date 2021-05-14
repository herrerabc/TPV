using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
		public class DaMovimientoDetalle : IDisposable 
		{
			private string conn = "";
			public DaMovimientoDetalle ()
			{
			conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
			}

#region Insert
	public EMovimientoDetalle MovimientoDetalle_Insert(EMovimientoDetalle item, ref ETransactionResult _transResult)
	{
		EMovimientoDetalle itemInserted = null;
		_transResult = new ETransactionResult();
		SqlTransaction transaction= null;
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
					sqlCmd.CommandText = "D_PR_MovimientoDetalle_Insert";
					sqlCmd.Parameters.AddWithValue("@idDetalle",item.idDetalle);
					sqlCmd.Parameters.AddWithValue("@idMovimiento",item.idMovimiento);
					sqlCmd.Parameters.AddWithValue("@idProducto",item.idProducto);
					sqlCmd.Parameters.AddWithValue("@cantidad",item.cantidad);
					sqlCmd.Parameters.AddWithValue("@tipoAfectacion",item.tipoAfectacion);
					using(var reader = sqlCmd.ExecuteReader())
						{
						while (reader.Read())
							{
						itemInserted = new EMovimientoDetalle();
						itemInserted.idDetalle  =  (int) reader["idDetalle"];
						itemInserted.idMovimiento  =  (int) reader["idMovimiento"];
						itemInserted.idProducto  =  (int) reader["idProducto"];
						itemInserted.cantidad  =  (decimal) reader["cantidad"];
						itemInserted.tipoAfectacion  =  (string) reader["tipoAfectacion"];
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
	public List<EMovimientoDetalle> MovimientoDetalle_GetAll(ref ETransactionResult _transResult)
	{
		var list = new List<EMovimientoDetalle>();
		_transResult = new ETransactionResult();
		SqlTransaction transaction= null;
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
					sqlCmd.CommandText = "D_PR_MovimientoDetalle_SelectAll";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 var item = new EMovimientoDetalle();
						item.idDetalle  =  (int) reader["idDetalle"];
						item.idMovimiento  =  (int) reader["idMovimiento"];
						item.idProducto  =  (int) reader["idProducto"];
						item.cantidad  =  (decimal) reader["cantidad"];
						item.tipoAfectacion  =  (string) reader["tipoAfectacion"];
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
	public EMovimientoDetalle MovimientoDetalle_Get(EMovimientoDetalle item, ref ETransactionResult _transResult)
	{
		EMovimientoDetalle itemFinded = null;
		_transResult = new ETransactionResult();
		SqlTransaction transaction= null;
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
					sqlCmd.Parameters.AddWithValue("@idDetalle",item.idDetalle);
					sqlCmd.CommandText = "D_PR_MovimientoDetalle_Select";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 itemFinded = new EMovimientoDetalle();
						itemFinded.idDetalle  =  (int) reader["idDetalle"];
						itemFinded.idMovimiento  =  (int) reader["idMovimiento"];
						itemFinded.idProducto  =  (int) reader["idProducto"];
						itemFinded.cantidad  =  (decimal) reader["cantidad"];
						itemFinded.tipoAfectacion  =  (string) reader["tipoAfectacion"];
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
	public void  MovimientoDetalle_Delete(EMovimientoDetalle item, ref ETransactionResult _transResult)
	{
		
		_transResult = new ETransactionResult();
		SqlTransaction transaction= null;
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
				sqlCmd.CommandText = "D_PR_MovimientoDetalle_Delete";
				sqlCmd.Parameters.AddWithValue("@idDetalle",item.idDetalle);
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
	public EMovimientoDetalle MovimientoDetalle_Update(EMovimientoDetalle item, ref ETransactionResult _transResult)
	{
		EMovimientoDetalle itemUpdated = null;
		_transResult = new ETransactionResult();
		SqlTransaction transaction= null;
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
					sqlCmd.CommandText = "D_PR_MovimientoDetalle_Update";
					sqlCmd.Parameters.AddWithValue("@idDetalle",item.idDetalle);
					sqlCmd.Parameters.AddWithValue("@idMovimiento",item.idMovimiento);
					sqlCmd.Parameters.AddWithValue("@idProducto",item.idProducto);
					sqlCmd.Parameters.AddWithValue("@cantidad",item.cantidad);
					sqlCmd.Parameters.AddWithValue("@tipoAfectacion",item.tipoAfectacion);
					using(var reader = sqlCmd.ExecuteReader())
						{
					while (reader.Read())
					{
							itemUpdated = new EMovimientoDetalle();
							itemUpdated.idDetalle  =  (int) reader["idDetalle"];
							itemUpdated.idMovimiento  =  (int) reader["idMovimiento"];
							itemUpdated.idProducto  =  (int) reader["idProducto"];
							itemUpdated.cantidad  =  (decimal) reader["cantidad"];
							itemUpdated.tipoAfectacion  =  (string) reader["tipoAfectacion"];
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