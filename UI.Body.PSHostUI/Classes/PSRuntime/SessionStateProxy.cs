/*
 * Created by SharpDevelop.

 * Date: 9/30/2017
 * Time: 8:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows;
namespace UI.Body.PSHostUI.Classes.PSRuntime
{
	/// <summary>
	/// Description of SessionStateProxy.
	/// </summary>
	public class SessionStateProxy
	{
		// Use this area to stitch together more values
		public string Name = "PSHostUI SessionStateProxy";
		public string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		public Object GetWindow = Window.GetWindow(globals.PSHostUI_Main);
		public Object FindName(string name) {
			return (this.GetWindow as Window).FindName(name);
		}

		public Object Callback { get; set; }
		public SessionStateProxy()
		{
			
		}

	}
}
