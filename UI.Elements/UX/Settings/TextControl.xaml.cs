/*
 * Created by SharpDevelop.

 * Date: 9/11/2017
 * Time: 2:53 PM
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
	/// Interaction logic for TextControl.xaml
	/// </summary>
	public partial class TextControl : UserControl
	{
		public TextControl()
		{
			InitializeComponent();
		}
		
		
		//public string Value { get; set; }
		
		public string ID {get;set;}

		public string Text { get; set; }
		//public string value { get; set; }
			
		public static readonly DependencyProperty valueProperty =
        DependencyProperty.Register("value", typeof(string), typeof(TextControl));

	    public string value
	    {
	    	get { return GetValue(valueProperty).ToString(); }
	        set { SetValue( valueProperty, value ); }
	    }

	}
}