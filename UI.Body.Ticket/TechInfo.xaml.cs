/*
 * Created by SharpDevelop.
 * Date: 08/01/2017
 * Time: 16:59
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
	/// Interaction logic for TechInfo.xaml
	/// </summary>
	public partial class TechInfo : UserControl
	{
		public List<DataClass> _Data = new List<DataClass>();
		private string DataElements = "SDE,User,Environment,Role,Subject,Service Impact,Resources";
		public partial class DataClass {
			public string Name { get; set; }
			public string Text { get; set; }
		}
		public TechInfo()
		{
			InitializeComponent();
			Clear();
			
		}
		public void Clear()
		{
			_Data = new List<DataClass>();
			
			foreach(string i in DataElements.Split(','))
				Add(i + ":", "");
			
			//foreach(DataClass i in _Data)
			//	if (i.Name == "User:")
			//		i.Text = "alextom";
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
		}
		public void Load(XDocument XDoc)
		{
			Clear();
			
			XElement v = XDoc.Element("MAIN").Element("TechInfo");
			if (v == null)
				return;
			foreach(DataClass i in _Data)
			{
				string y = i.Name.TrimEnd(':').Replace(" ", "_");
				i.Text = v.Element(y).Value;
			}
			
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
		}
		public void Save(XDocument XDoc)
		{
			XElement v = XDoc.Element("MAIN").Element("TechInfo");
			if (v == null)
			{
				v = new XElement("TechInfo");
				XDoc.Element("MAIN").Add(v);
			}
			else
				v.RemoveNodes();
			
			foreach (DataClass i in _Data)
			{
				string y = i.Name.TrimEnd(':').Replace(" ", "_");
				
				XElement data = new XElement(y);
				data.Value = i.Text;
				v.Add(data);
			}
		}
		public string ExportToString()
		{
			string result = "";
			
			foreach (DataClass i in _Data)
			{
				if (i.Text != "")
					result = result + string.Format("{0}\r\n {1}\r\n\r\n", i.Name, i.Text.Replace("\r", "").Replace("\n", "\r\n "));
				
			}
			return result;
		}
		public void Add(string Name, string Text)
		{
			DataClass v = new DataClass();
			v.Name = Name;
			v.Text = Text;
			_Data.Add(v);
		}
		void LOG_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataClass SelItem = ((sender as DataGrid).SelectedItem as DataClass);
			switch(SelItem.Name)
			{
				case "User:":
					if (SelItem.Text == "")
						break;
					string alias = SelItem.Text;
					if (!alias.Contains('@'))
					{
						Microsoft.Lync.Model.LyncClient v = Microsoft.Lync.Model.LyncClient.GetClient();	
						string domain = v.Uri.Split('@')[1];
						alias = string.Format("{0}@{1}", SelItem.Text, domain);
					}
					System.Diagnostics.Process.Start(string.Format("SIP:{0}", alias));
					break;
				default:
					//throw new InvalidOperationException("unknown item type");
					break;
			}
		}

	}
}