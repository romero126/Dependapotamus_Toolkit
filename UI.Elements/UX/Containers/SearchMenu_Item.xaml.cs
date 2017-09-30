/*
 * Created by SharpDevelop.

 * Date: 09/10/2017
 * Time: 15:42
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
	/// Interaction logic for SearchMenu_Item.xaml
	/// </summary>
	public partial class SearchMenu_Item : UserControl
	{
		public Visibility VisibilityDesiredState { get; set; }
		
		public Brush BackgroundColor { get; set; }
		private Brush CurrentBackgroundColor { get; set; }
		public Brush HoverBackgroundColor { get; set; }
		public Brush SelectedBackgroundColor { get; set; }
		
		public ImageSource LeftIconSource { get; set; }
		public ImageSource RightIconSource { get; set; }
		
		public bool AlwaysVisible { get; set; }
		public Visibility IsVisible { get; set; }
		public double Position { get; set; }

		public string Text { get; set; }
		public string guid { get; set; }
		public string Description { get; set; }
		
		public Brush TextColor { get; set; }
		
		public event EventHandler Left_MouseLeftButtonDown;
		public event EventHandler Right_MouseLeftButtonDown;
		public event EventHandler Text_MouseLeftButtonDown;
		
		
		public SearchMenu_Item()
		{
			BackgroundColor = Brushes.Transparent;
			SelectedBackgroundColor = Brushes.DodgerBlue;
			HoverBackgroundColor = Brushes.LightGray;
			TextColor = Brushes.Black;
			InitializeComponent();
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			if (LeftIconSource != null)
				Left_OBJ.Source = LeftIconSource;
			else
				Left_Grid.Visibility = Visibility.Collapsed;
			if (RightIconSource != null)
				Right_OBJ.Source = RightIconSource;
			else
				Right_Grid.Visibility = Visibility.Collapsed;
		}
		void Event_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Grid s = sender as Grid;
			switch (s.Name)
			{
				case "Text_Grid":
					if (Text_MouseLeftButtonDown != null)
						Text_MouseLeftButtonDown(this, e);
					break;
				case "Left_Grid":
					if (Left_MouseLeftButtonDown != null)
						Left_MouseLeftButtonDown(this, e);
					break;
				case "Right_Grid":
					if (Right_MouseLeftButtonDown != null)
						Right_MouseLeftButtonDown(this, e);
					break;
				default:
					break;
			}
			
		}
	}
}