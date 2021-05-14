using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dulceria.Entidades;

namespace Dulceria.AccesoDatos
{
		public class Dausuarios : IDisposable 
		{
			private string conn = "";
			public Dausuarios ()
			{
			conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
			}

#region Insert
	public Eusuarios usuarios_Insert(Eusuarios item, ref ETransactionResult _transResult)
	{
		Eusuarios itemInserted = null;
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
					sqlCmd.CommandText = "D_PR_usuarios_Insert";
					sqlCmd.Parameters.AddWithValue("@usuario",item.usuario);
					sqlCmd.Parameters.AddWithValue("@passwd",item.passwd);
					sqlCmd.Parameters.AddWithValue("@nombre",item.nombre);
					sqlCmd.Parameters.AddWithValue("@apellidoP",item.apellidoP);
					sqlCmd.Parameters.AddWithValue("@apellidoM",item.apellidoM);
					sqlCmd.Parameters.AddWithValue("@roll",item.roll);
					sqlCmd.Parameters.AddWithValue("@estatus",item.estatus);
					using(var reader = sqlCmd.ExecuteReader())
						{
						while (reader.Read())
							{
						itemInserted = new Eusuarios();
						itemInserted.usuario  =  (string) reader["usuario"];
						itemInserted.passwd  =  (string) reader["passwd"];
						itemInserted.nombre  =  (string) reader["nombre"];
						itemInserted.apellidoP  =  (string) reader["apellidoP"];
						itemInserted.apellidoM  =  (string) reader["apellidoM"];
						itemInserted.roll  =  (string) reader["roll"];
						itemInserted.estatus  =  reader["estatus"] == DBNull.Value ? null :  (bool?) reader["estatus"];
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
	public List<Eusuarios> usuarios_GetAll(ref ETransactionResult _transResult)
	{
		var list = new List<Eusuarios>();
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
					sqlCmd.CommandText = "D_PR_usuarios_SelectAll";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 var item = new Eusuarios();
						item.usuario  =  (string) reader["usuario"];
						item.passwd  =  (string) reader["passwd"];
						item.nombre  =  (string) reader["nombre"];
						item.apellidoP  =  (string) reader["apellidoP"];
						item.apellidoM  =  (string) reader["apellidoM"];
						item.roll  =  (string) reader["roll"];
						item.estatus  =  reader["estatus"] == DBNull.Value ? null :  (bool?) reader["estatus"];
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
	public Eusuarios usuarios_Get(Eusuarios item, ref ETransactionResult _transResult)
	{
		Eusuarios itemFinded = null;
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
					sqlCmd.Parameters.AddWithValue("@usuario",item.usuario);
					sqlCmd.CommandText = "D_PR_usuarios_Select";
					using (var reader = sqlCmd.ExecuteReader())
					while (reader.Read())
					{
						 itemFinded = new Eusuarios();
						itemFinded.usuario  =  (string) reader["usuario"];
						itemFinded.passwd  =  (string) reader["passwd"];
						itemFinded.nombre  =  (string) reader["nombre"];
						itemFinded.apellidoP  =  (string) reader["apellidoP"];
						itemFinded.apellidoM  =  (string) reader["apellidoM"];
						itemFinded.roll  =  (string) reader["roll"];
						itemFinded.estatus  =  reader["estatus"] == DBNull.Value ? null :  (bool?) reader["estatus"];
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
	public void  usuarios_Delete(Eusuarios item, ref ETransactionResult _transResult)
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
				sqlCmd.CommandText = "D_PR_usuarios_Delete";
				sqlCmd.Parameters.AddWithValue("@usuario",item.usuario);
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
	public Eusuarios usuarios_Update(Eusuarios item, ref ETransactionResult _transResult)
	{
		Eusuarios itemUpdated = null;
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
					sqlCmd.CommandText = "D_PR_usuarios_Update";
					sqlCmd.Parameters.AddWithValue("@usuario",item.usuario);
					sqlCmd.Parameters.AddWithValue("@passwd",item.passwd);
					sqlCmd.Parameters.AddWithValue("@nombre",item.nombre);
					sqlCmd.Parameters.AddWithValue("@apellidoP",item.apellidoP);
					sqlCmd.Parameters.AddWithValue("@apellidoM",item.apellidoM);
					sqlCmd.Parameters.AddWithValue("@roll",item.roll);
					sqlCmd.Parameters.AddWithValue("@estatus",item.estatus);
					using(var reader = sqlCmd.ExecuteReader())
						{
					while (reader.Read())
					{
							itemUpdated = new Eusuarios();
							itemUpdated.usuario  =  (string) reader["usuario"];
							itemUpdated.passwd  =  (string) reader["passwd"];
							itemUpdated.nombre  =  (string) reader["nombre"];
							itemUpdated.apellidoP  =  (string) reader["apellidoP"];
							itemUpdated.apellidoM  =  (string) reader["apellidoM"];
							itemUpdated.roll  =  (string) reader["roll"];
							itemUpdated.estatus  =  reader["estatus"] == DBNull.Value ? null :  (bool?) reader["estatus"];
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