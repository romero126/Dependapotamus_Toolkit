/*
 * Created by SharpDevelop.
 * Date: 8/31/2017
 * Time: 10:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows.Forms;


namespace UI.Body.PSHostUI.Classes
{
	/// <summary>
	/// Description of SQLDB.
	/// </summary>
	public class SQLDB
	{
		public SQLiteConnection database;
		public SQLDB(string path)
		{
			string connectionString = "Data Source=" + path + ";Pooling=true;FailIfMissing=false;Synchronous=Full;";
			database = new SQLiteConnection(connectionString);
		}
		~SQLDB()
		{
			database.Dispose();
		}
		public int ExecuteNonQuery(string query)
		{
			database.Open();
			
			SQLiteCommand call = new SQLiteCommand(query, database);
			int result = -1;
			try {
				result = call.ExecuteNonQuery();
			}
			catch {
				
			}
			database.Close();
			return result;
		}
		public List<object> GenerateQuery(string query)
		{
			// List<Table> -> List<Table>Row - Tuple<string, object>Key,Value 
			// Note: This will be slow for larger tables, do not use if database is big.
			// 
			database.Open();
			
			List<object> result = new List<object>();
			using (SQLiteCommand cmd = new SQLiteCommand(query, database))
			{
				using (SQLiteDataReader r = cmd.ExecuteReader())
				{
					
					while (r.Read())
					{
						List<Object> _obj = new List<Object>();
						for (int i = 0; i <= (r.FieldCount - 1); i++)
							_obj.Add(new Tuple<string, object>(r.GetName(i), r.GetValue(i)));
						result.Add(_obj);
					}
					
				}
			}
			database.Close();
			
			return result;
		}
		public int Insert(String tableName, Dictionary<String, Object> data)
		{
			String vals = "";
			if (data.Count >= 1)
			{
				SQLiteCommand command = new SQLiteCommand(database);
				database.Open();
				
				foreach (KeyValuePair<String, Object> val in data)
				{
					if (vals != "")
						vals += ",";
					vals += string.Format("{0} = @{0}", val.Key);
				}
				command.CommandText = string.Format("insert into {0} set {1}", tableName, vals);
				foreach (KeyValuePair<String, Object> val in data)
					command.Parameters.AddWithValue(val.Key, val.Value);

				int result = -1;
				try {
					result = command.ExecuteNonQuery(); 
				}
				catch {
					
				}
				database.Close();
				return result;
			}
			return -1;
		}
			
			
		public int Update(String tableName, Dictionary<String, Object> data, String whereobj)
		{
			
			String vals = "";
			
			if (data.Count >= 1)
			{

				SQLiteCommand command = new SQLiteCommand(database);
				
				database.Open();
							
				foreach (KeyValuePair<String, Object> val in data)
				{
					if (vals != "")
						vals += ",";
					vals += string.Format("{0} = @{0}", val.Key);
				}
				
				command.CommandText = string.Format("update {0} set {1} where {2}", tableName, vals, whereobj);
				
				foreach (KeyValuePair<String, Object> val in data)
					command.Parameters.AddWithValue(val.Key, val.Value);
				int result = -1;
				try {
					result = command.ExecuteNonQuery();
				}
				catch {}
				database.Close();
			
				return result;
			}
			return -1;
		}
	}
}
