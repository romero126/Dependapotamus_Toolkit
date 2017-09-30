/*
 * Created by SharpDevelop.

 * Date: 08/31/2017
 * Time: 15:28
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
using UI.Elements.UX;

namespace UI.Body.PSHostUI.UX.Controls
{
	/// <summary>
	/// Interaction logic for PSRuntime.xaml
	/// </summary>
	public partial class PSRuntime : UserControl
	{
		public event EventHandler EventUpdated;
		public PSRuntime()
		{
			InitializeComponent();
			globals.UX_Controls_PSRuntime = this;
		}
		private void Call(string guid) {
			foreach (Classes.PSConsole i in globals.List_PSRuntime)
				if (i.ID == guid)
					globals.PSruntime = i;
			
			globals.PSruntime.ps_init();
			
			if (EventUpdated != null) 
				EventUpdated(this, EventArgs.Empty);
			
			Refresh();
			
			return;
		}
		private void Add(Classes.PSConsole obj) {
			
			SearchMenu_Item AddButton = new SearchMenu_Item();
			AddButton.Text = obj.NAME;
			AddButton.TextColor = Brushes.White;
			AddButton.guid = obj.ID;
			AddButton.HoverBackgroundColor = Brushes.DarkSlateBlue;
			AddButton.LeftIconSource = (ImageSource) Resources["IMG_AppbarConsole"];
			AddButton.RightIconSource = (ImageSource) Resources["IMG_AppbarConfig"];
			AddButton.Text_MouseLeftButtonDown += (sender, e) => {
				SearchMenu_Item me = (SearchMenu_Item)sender;
				Call(me.guid);
			};
			AddButton.Right_MouseLeftButtonDown += (sender, e) => {
				SearchMenu_Item me = (SearchMenu_Item)sender;
				Edit(me.guid);
			};
			Cmdlets_Control.AddItem(AddButton);
		}
		private void Create()
		{
			Edit(Guid.NewGuid().ToString());
		}
		
		private void Edit(string guid) {
			if (globals.List_PSRuntime == null)
				return;
			
			Classes.PSConsole _DataContext = null;

			foreach (Classes.PSConsole i in globals.List_PSRuntime)
				if (i.ID == guid)
					_DataContext = i;

			if (_DataContext == null) {
				_DataContext = new Classes.PSConsole();
				_DataContext.NAME = "New Object";
				_DataContext.ID = guid;
				_DataContext.VISIBLE = 1;
			}
			globals.UX_Settings_PSRuntime.DataContext = _DataContext;
			globals.UX_Settings_PSRuntime.Visibility = Visibility.Visible;
		}
		public void Clear() {
			
			Cmdlets_Control.ClearItems();
			
			SearchMenu_Item AddButton = new SearchMenu_Item();
			AddButton.BackgroundColor = Brushes.Black;
			AddButton.Text = "ADD";
			AddButton.TextColor = Brushes.White;
			AddButton.AlwaysVisible = true;
			AddButton.LeftIconSource = (ImageSource) Resources["IMG_AppbarAdd"];
			AddButton.HoverBackgroundColor = Brushes.DarkSlateBlue;
			AddButton.Text_MouseLeftButtonDown += (sender, e) => {
				Create();
			};
			Cmdlets_Control.AddItem(AddButton);
		}
		
		public void Refresh()
		{
			
			if (globals.List_PSRuntime == null)
			{
				globals.List_PSRuntime = new List<Classes.PSConsole>();
				List<object> QueryResults = globals.SQLDB.GenerateQuery(
					"SELECT * FROM 'POWERSHELL' " +
						"ORDER BY " +
							"CASE " +
								"WHEN POS IS NULL THEN 1 " +
								"WHEN POS = '' THEN 1 " +
								"ELSE 0 " +
							"END, POS");
				foreach (object i in QueryResults)
				{
					Classes.PSConsole obj = new Classes.PSConsole(i);
					globals.List_PSRuntime.Add(obj);
				}
			}
			
			if (!globals.List_PSRuntime.Contains(globals.PSruntime))
				foreach (Classes.PSConsole i in globals.List_PSRuntime)
					if (i.POS == 1)
						Call(i.ID);
			
			Clear();
			foreach (Classes.PSConsole i in globals.List_PSRuntime)
			{
				Add(i);
			}
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			globals.SQLDB.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS 'POWERSHELL' ( `ID` TEXT UNIQUE, `POS` INTEGER, `NAME` TEXT, `DESC` TEXT, `ICON` BLOB, `PATH` TEXT, `COMMAND` TEXT, `SCRIPT` TEXT, `VISIBLE` INTEGER )");
			globals.UX_Settings_PSRuntime.EventClose += (_sender, _e) => { Refresh(); };
			Refresh();
		}
	}
}