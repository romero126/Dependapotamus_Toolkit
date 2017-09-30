/*
 * Created by SharpDevelop.
 * Date: 08/21/2017
 * Time: 16:17
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

namespace UI.Elements.UISettings
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class FlatButton : UserControl
	{
		public string Text { get; set; }
		
		
		public Brush SelectedBGColor { get; set; }
		public Brush HoverBGColor { get; set; }
		public Brush BGColor { get; set; }
		private Brush CurBGColor { get; set; }
		
		
		public event EventHandler Click;
		public FlatButton()
		{
			InitializeComponent();
		}
		void ThisUserControl_Loaded(object sender, RoutedEventArgs e)
		{
			if (BGColor == null)
				BGColor = Brushes.DarkSlateBlue;
			CurBGColor = BGColor;
			if (SelectedBGColor == null)
				SelectedBGColor = Brushes.DodgerBlue;
			if (HoverBGColor == null)
				HoverBGColor = Brushes.LightGray;

		}
		void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (Click != null)
				Click(this, EventArgs.Empty);
		}
	}
}