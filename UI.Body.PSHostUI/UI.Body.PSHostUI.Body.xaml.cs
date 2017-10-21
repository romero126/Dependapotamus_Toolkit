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
using System.Windows.Media.Imaging;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

using System.Collections.ObjectModel;
using System.Timers;
using System.Threading;



namespace UI.Body.PSHostUI
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class Body : UserControl
	{
		public string guid { get; set; }
		public Body()
		{
			InitializeComponent();
		}
		public bool Console_AutoScroll = true;
		void Event_Input_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if ((System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift))
				&& e.Key.ToString() == "Return" ) {
				input.Text += "\r\n";
			}
			else if (e.Key.ToString() == "Return") {
				if (globals.PSruntime.ps_status())
					return;
					
				globals.PSruntime.ps_call(input.Text);
				globals.PSruntime.history_add(input.Text);
				globals.PSruntime.history_reset();
				input.Text = "";
				e.Handled = true;
			} else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Up)) {
				globals.PSruntime.history_prev();
				input.Text = globals.PSruntime.history_getdata().ToString();	
			} else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Down)) {
				globals.PSruntime.history_next();
		    	input.Text = globals.PSruntime.history_getdata().ToString();	

			}
		}
		void Event_ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			
			
			ScrollViewer sv = (sender as ScrollViewer);
			
			if (e.ExtentHeightChange == 0)
				if (sv.VerticalOffset == sv.ScrollableHeight)
					Console_AutoScroll = true;
				else
					Console_AutoScroll = false;
		
			if (Console_AutoScroll && e.ExtentHeightChange != 0)
				sv.ScrollToEnd();
		}
		
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			console.DataContext = globals.PSruntime;
			
			DataContext = globals.PSruntime;
			globals.UX_Controls_PSRuntime.EventUpdated += (_sender, _e) => {
				console.DataContext = globals.PSruntime;
				DataContext = globals.PSruntime;
			};
		}
	}
}