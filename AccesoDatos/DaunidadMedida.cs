using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
		public class DaunidadMedida : IDisposable 
		{
			private string conn = "";
			public DaunidadMedida ()
			{
			conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
			}

#region Insert
	public EunidadMedida unidadMedida_Insert(EunidadMedida item, ref ETransactionResult _transResult)
	{
		EunidadMedida itemInserted = null;
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
					sqlCmd.CommandText = "D_PR_unidadMedida_Insert";
					sqlCmd.Parameters.AddWithValue("@idUnidad",item.idUnidad);
					sqlCmd.Parameters.AddWithValue("@descripcion",item.descripcion);
					using(var reader = sqlCmd.ExecuteReader())
						{
						while (reader.Read())
							{
						itemInserted = new EunidadMedida();
						itemInserted.idUnidad  =  (int) reader["idUnidad"];
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
	public List<EunidadMedida> unidadMedida_GetAll(ref ETransactionResult _transResult)
	{
		var list = new List<EunidadMedida>();
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
					sqlCmd.CommandText = "D_PR_unidadMedida_SelectAll";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 var item = new EunidadMedida();
						item.idUnidad  =  (int) reader["idUnidad"];
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
	public EunidadMedida unidadMedida_Get(EunidadMedida item, ref ETransactionResult _transResult)
	{
		EunidadMedida itemFinded = null;
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
					sqlCmd.Parameters.AddWithValue("@idUnidad",item.idUnidad);
					sqlCmd.CommandText = "D_PR_unidadMedida_Select";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 itemFinded = new EunidadMedida();
						itemFinded.idUnidad  =  (int) reader["idUnidad"];
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
	public void  unidadMedida_Delete(EunidadMedida item, ref ETransactionResult _transResult)
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
				sqlCmd.CommandText = "D_PR_unidadMedida_Delete";
				sqlCmd.Parameters.AddWithValue("@idUnidad",item.idUnidad);
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
	public EunidadMedida unidadMedida_Update(EunidadMedida item, ref ETransactionResult _transResult)
	{
		EunidadMedida itemUpdated = null;
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
					sqlCmd.CommandText = "D_PR_unidadMedida_Update";
					sqlCmd.Parameters.AddWithValue("@idUnidad",item.idUnidad);
					sqlCmd.Parameters.AddWithValue("@descripcion",item.descripcion);
					using(var reader = sqlCmd.ExecuteReader())
						{
					while (reader.Read())
					{
							itemUpdated = new EunidadMedida();
							itemUpdated.idUnidad  =  (int) reader["idUnidad"];
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