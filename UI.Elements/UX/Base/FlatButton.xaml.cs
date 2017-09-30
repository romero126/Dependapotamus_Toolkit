/*
 * Created by SharpDevelop.

 * Date: 9/11/2017
 * Time: 10:08 AM
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
	/// Interaction logic for FlatButton.xaml
	/// </summary>
	public partial class FlatButton : UserControl
	{
		
		public string Text { get; set; }
		public Brush SelectedBackgroundColor { get; set; }
		public Brush HoverBackgroundColor { get; set; }
		public Brush BackgroundColor {
			get { return BackgroundColorProperty; }
			set {
				BackgroundColorProperty = value;
				if (!Selected)
					CurrentBackgroundColor = value;
			}
		}
		private Brush BackgroundColorProperty { get; set; }
		public bool Selected {
			get {
				return SelectedProperty;
			}
			set {
				SelectedProperty = value;
				if (value == true)
					CurrentBackgroundColor = SelectedBackgroundColor;
				if (value == false)
					CurrentBackgroundColor = BackgroundColor;
			}
		}
		private bool SelectedProperty { get; set; }
		private Brush CurrentBackgroundColor {
			get {
				return CurrentBackgroundColorProperty;
			}
			set {
				CurrentBackgroundColorProperty = value;
				_border.Background = value;
			}
		}
		private Brush CurrentBackgroundColorProperty { get; set; }
		
		
		public event EventHandler Click;
		
		public FlatButton()
		{
			InitializeComponent();
			if (BackgroundColor == null)
				BackgroundColor = Brushes.DarkSlateBlue;
			if (SelectedBackgroundColor == null)
				SelectedBackgroundColor = Brushes.DodgerBlue;
			if (HoverBackgroundColor == null)
				HoverBackgroundColor = Brushes.LightGray;
			CurrentBackgroundColor = BackgroundColor;
			
			_border.MouseEnter += (sender, e) => {
				CurrentBackgroundColor = HoverBackgroundColor;
			};
			_border.MouseLeave += (sender, e) => {
				if (Selected == true)
					CurrentBackgroundColor = SelectedBackgroundColor;
				else
					CurrentBackgroundColor = BackgroundColor;
			};
		}
		void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (Click != null)
				Click(this, EventArgs.Empty);
		}
		
	}
}