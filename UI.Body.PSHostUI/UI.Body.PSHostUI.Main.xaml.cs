/*
 * Created by SharpDevelop.
 * Date: 08/13/2017
 * Time: 17:30
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
using System.Xml;
using System.Windows.Markup;

namespace UI.Body.PSHostUI
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class Main : UserControl
	{
		
		public Main()
		{
			InitializeComponent();
		}
		void Event_UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			globals.PSHostUI_Main = this;
			globals.PSHostUI_Control_Body = Control_Body;
			globals.PSHostUI_Control_Toolbar = Control_Toolbar;
			
			// Updated Things go Below
			
			globals.UX_Settings_PSCmdlet = Settings_PSCmdlet;
			globals.UX_Settings_PSRuntime = Settings_PSRuntime;
			
			// Initialize Toolbar Items
			globals.SQLDB = new Classes.SQLDB("Settings.SQLite");
		}
	}
}