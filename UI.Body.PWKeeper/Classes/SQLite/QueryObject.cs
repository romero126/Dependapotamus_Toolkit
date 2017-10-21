/*
 * Created by SharpDevelop.

 * Date: 9/30/2017
 * Time: 8:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UI.Body.PWKeeper.Classes.SQLite
{
	/// <summary>
	/// Description of QueryObject.
	/// </summary>
	public class QueryObject
	{
		public string Name { get; set; }
		public object Value { get; set; }
		public Type ValueType {
			get { return typeof(Value); }
		}
		public QueryObject(string Name, object Value)
		{
			this.Name = Name;
			this.Value = Value;
		}
	}
}
