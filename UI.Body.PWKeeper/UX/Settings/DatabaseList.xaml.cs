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

namespace UI.Body.PWKeeper.UX.Settings
{
	/// <summary>
	/// Interaction logic for PSRuntime.xaml
	/// </summary>
	public partial class DatabaseList : UserControl
	{
		public event EventHandler EventClose;


		public DatabaseList()
		{
			InitializeComponent();
		}		
		void Settings_EventClose(object sender, EventArgs e)
		{
			HideWindow();

		}
		private void HideWindow()
		{
			if (EventClose != null)
				EventClose(this, EventArgs.Empty);
			Visibility = Visibility.Hidden;			
		}
		void Save_Click(object sender, EventArgs e)
		{
			if (DataContext == null) { HideWindow(); return; }

			/*
			UI.Body.PSHostUI.PSRuntime _DataContext = (DataContext as UI.Body.PSHostUI.PSRuntime);
			Dictionary<String, Object> data = new Dictionary<String, Object>();
			data.Add("SCRIPT", _DataContext.SCRIPT);
			data.Add("VISIBLE", _DataContext.VISIBLE);
			data.Add("NAME", _DataContext.NAME);
			data.Add("DESC", _DataContext.DESC);
			data.Add("PATH", _DataContext.PATH);

			bool IsFound = false;
			foreach (UI.Body.PSHostUI.PSRuntime i in globals.List_PSRuntime)
				if (i.ID == _DataContext.ID)
					IsFound = true;
					
			if (!IsFound) {
				_DataContext.VISIBLE = 1;
				globals.SQLDB.ExecuteNonQuery(String.Format("INSERT INTO `POWERSHELL`(`ID`,`POS`,`NAME`,`DESC`,`ICON`,`PATH`,`COMMAND`,`SCRIPT`,`VISIBLE`) VALUES ('{0}',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)", _DataContext.ID));
			}
			globals.SQLDB.Update("POWERSHELL", data, String.Format("ID='{0}'", _DataContext.ID ));
			
			//TODO: Remove this and figure out a better fix.
			if (!IsFound)
				globals.List_PSRuntime.Add(_DataContext);
			*/
			HideWindow();
		}
		void Delete_Click(object sender, EventArgs e)
		{
			if (DataContext == null) { HideWindow(); return; }
			/*
			MessageBoxResult dialog = MessageBox.Show("WARNING:\r\n\r\n    Selecting yess will IRREVERSABLY remove the POWERSHELL script configuration and sub Commandlets from the database.\r\n      You will not be able to recoever the data.\r\n\r\nContinue?", "WARNING!!", MessageBoxButton.YesNo);
			if (dialog == MessageBoxResult.No)
				return;
			UI.Body.PSHostUI.PSRuntime _DataContext = (DataContext as UI.Body.PSHostUI.PSRuntime);
			
			globals.SQLDB.ExecuteNonQuery(String.Format("delete from POWERSHELL where ID='{0}'", _DataContext.ID));
			globals.SQLDB.ExecuteNonQuery(String.Format("delete from POWERSHELL_CMDLETS where PSID='{0}'", _DataContext.ID));
			
			//TODO: Remove this and figure out a better fix.
			globals.List_PSRuntime.Remove(_DataContext);
			*/
			HideWindow();
		}
		void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			/*
			if (this.Visibility == Visibility.Visible) {
				foreach (UI.Elements.UISettings.Settings_Page page in Settings.Children)
					page.Visibility = Visibility.Hidden;
				
				if (Settings.Children.Count > 0)
					(Settings.Children[0] as UI.Elements.UISettings.Settings_Page).Visibility = Visibility.Visible;
			}
			*/
			
		}
		void SavePassword_Click(object sender, EventArgs e)
		{
			//if (Password1.Value == Password2.Value)
			//	MessageBox.Show("Success " + Password1.Value);
		}
	}
}