/*
 * Created by SharpDevelop.

 * Date: 09/10/2017
 * Time: 15:15
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
	/// Interaction logic for Settings_Page.xaml
	/// </summary>
	[ContentProperty("Children")]
	public partial class Settings_Page : UserControl
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public ImageSource Icon { get; set; }
		public string guid { get; set; }
		public UIElementCollection Children { get; set; }
		
		/*
		public UIElementCollection Children
	    {
	        get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
	        private set { SetValue(ChildrenProperty, value); }
	    }
	    public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly("Children", typeof(UIElementCollection), typeof(Settings_Page), new PropertyMetadata(null));
	    */
		public Settings_Page()
		{
			InitializeComponent();
			Children = MenuPanels.Children;
		}
	}
}