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
	/// Interaction logic for UserControl2.xaml
	/// </summary>
	public partial class SearchMenu : UserControl
	{
		public Brush Control_Background { get; set; }
		public double Control_Opacity { get; set; }
		public Brush Control_SearchBackground { get; set; }
		public Brush Control_SearchForeground { get; set; }
		
		public Brush Item_BackgroundColor { get; set; }
		public Brush Item_HoverBackgroundColor { get; set; }
		public Brush Item_SelectedBackgroundColor { get; set; }
		public ImageSource Item_LeftIconSource { get; set; }
		public ImageSource Item_RightIconSource { get; set; }
		public event EventHandler Item_Left_MouseLeftButtonDown;
		public event EventHandler Item_Right_MouseLeftButtonDown;
		public event EventHandler Item_Text_MouseLeftButtonDown;
		
		public double Item_Height { get; set; }
		
		public List<UX.SearchMenu_Item> Items_List { get; set; }
		
		public SearchMenu()
		{
			Control_SearchForeground = Brushes.Black;
			Control_SearchBackground = Brushes.White;
			Control_Background = Brushes.White;
			Control_Opacity = 1;
			InitializeComponent();
		}
		public void ClearItems()
		{
			Children.Children.Clear();
		}
		public void RemoveItem(string guid) {
			foreach (UX.SearchMenu_Item obj in Children.Children)
				if (obj.guid == guid)
					Children.Children.Remove(obj);
		}
		public void AddItem(string text)
		{
			UX.SearchMenu_Item obj = new UX.SearchMenu_Item();
			obj.Text = text;
			obj.VisibilityDesiredState = Visibility.Visible;
			if (Item_BackgroundColor != null)
				obj.BackgroundColor = Item_BackgroundColor;
			if (Item_HoverBackgroundColor != null)
				obj.HoverBackgroundColor = Item_HoverBackgroundColor;
			if (Item_SelectedBackgroundColor != null)
				obj.SelectedBackgroundColor = Item_SelectedBackgroundColor;
			if (Item_LeftIconSource != null)
				obj.LeftIconSource = Item_LeftIconSource;
			if (Item_RightIconSource != null)
				obj.RightIconSource = Item_RightIconSource;
			if (Item_Left_MouseLeftButtonDown != null)
				obj.Left_MouseLeftButtonDown += Item_Left_MouseLeftButtonDown;
			if (Item_Right_MouseLeftButtonDown != null)
				obj.Right_MouseLeftButtonDown += Item_Right_MouseLeftButtonDown;
			if (Item_Text_MouseLeftButtonDown != null)
				obj.Text_MouseLeftButtonDown += Item_Text_MouseLeftButtonDown;
			Children.Children.Add(obj);
			
		}
		public void AddItem(UX.SearchMenu_Item obj)
		{
			Children.Children.Add(obj);
		}
		void Search_KeyDown(object sender, KeyEventArgs e)
		{
			string myText = Search.Text.ToLower();
			
			if ((e.Key == Key.Back) && (myText.Length >= 1))
				myText = myText.Remove(myText.Length-1, 1);
			if (e.Key.ToString().Length == 1)
				myText += e.Key.ToString().ToLower();
			
			foreach (UX.SearchMenu_Item obj in Children.Children)
			{
				if (myText == "")
					obj.Visibility = obj.VisibilityDesiredState;
				else if (obj.Text.ToLower().Contains(myText))
					obj.Visibility = Visibility.Visible;
				else
					if (obj.AlwaysVisible != true)
						obj.Visibility = Visibility.Collapsed;
			}
		}
	}
}