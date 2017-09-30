/*
 * Created by SharpDevelop.

 * Date: 9/5/2017
 * Time: 7:45 PM
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

namespace UI.Body.PWKeeper.UX.Control
{
	/// <summary>
	/// Interaction logic for DatabaseList.xaml
	/// </summary>
	public partial class DatabaseList : UserControl
	{
		public DatabaseList()
		{
			InitializeComponent();
		}
		private void Call() {}
		private void Add(Classes.objDB obj) {
			SearchMenu_Item AddButton = new SearchMenu_Item();
			AddButton.Text = obj.TITLE;
			AddButton.TextColor = Brushes.Black;
			AddButton.guid = obj.ID;
			AddButton.HoverBackgroundColor = Brushes.DarkSlateBlue;
			
			AddButton.LeftIconSource = (ImageSource) Resources["IMG_AppbarConsole"];
			AddButton.RightIconSource = (ImageSource) Resources["IMG_AppbarConfig"];
			AddButton.Text_MouseLeftButtonDown += (sender, e) => {
				//UI.Elements.UISettings.SearchMenu_Item me = (UI.Elements.UISettings.SearchMenu_Item)sender;
				//Call(me.guid);
			};
			AddButton.Right_MouseLeftButtonDown += (sender, e) => {
				//UI.Elements.UISettings.SearchMenu_Item me = (UI.Elements.UISettings.SearchMenu_Item)sender;
				//Edit(me.guid);
			};
			Cmdlets_Control.AddItem(AddButton);
			
		}
		private void Create() {
			Edit(Guid.NewGuid().ToString());
		}
		private void Edit(string guid) {}
		
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
		public void Refresh() {
			Clear();
			globals.LISTobjDB = new List<Classes.objDB>();
		
			List<object> QueryResults = globals.SQLDB.GenerateQuery(
				"SELECT * FROM 'PWKeeper_DB'");
			foreach (object i in QueryResults)
			{
				Classes.objDB obj = new Classes.objDB(i);
				globals.LISTobjDB.Add(obj);
				Add(obj);
			}
			
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			globals.SQLDB.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS 'PWKeeper_DB' ( `ID` TEXT UNIQUE, `POS` INTEGER, `TITLE` TEXT, `DESC` TEXT, `SALT` TEXT, `HEADER` TEXT)");
			Refresh();
		}
	}
}
/*
 * 		public event EventHandler EventUpdated;
		public PSRuntime()
		{
			InitializeComponent();
			globals.UX_Controls_PSRuntime = this;
		}
		private void Call(string guid) {
			foreach (UI.Body.PSHostUI.PSRuntime i in globals.List_PSRuntime)
				if (i.ID == guid)
					globals.PSruntime = i;
			
			
			globals.PSruntime.ps_init();
			
			
			if (EventUpdated != null) 
				EventUpdated(this, EventArgs.Empty);
			
			Refresh();
			
			return;
		}


		
		private void Edit(string guid) {
			if (globals.List_PSRuntime == null)
				return;
			
			UI.Body.PSHostUI.PSRuntime _DataContext = null;

			foreach (UI.Body.PSHostUI.PSRuntime i in globals.List_PSRuntime)
				if (i.ID == guid)
					_DataContext = i;

			if (_DataContext == null) {
				_DataContext = new UI.Body.PSHostUI.PSRuntime();
				_DataContext.NAME = "New Object";
				_DataContext.ID = guid;
				_DataContext.VISIBLE = 1;
			}
			globals.UX_Settings_PSRuntime.DataContext = _DataContext;
			globals.UX_Settings_PSRuntime.Visibility = Visibility.Visible;
		}

		

		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			globals.SQLDB.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS 'POWERSHELL' ( `ID` TEXT UNIQUE, `POS` INTEGER, `NAME` TEXT, `DESC` TEXT, `ICON` BLOB, `PATH` TEXT, `COMMAND` TEXT, `SCRIPT` TEXT, `VISIBLE` INTEGER )");
			globals.UX_Settings_PSRuntime.EventClose += (_sender, _e) => { Refresh(); };
			Refresh();
		}
		*/