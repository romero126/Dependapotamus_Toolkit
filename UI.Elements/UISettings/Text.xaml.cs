/*
 * Created by SharpDevelop.
 * Date: 08/21/2017
 * Time: 16:18
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
	/// Interaction logic for UserControl4.xaml
	/// </summary>
	public partial class Text : UserControl
	{
		//public string Value { get; set; }
		
		public string ID {get;set;}
		//public string value {get;set;}
		public string Description {get;set;}
		//public string value { get; set; }
		
		
		public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("value", typeof(string), typeof(Text));

	    public string value
	    {
	    	get { return GetValue(TextProperty).ToString(); }
	        set { 
	        	SetValue( TextProperty, value );
	        	//TextBox.Text=value;
	        }
	    }
	    
		/*
		public string Description { 
			get {
				return Label.Content.ToString();
			}
			set {
				Label.Content = value;
			}
		}
		public string ID { get; set; }
		public string value {
			get {
				return TextBox.Text;
			}
			set {
				Label.Content = value;
			}
		}
		*/
		public Text()
		{
			//DataContext = this;
			InitializeComponent();
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			//TextBox.Text = value;
			//Label.Content = Description;
		}

	}
}