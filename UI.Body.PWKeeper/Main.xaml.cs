/*
 * Created by SharpDevelop.

 * Date: 9/2/2017
 * Time: 4:44 PM
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

namespace UI.Body.PWKeeper
{
	/// <summary>
	/// Interaction logic for Main.xaml
	/// </summary>
	public partial class Main : UserControl
	{
		public Main()
		{
			InitializeComponent();
			
		}
		void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			globals.SQLDB = new Classes.SQLDB("Settings.SQLite");
		}
	}
}


/*
Database will be


GUID, GROUP, TITLE, NAME, DOMAIN, PASSWORD, URL, EMAIL, COMMENTS,
                            <Enc>,<Enc>  ,



GUID, TITLE, DESC, SALT, HEADER







GUID, GROUP,
	Encrypted
           -----------------
	TITLE encryptedString,
	NAME encryptedString,
	DOMAIN encryptedString,
	PASSWORD encryptedString,
	URL encryptedString,
	EMAIL encryptedString,
	COMMENTS encryptedString

*/
