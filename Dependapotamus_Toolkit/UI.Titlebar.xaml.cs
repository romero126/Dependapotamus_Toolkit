/*
 * Created by SharpDevelop.
 * Date: 07/30/2017
 * Time: 17:02
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

namespace UI
{
	/// <summary>
	/// Interaction logic for UI.Titlebar.xaml
	/// </summary>
	public partial class Titlebar : UserControl
	{
		public Titlebar()
		{
			InitializeComponent();
		}
		public string Title { get; set; }
		void Control_Loaded(object sender, RoutedEventArgs e)
		{
			
			this.Label_Title.Content = this.Title;
		}
		void Close(object sender, MouseButtonEventArgs e)
		{
			var parent = Window.GetWindow(this);
			parent.Close();
		}
		void Minimize(object sender, MouseButtonEventArgs e)
		{
			var parent = Window.GetWindow(this);
			parent.WindowState = WindowState.Minimized;
		}
		void Move(object sender, MouseButtonEventArgs e)
		{
    		if (e.LeftButton == MouseButtonState.Pressed)
    		{
    			var parent = Window.GetWindow(this);
	    		parent.DragMove();
    		}
		}
		void DoubleClick(object sender, MouseButtonEventArgs e)
		{

			var parent = Window.GetWindow(this);
			if (parent.WindowState == WindowState.Maximized)
				parent.WindowState = WindowState.Normal;
			else if (parent.WindowState == WindowState.Normal)
			{
				parent.WindowState = WindowState.Maximized;

				// This fixes a bug where it ignores the taskbar when you change the WindowState to Maximized.
				parent.WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
				parent.WindowStyle = System.Windows.WindowStyle.None;
			}

		}
	}
}