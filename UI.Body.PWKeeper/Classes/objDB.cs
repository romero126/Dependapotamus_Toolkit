/*
 * Created by SharpDevelop.

 * Date: 09/05/2017
 * Time: 20:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
namespace UI.Body.PWKeeper.Classes
{
	/// <summary>
	/// Description of objDB.
	/// </summary>
	public class objDB
	{
		public string ID { get; set; }
		public string TITLE { get; set; }
		public string DESC { get; set; }
		public string SALT { get; set; }
		public string HEADER { get; set; }
		public string POS { get; set; }
		
		public objDB(object data)
		{
			foreach (Tuple<string,object> value in data as List<Object>)
			{
				try {
					PropertyInfo v = this.GetType().GetProperty(value.Item1);
					v.SetValue(this, Convert.ChangeType(value.Item2, v.PropertyType));	
				}
				catch {
					
				}
			}
		}
		public objDB() {
			
		}
	}
}
