/*
 * Created by SharpDevelop.
 * Date: 08/29/2017
 * Time: 16:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;


namespace UI.Body.PSHostUI.Classes
{
	/// <summary>
	/// Description of PSCmdlet.
	/// </summary>
	public class PSCmdlet
	{
		public string ID { get; set; }
		public string PSID { get; set; }
		public string NAME { get; set; }
		public string DESC { get; set; }
		public string COMMAND { get; set; }
		public string SCRIPT { get; set; }
		public int VISIBLE { get; set; }
		public int POS { get; set; }

		public PSCmdlet(object data)
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
		public PSCmdlet()
		{
			
		}
	}
}

