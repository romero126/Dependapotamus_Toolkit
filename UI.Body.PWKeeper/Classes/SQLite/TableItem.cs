/*
 * Created by SharpDevelop.

 * Date: 9/30/2017
 * Time: 8:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UI.Body.PWKeeper.Classes.SQLite
{
	/// <summary>
	/// Description of TableItem.
	/// </summary>
	public class TableItem
	{
		public string Name { get; set; }
		public object Value { get; set; }
		public Type ValueType {
			get { return typeof(Value); }
		}
		public TableItem()
		{
			
		}
	}
}
