/*
 * Created by SharpDevelop.
 * Date: 07/23/2017
 * Time: 10:14
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
	/// Interaction logic for UI.Body.Ticket.xaml
	/// </summary>
	public partial class Logs : UserControl
	{
		public int ID { get; set; }
		public string SDE { get; set; }
		public List<DataClass> _Data = new List<DataClass>();

		public partial class DataClass {
			public string ID { get; set; }
			public string IsVisible { get; set; }
			public string User { get; set; }
			public string Time { get; set; }
			public string Text { get; set; }
		}
		public Logs()
		{
			InitializeComponent();
		}
		void Control_Loaded(object sender, RoutedEventArgs e)
		{
			LOG.DataContext = _Data;
		}
		public void Clear()
		{
			_Data = new List<DataClass>();
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
		}
		private void ResetGridID() {
			if (LOG.ItemsSource == null)
				return;
			int i = 0;
			foreach (DataClass data in LOG.ItemsSource) {
				i++;
				data.ID = i.ToString();
			}
		}
		public void Add(string ID, string User, string Time, string IsVisible, string Text)
		{
			LOG.CommitEdit();
			
			DataClass v = new DataClass();
			v.ID = (ID == "") ? (_Data.Count() + 1).ToString() : ID;
			v.User = (User == "") ? Environment.UserName : User;
			v.Time = (Time == "") ? System.DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt") : Time;
			v.IsVisible = (IsVisible == "True" || IsVisible == "False") ? IsVisible : "True";
			v.Text = Text;
			_Data.Add(v);
		}
		
		public void Save(XDocument XDoc) {
			dynamic nodes = XDoc.Element("MAIN").Elements("TicketLog");
			XElement FoundNode = null;
			// Check if ID Exists in XDoc
			foreach (XElement node in nodes)
				if (node.Attribute("ID").Value == ID.ToString())
					FoundNode = node;
			
			if (FoundNode == null)
			{
				FoundNode = new XElement("TicketLog");
				FoundNode.Add(new XAttribute("ID", ID.ToString()));
				XDoc.Element("MAIN").Add(FoundNode);
			}
			else
				FoundNode.RemoveNodes();
			
			foreach (DataClass i in _Data)
			{
				XElement data = new XElement("LOG", i.Text);
				data.Add(new XAttribute("ID", i.ID));
				if (i.IsVisible != null)
					data.Add(new XAttribute("IsVisible", i.IsVisible));
				else
					data.Add(new XAttribute("IsVisible", "True"));
				data.Add(new XAttribute("User", i.User));
				data.Add(new XAttribute("Time", i.Time));
				FoundNode.Add(data);
			}
		}
		
		public void Load(XDocument TicketData)
		{
			// Loads from XML to DataGrid List
			// Need to call save to update XML Data
			
			dynamic TicketData_Nodes = TicketData.Element("MAIN").Elements("TicketLog");
			_Data = new List<DataClass>();
			
			// Test if ID Element Exists.
			// Adds the Attribute to the DataList
			foreach (XElement n in TicketData_Nodes)
				if (n.Attribute("ID").Value == ID.ToString())
					foreach (XElement i in n.Elements("LOG")) 
						Add(i.Attribute("ID").Value, i.Attribute("User").Value, i.Attribute("Time").Value, i.Attribute("IsVisible").Value, i.Value);


			// Refresh the Elements on Screen
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
		}
		public string ExportToString()
		{
			string result = "";
			foreach (DataClass i in _Data)
				if (i.IsVisible == "True")
					result = result + string.Format("   {0}. {1} {2} UTC -  {3}\r\n", i.ID, i.User, i.Time, i.Text.Replace("\r", "").Replace("\n", "\r\n				"));
			if (result == "")
				return "n.a";
			return result;
		}
		void btn_add_Click(object sender, RoutedEventArgs e)
		{
			LOG.CommitEdit();
			Add("","","","",text.Text);
			ResetGridID();
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
			text.Text = "";
		}
		void text_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			//System.Windows.Input.Key.LeftCtrl || System.Windows.Input.Key.RightCtrl
			if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift) || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift)) {
				if (e.Key.ToString() == "Return") {
					Add("","","","", text.Text);
					LOG.DataContext = _Data;
					LOG.Items.Refresh();
					text.Text = "";
					e.Handled = true;
				}
			}
		}
		void btn_del_Click(object sender, RoutedEventArgs e)
		{	
			LOG.CommitEdit();
			foreach (DataClass i in LOG.SelectedItems) {
				_Data.Remove(i);
			}
			ResetGridID();
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
		}
		void LOG_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			/*
			if (e.Key.ToString() == "Delete") {
				foreach (DataClass i in this.LOG.SelectedItems) {
					this._Data.Remove(i);
				}
				this.ResetGridID();
				this.LOG.DataContext = this._Data;
				this.LOG.Items.Refresh();
				e.Handled = true;
			}
			*/
		}
		void btn_up_Click(object sender, RoutedEventArgs e)
		{
			LOG.CommitEdit();
			//	Check if there is any object at the top of the list.
			foreach (DataClass i in LOG.SelectedItems)
				if ((_Data.IndexOf(i) - 1) <= -1)
					return;
			
			//	Sort SelectedItems by ID
			List<DataClass> d = new List<DataClass>();
			foreach (DataClass i in LOG.SelectedItems)
				d.Add(i);
			List<DataClass> SortedList = d.OrderBy(q => q.ID).ToList();
			
			//	Move the Objects
			foreach (DataClass i in SortedList) {
				int v = (_Data.IndexOf(i) - 1);
				_Data.Remove(i);
				_Data.Insert(v, i);
			}
			
			// Refresh the Elements on Screen
			ResetGridID();
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
		}
		void btn_down_Click(object sender, RoutedEventArgs e)
		{
			LOG.CommitEdit();
			//	Check if there is any object at the Bottom of the list.
			foreach (DataClass i in LOG.SelectedItems)
				if ((_Data.IndexOf(i) + 1) >= _Data.Count())
					return;

			
			//	Sort SelectedItems by ID
			List<DataClass> d = new List<DataClass>();
			foreach (DataClass i in LOG.SelectedItems)
				d.Add(i);
			List<DataClass> SortedList = d.OrderByDescending(q => q.ID).ToList();
			
			//	Move the Objects
			foreach (DataClass i in SortedList) {
				int v = (_Data.IndexOf(i) + 1);
				_Data.Remove(i);
				_Data.Insert(v, i);
			}
			
			// Refresh the Elements on the Screen
			ResetGridID();
			LOG.DataContext = _Data;
			LOG.Items.Refresh();
		}
	}
}