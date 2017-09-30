/*
 * Created by SharpDevelop.

 * Date: 9/14/2017
 * Time: 9:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Windows.Forms;
namespace UI.Body.PSHostUI.Classes
{
	/// <summary>
	/// Description of objPSWrapper.
	/// </summary>
	public class PSConsole : INotifyPropertyChanged
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
		public PSConsole(object data)
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
			initializer();
		}
		public PSConsole()
		{
			initializer();
		}
		Classes.objPSListener Listener;
		
		#region define Buffer
		/*
		public string buffer {
			get {
				return 
					Listener.runspace.RunspaceConfiguration..
			}
			
		}
		*/
		
		public string buffer {
			get {
				return Listener.buffer;
			}
			set {
				Listener.buffer = value;
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
		#endregion define Buffer
		
		
		
		private void initializer()
		{
			Listener = new objPSListener();
			
			this.Listener.onBufferChanged += (sender, e) => {
				OnPropertyChanged("buffer");
			};
			
		}
		public void ps_init()
		{
			
		}
		public void ps_start()
		{
			
		}
		public void ps_stop()
		{
			
		}
		public void ps_call(string text) {
			Listener.Execute(text);
			Listener.buffer = Listener.buffer;
			//MessageBox.Show("Finished Running stuff?\r\n\r\n" + buffer);
		}
		
		public void history_add(string text)
		{
			
		}
		public void history_reset()
		{
			
		}
		public void history_prev()
		{
			
		}
		public void history_next()
		{
			
		}
		public string history_getdata()
		{
			return "";
		}
		
	}
}
