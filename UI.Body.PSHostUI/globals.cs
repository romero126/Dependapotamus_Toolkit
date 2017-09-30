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
using System.Data.SQLite;


namespace UI.Body.PSHostUI
	
{
	/// <summary>
	/// Description of globals.
	/// </summary>
	public static class globals
	{
		//public static List<object> _obj;
		//public string str {get; set; }
		//public List<object> SQL_COMMANDS;
		public static string gstring = "pew pew";
		public static Classes.PSConsole PSruntime;
		
		
		public static Main PSHostUI_Main;
		public static Body PSHostUI_Control_Body;
		public static Toolbar PSHostUI_Control_Toolbar;
		
		//public static ItemConfig PSHostUI_Control_ItemConfig;
		public static UX.Settings.PSRuntime PSHostUI_Control_ItemConfig;
		
		//public static SQL_Settings SQL_DB;
		//public static UI.Body.PSHostUI.Classes.SQLDB SQL_DB;
		/*
		 Class_SQLDB
		 Class_PSRuntime
		 Class_PSCmdlet
		 UI_Main
		 UI_Body
		 UI_Toolbar_Main
		 UI_Toolbar_PSRuntime
		 UI_Toolbar_Cmdlet
		 UI_Config_PSRuntime
		 UI_Config_Main
		*/
		#region Lists
		public static List<Classes.PSCmdlet> List_PSCmdlet = new List<Classes.PSCmdlet>();
		public static List<Classes.PSConsole> List_PSRuntime;
		
		#endregion
		
		public static UI.Body.PSHostUI.Classes.SQLDB SQLDB;
		
		
		public static UX.Settings.PSCmdlet UX_Settings_PSCmdlet;
		public static UX.Settings.PSRuntime UX_Settings_PSRuntime;
		
		public static UX.Controls.PSCmdlet UX_Controls_PSCmdlet;
		public static UX.Controls.PSRuntime UX_Controls_PSRuntime;
		
		
	}
}
