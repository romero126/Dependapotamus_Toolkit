/*
 * Created by SharpDevelop.

 * Date: 09/30/2017
 * Time: 20:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows.Forms;
namespace UI.Body.PWKeeper.Classes.SQLite
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
						List<QueryObject> _obj = new List<QueryObject>();
						for (int i = 0; i <= (r.FieldCount - 1); i++)
							_obj.Add(new QueryObject(r.GetName(i), r.GetValue(i) ) );
						result.Add(_obj);
					}
				}
			}
			database.Close();
			
			return result;
		}
		
		
	}
}
