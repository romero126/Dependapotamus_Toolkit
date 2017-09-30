/*
 * Created by SharpDevelop.

 * Date: 09/10/2017
 * Time: 14:51
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
using System.Windows.Markup;

namespace UI.Elements.UX
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	[ContentProperty("Children")]
	public partial class Settings : UserControl
	{
		public string Title { get; set; }
		public string myText { get; set; }

		public event EventHandler EventClose;
		public UIElementCollection Children { get; set; }
		/*
		public UIElementCollection Children
	    {
	        get { return (UIElementCollection)GetValue(ChildrenProperty); }
	        private set { SetValue(ChildrenProperty, value); }
	    }
		
	    //public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly("Children", typeof(UIElementCollection), typeof(Settings), new PropertyMetadata(null));
		public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register("Children", typeof(UIElementCollection), typeof(Settings), new PropertyMetadata(null));
		*/
	    public Settings()
		{
			InitializeComponent();
			Children = MenuPanels.Children;
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			MenuItems.Children.Clear();
			foreach (Settings_Page i in MenuPanels.Children) {
				
				SearchMenu_Item v = new SearchMenu_Item();
				v.Text = i.Title;
				v.guid = i.guid;
				i.Visibility = Visibility.Hidden;
				if (i.Icon != null)
					v.LeftIconSource = i.Icon;
				v.Text_MouseLeftButtonDown += (_sender, _e) => {
					foreach (Settings_Page page in Children)
					{
						if (page.guid == (_sender as SearchMenu_Item).guid)
							page.Visibility = Visibility.Visible;
						else
							page.Visibility = Visibility.Hidden;
					}
				};
				
				MenuItems.Children.Add(v);
				
			}
			if ((Children as UIElementCollection).Count >= 1)
				(Children as UIElementCollection)[0].Visibility = Visibility.Visible;
			
		}
		void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (EventClose != null)
				EventClose(this, e);
		}
	}
}