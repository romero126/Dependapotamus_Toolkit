/*
 * Created by SharpDevelop.
 * Date: 08/17/2017
 * Time: 10:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Data;
using System.Collections.Generic;
using System.Data;


namespace UI.Body.PWKeeper
{
	/// <summary>
	/// Description of globals.
	/// </summary>
	public class globals
	{
		public static List<Classes.objDB> LISTobjDB;
		public static List<Classes.objPW> LISTobjPW;
		public static Classes.SQLDB SQLDB;
		public static Classes.PasswordDB PasswordDB = new Classes.PasswordDB();
	}
}
