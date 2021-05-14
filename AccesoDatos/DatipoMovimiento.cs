using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
		public class DatipoMovimiento : IDisposable 
		{
			private string conn = "";
			public DatipoMovimiento ()
			{
			conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
			}

#region Insert
	public EtipoMovimiento tipoMovimiento_Insert(EtipoMovimiento item, ref ETransactionResult _transResult)
	{
		EtipoMovimiento itemInserted = null;
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
					sqlCmd.CommandText = "D_PR_tipoMovimiento_Insert";
					sqlCmd.Parameters.AddWithValue("@idTipoMovimiento",item.idTipoMovimiento);
					sqlCmd.Parameters.AddWithValue("@descripcion",item.descripcion);
					using(var reader = sqlCmd.ExecuteReader())
						{
						while (reader.Read())
							{
						itemInserted = new EtipoMovimiento();
						itemInserted.idTipoMovimiento  =  (string) reader["idTipoMovimiento"];
						itemInserted.descripcion  =  (string) reader["descripcion"];
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
	public List<EtipoMovimiento> tipoMovimiento_GetAll(ref ETransactionResult _transResult)
	{
		var list = new List<EtipoMovimiento>();
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
					sqlCmd.CommandText = "D_PR_tipoMovimiento_SelectAll";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 var item = new EtipoMovimiento();
						item.idTipoMovimiento  =  (string) reader["idTipoMovimiento"];
						item.descripcion  =  (string) reader["descripcion"];
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
	public EtipoMovimiento tipoMovimiento_Get(EtipoMovimiento item, ref ETransactionResult _transResult)
	{
		EtipoMovimiento itemFinded = null;
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
					sqlCmd.Parameters.AddWithValue("@idTipoMovimiento",item.idTipoMovimiento);
					sqlCmd.CommandText = "D_PR_tipoMovimiento_Select";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 itemFinded = new EtipoMovimiento();
						itemFinded.idTipoMovimiento  =  (string) reader["idTipoMovimiento"];
						itemFinded.descripcion  =  (string) reader["descripcion"];
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
	public void  tipoMovimiento_Delete(EtipoMovimiento item, ref ETransactionResult _transResult)
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
				sqlCmd.CommandText = "D_PR_tipoMovimiento_Delete";
				sqlCmd.Parameters.AddWithValue("@idTipoMovimiento",item.idTipoMovimiento);
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
	public EtipoMovimiento tipoMovimiento_Update(EtipoMovimiento item, ref ETransactionResult _transResult)
	{
		EtipoMovimiento itemUpdated = null;
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
					sqlCmd.CommandText = "D_PR_tipoMovimiento_Update";
					sqlCmd.Parameters.AddWithValue("@idTipoMovimiento",item.idTipoMovimiento);
					sqlCmd.Parameters.AddWithValue("@descripcion",item.descripcion);
					using(var reader = sqlCmd.ExecuteReader())
						{
					while (reader.Read())
					{
							itemUpdated = new EtipoMovimiento();
							itemUpdated.idTipoMovimiento  =  (string) reader["idTipoMovimiento"];
							itemUpdated.descripcion  =  (string) reader["descripcion"];
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