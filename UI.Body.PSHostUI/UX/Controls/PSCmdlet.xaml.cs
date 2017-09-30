/*
 * Created by SharpDevelop.
 * Date: 8/31/2017
 * Time: 11:56 AM
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
	/// Interaction logic for PSCmdlet.xaml
	/// </summary>
	public partial class PSCmdlet : UserControl
	{
		public PSCmdlet()
		{
			InitializeComponent();
			globals.UX_Controls_PSCmdlet = this;
		}
		private void Call(string guid) {
			foreach (Classes.PSCmdlet i in globals.List_PSCmdlet)
				if (i.ID == guid)
					globals.PSruntime.ps_call(i.SCRIPT);
		}
		private void Add(Classes.PSCmdlet obj) {
			
			SearchMenu_Item AddButton = new SearchMenu_Item();
			AddButton.Text = obj.NAME;
			AddButton.TextColor = Brushes.White;
			AddButton.guid = obj.ID;
			AddButton.HoverBackgroundColor = Brushes.SlateBlue;
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
			if (globals.List_PSCmdlet == null)
				return;
			
			Classes.PSCmdlet _DataContext = null;

			foreach (Classes.PSCmdlet i in globals.List_PSCmdlet)
				if (i.ID == guid)
					_DataContext = i;

			if (_DataContext == null) {
				_DataContext = new Classes.PSCmdlet();
				_DataContext.NAME = "New Object";
				_DataContext.ID = guid;
				_DataContext.PSID = globals.PSruntime.ID;
				_DataContext.VISIBLE = 1;
			}
			globals.UX_Settings_PSCmdlet.DataContext = _DataContext;
			globals.UX_Settings_PSCmdlet.Visibility = Visibility.Visible;
		}
		public void Clear() {
			
			Cmdlets_Control.ClearItems();
			
			SearchMenu_Item AddButton = new SearchMenu_Item();
			AddButton.BackgroundColor = Brushes.Black;
			AddButton.Text = "ADD";
			AddButton.TextColor = Brushes.White;
			AddButton.AlwaysVisible = true;
			AddButton.LeftIconSource = (ImageSource) Resources["IMG_AppbarAdd"];
			AddButton.HoverBackgroundColor = Brushes.SlateBlue;
			AddButton.Text_MouseLeftButtonDown += (sender, e) => {
				Create();
			};
			Cmdlets_Control.AddItem(AddButton);
		}
		
		
		public void Refresh()
		{
			Clear();
			List<object> QueryResults = globals.SQLDB.GenerateQuery(string.Format("SELECT * FROM {0} WHERE PSID='{1}' ORDER BY POS", "POWERSHELL_CMDLETS" , globals.PSruntime.ID));
			globals.List_PSCmdlet.Clear();
			
			foreach (object i in QueryResults)
			{
				Classes.PSCmdlet pscmdlet = new Classes.PSCmdlet(i);
				globals.List_PSCmdlet.Add(pscmdlet);
				Add(pscmdlet);
			}
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			globals.SQLDB.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS `POWERSHELL_CMDLETS` ( `ID` TEXT UNIQUE, `PSID` TEXT, `POS` INTEGER, `NAME` TEXT, `DESC` TEXT, `ICON` BLOB, `COMMAND` TEXT, `SCRIPT` TEXT, `VISIBLE` INTEGER )");
			globals.UX_Settings_PSCmdlet.EventClose += (_sender, _e) => { Refresh(); };
			globals.UX_Controls_PSRuntime.EventUpdated += (_sender, _e) => { Refresh(); };
		}
	}
}