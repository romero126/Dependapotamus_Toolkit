/*
 * Created by SharpDevelop.
 * Date: 08/14/2017
 * Time: 19:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;



using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ComponentModel;
//using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace UI.Body.PSHostUI
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public partial class PSRuntime
	{
		// Generate Most Basic Object
		
		public string ID { get; set; }
		public int POS { get; set; }
		public string NAME {get; set;}
		public string DESC {get; set;}
		public byte[] ICON {get; set; }
		public string PATH {get;set;}
		public string COMMAND {get;set;}
		public string SCRIPT {get;set;}
		public int VISIBLE {get; set;}
		
		
		private void base_init(object data)
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
		public PSRuntime(object data)
		{
			base_init(data);
			history_init();
			//ps_init();
		}
		public PSRuntime()
		{
			//base_init(data);
			history_init();
			//ps_init();
		}
	}
}
