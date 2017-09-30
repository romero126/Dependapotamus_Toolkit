/*
 * Created by SharpDevelop.

 * Date: 9/5/2017
 * Time: 10:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace UI.Body.PWKeeper.Classes
{
	/// <summary>
	/// Description of PasswordDB.
	/// </summary>
	public class PasswordDB
	{
		Classes.SQLDB DB;
		//private string BaseAESKey;
		//private List<object> DBKeys;
		public List<objDB> List_objDB;
		public List<objPW> List_objPW;
		
		public PasswordDB()
		{
			DB = new Classes.SQLDB("Settings.SQLite");
			DB.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS 'PWKeeper_DB' ( `ID` TEXT UNIQUE, `POS` INTEGER, `TITLE` TEXT, `DESC` TEXT, `SALT` TEXT, `HEADER` TEXT)");
		}
		
	}
}
