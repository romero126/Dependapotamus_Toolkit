/*
 * Created by SharpDevelop.

 * Date: 9/11/2017
 * Time: 10:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace UI.Elements.UX
{
	/// <summary>
	/// Interaction logic for Password.xaml
	/// </summary>
	public partial class Password : UserControl
	{
		public string Text { get; set; }
		public string Value {
			get {
				return Pass.Password;
			}
			set {
				Pass.Password = value;
			}
		}
		
		public event EventHandler Updated;
		public Password()
		{
			InitializeComponent();
		}
		void Pass_KeyUp(object sender, KeyEventArgs e)
		{
			if (Updated != null)
				Updated(this, EventArgs.Empty);
		}
	}
}