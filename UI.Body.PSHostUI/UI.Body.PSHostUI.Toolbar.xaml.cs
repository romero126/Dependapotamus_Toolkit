/*
 * Created by SharpDevelop.
 * Date: 08/13/2017
 * Time: 17:59
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

namespace UI.Body.PSHostUI
{
	/// <summary>
	/// Interaction logic for UserControl2.xaml
	/// </summary>
	public partial class Toolbar : UserControl
	{
		public Toolbar()
		{
			InitializeComponent();
		}
		
		void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			SearchMenu.Visibility = (SearchMenu.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
		}
		
		void Menu_PSState_Start_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (globals.PSruntime != null)
				globals.PSruntime.ps_start();
		}
		void Menu_PSState_Stop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (globals.PSruntime != null)
				globals.PSruntime.ps_stop();
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			globals.UX_Controls_PSRuntime.EventUpdated += (_sender, _e) => { SearchMenu.Visibility = Visibility.Hidden; };
		}
		void PSState_ShowBuffer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			globals.PSHostUI_Control_Body.console.Text = globals.PSruntime.buffer;
		}
	}
}