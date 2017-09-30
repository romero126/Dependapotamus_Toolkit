/*
 * Created by SharpDevelop.

 * Date: 09/01/2017
 * Time: 20:36
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

namespace UI.Elements.ToolBar
{
	/// <summary>
	/// Interaction logic for SmallButton.xaml
	/// </summary>
	public partial class SmallButton : UserControl
	{
		public ImageSource Source { get; set; }
		
		public Brush BackgroundColor { get; set; }
		private Brush CurrentBackgroundColor { get; set; }
		public Brush HoverBackgroundColor { get; set; }
		public Brush SelectedBackgroundColor { get; set; }
		
		public SmallButton()
		{
			
			BackgroundColor = Brushes.Transparent;
			SelectedBackgroundColor = Brushes.DodgerBlue;
			HoverBackgroundColor = Brushes.SlateBlue;
			InitializeComponent();
			
			this._Body.MouseEnter += (sender, e) => _Body.Background = HoverBackgroundColor;
			this._Body.MouseLeave += (sender, e) => _Body.Background = BackgroundColor;
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			if (Source != null)
				_Image.Source = Source;
		}

	}
}