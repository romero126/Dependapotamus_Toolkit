/*
 * Created by SharpDevelop.
 * Date: 8/31/2017
 * Time: 10:28 AM
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

namespace UI.Body.PSHostUI.UX.Settings
{
	/// <summary>
	/// Interaction logic for PSCmdlet.xaml
	/// </summary>
	public partial class PSCmdlet : UserControl
	{

		public event EventHandler EventClose;

		public PSCmdlet()
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

			
			Classes.PSCmdlet _DataContext = (DataContext as Classes.PSCmdlet);
			Dictionary<String, Object> data = new Dictionary<String, Object>();
			data.Add("SCRIPT", _DataContext.SCRIPT);
			data.Add("VISIBLE", _DataContext.VISIBLE);
			data.Add("NAME", _DataContext.NAME);
			data.Add("DESC", _DataContext.DESC);
			data.Add("PSID", _DataContext.PSID);


			bool IsFound = false;
			foreach (Classes.PSCmdlet i in globals.List_PSCmdlet)
				if (i.ID == _DataContext.ID)
					IsFound = true;
					
			if (!IsFound) {
				_DataContext.VISIBLE = 1;
				globals.SQLDB.ExecuteNonQuery(String.Format("INSERT INTO `POWERSHELL_CMDLETS`(`ID`, `PSID`,`POS`,`NAME`,`DESC`,`ICON`,`COMMAND`,`SCRIPT`,`VISIBLE`) VALUES ('{0}',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)", _DataContext.ID));
			}
			globals.SQLDB.Update("POWERSHELL_CMDLETS", data, String.Format("ID='{0}'", _DataContext.ID ));
			
			HideWindow();
		}
		void Delete_Click(object sender, EventArgs e)
		{
			if (DataContext == null) { HideWindow(); return; }

			MessageBoxResult dialog = MessageBox.Show("WARNING:\r\n\r\n    Selecting yess will IRREVERSABLY remove the POWERSHELL COMMANDLET script configuration from the database.\r\n      You will not be able to recoever the data.\r\n\r\nContinue?", "WARNING!!", MessageBoxButton.YesNo);
			if (dialog == MessageBoxResult.No)
				return;
			Classes.PSCmdlet _DataContext = (DataContext as Classes.PSCmdlet);
			globals.SQLDB.ExecuteNonQuery(String.Format("delete from POWERSHELL_CMDLETS where ID='{0}'", _DataContext.ID));
			HideWindow();
		}
		void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible) {
				foreach (UI.Elements.UX.Settings_Page page in Settings.Children)
					page.Visibility = Visibility.Hidden;
				
				if (Settings.Children.Count > 0)
					(Settings.Children[0] as UI.Elements.UX.Settings_Page).Visibility = Visibility.Visible;
			}
		}
	}
}