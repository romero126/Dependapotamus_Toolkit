/*
 * Created by SharpDevelop.
 * Date: 08/02/2017
 * Time: 20:17
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
	/// Interaction logic for UI.SideBar.xaml
	/// </summary>
	public partial class SideBar : UserControl
	{
		public SideBar()
		{
			InitializeComponent();
		}

		void SideBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Control g = (sender as Control);
			
			
			var parent = Window.GetWindow(this);
			
			string obj = "Skype,PowerShell,Ticket1,Ticket2,Ticket3,Ticket4,Password";
			
			foreach (string i in obj.Split(','))
			{
				try {
					(parent.FindName(i) as UserControl).Visibility = Visibility.Hidden;
				}
				catch
				{
					
				}
			}
			try {
				(parent.FindName(g.Name) as UserControl).Visibility = Visibility.Visible;
			}
			catch {
				MessageBox.Show("Warning: Caught an error! \r\nThe button you tried to click on has not been implemented yet!\r\nDon't worry it didn't break aything.");
			}
		}
	}
}