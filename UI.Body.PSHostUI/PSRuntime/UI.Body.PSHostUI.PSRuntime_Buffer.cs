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
	public partial class PSRuntime : INotifyPropertyChanged
	{
		
		private string stdio;
		public string buffer {
			get {
				return stdio;
			}
			set {
				stdio = value;
				OnPropertyChanged("buffer");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
		
		public void buffer_writeline(string text) {
			buffer += string.Format("{0}\r\n", text);
		}
		public void buffer_write(string text) {
			buffer += string.Format("{0}", text);
		}
	}
}
