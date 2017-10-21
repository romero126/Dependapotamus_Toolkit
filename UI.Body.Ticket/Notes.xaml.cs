/*
 * Created by SharpDevelop.
 * Date: 08/01/2017
 * Time: 15:14
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
using System.Xml.Linq;
using System.Xml;
using System.Linq;


namespace UI.Body.Ticket
{
	/// <summary>
	/// Interaction logic for Notes.xaml
	/// </summary>
	public partial class Notes : UserControl
	{
		public Notes()
		{
			InitializeComponent();
		}
		public void Clear()
		{
			text.Text = "";
		}
		public void Load(XDocument XDoc) {
			// text.Text =
			XElement v = XDoc.Element("MAIN").Element("NOTES");
			if (v == null)
				text.Text = "";
			else
				text.Text = v.Value;
		}
		public void Save(XDocument XDoc) {
			XElement node = XDoc.Element("MAIN").Element("NOTES");
			if (node == null)
			{
				node = new XElement("NOTES");
				node.Add();
				XDoc.Element("MAIN").Add(node);
			}
			node.Value = text.Text;
		}

	}
}