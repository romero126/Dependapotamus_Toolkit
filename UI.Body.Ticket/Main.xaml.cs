/*
 * Created by SharpDevelop.
 * Date: 07/30/2017
 * Time: 17:28
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

//using System.Windows.Forms;

namespace UI.Body.Ticket
{
	/// <summary>
	/// Interaction logic for Main.xaml
	/// </summary>
	public partial class Main : UserControl
	{
		public string XDocFileName { get; set; }
		public XDocument XDoc { get; set; }
		
		public Main()
		{
			InitializeComponent();
			New();
		}
		public void New()
		{
			XDoc = new XDocument();
			XDoc.Add(new XElement("MAIN"));
			
			XDocFileName = null;
			TechInfo.Clear();
			Logs1.Clear();
			Logs2.Clear();
			Logs3.Clear();
			Logs4.Clear();
			Logs5.Clear();
			Note.Clear();
		}
		public void Load()
		{

			System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
			dialog.Filter = "SDE Files|*.XLOG";
			dialog.Title = "Open a File";
			dialog.InitialDirectory = @".\SaveFiles\";
			//Show the Dialog
			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (dialog.FileName == "") {
					return;
				}
				XDocFileName = dialog.FileName;
				XDoc = XDocument.Load(dialog.FileName);
				TechInfo.Load(XDoc);
				Logs1.Load(XDoc);
				Logs2.Load(XDoc);
				Logs3.Load(XDoc);
				Logs4.Load(XDoc);
				Logs5.Load(XDoc);
				Note.Load(XDoc);
			}
		}
		
		public void Save()
		{
			if (XDocFileName == null)
			{
				System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
				dialog.Filter = "SDE Files|*.XLOG";
				dialog.Title = "Open a File";
				dialog.InitialDirectory = @".\SaveFiles\";
				dialog.RestoreDirectory = true;
				
				if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					XDocFileName = dialog.FileName;
			}
			if (XDocFileName == null || XDocFileName == "")
			{
				XDocFileName = null;
				return;
			}
			
			try {
				TechInfo.Save(XDoc);	
				Logs1.Save(XDoc);
				Logs2.Save(XDoc);
				Logs3.Save(XDoc);
				Logs4.Save(XDoc);
				Logs5.Save(XDoc);
				Note.Save(XDoc);
				XDoc.Save(XDocFileName);
			}
			catch {
				MessageBox.Show("Error: Unable to save file is this file already being edited?");
				XDocFileName = null;
			}
		}
		public string ExportToString()
		{
			// The Super Dirty way to build this out
			//string  = "TECHNICAL INFORMATION,PROBABLE CAUSE,NEXT STEPS,STEPS TAKEN,SUPPORTING DATA,REPRODUCIBLE DATA";
			//
			//v.Split(',');
			//Enumerable.Zip();
			string result = "";
			result = result + "TECHNICAL INFORMATION\r\n";
			result = result + "-----------------------------------------------------------------\r\n";
			result = result + TechInfo.ExportToString();
			result = result + "\r\n\r\n\r\n";
			result = result + "PROBABLE CAUSE\r\n";
			result = result + "-----------------------------------------------------------------\r\n";
			result = result + Logs1.ExportToString();
			result = result + "\r\n\r\n\r\n";
			result = result + "NEXT STEPS\r\n";
			result = result + "-----------------------------------------------------------------\r\n";
			result = result + Logs2.ExportToString();
			result = result + "\r\n\r\n\r\n";
			result = result + "STEPS TAKEN\r\n";
			result = result + "-----------------------------------------------------------------\r\n";
			result = result + Logs3.ExportToString();
			result = result + "\r\n\r\n\r\n";
			result = result + "SUPPORTING DATA\r\n";
			result = result + "-----------------------------------------------------------------\r\n";
			result = result + Logs4.ExportToString();
			result = result + "\r\n\r\n\r\n";
			result = result + "REPRODUCIBLE DATA\r\n";
			result = result + "-----------------------------------------------------------------\r\n";
			result = result + Logs5.ExportToString();
			return result;
		}

		void ToolBar_MouseEnter(object sender, MouseEventArgs e)
		{
			//(sender as Grid).Background = Brushes.DarkBlue;
			foreach (var v in (sender as Grid).Children)
				if (v.GetType() == typeof(Border))
					(v as Border).BorderBrush = Brushes.LightSlateGray;
		}
		void ToolBar_MouseLeave(object sender, MouseEventArgs e)
		{
			//(sender as Grid).Background = Brushes.Black;
			foreach (var v in (sender as Grid).Children)
				if (v.GetType() == typeof(Border))
					(v as Border).BorderBrush = Brushes.DarkSlateBlue;
			
		}
		void ToolBar_MouseDown_New(object sender, MouseEventArgs e)
		{
			New();
		}
		void ToolBar_MouseDown_Save(object sender, MouseEventArgs e)
		{
			Save();
		}
		void ToolBar_MouseDown_Load(object sender, MouseEventArgs e)
		{
			Load();
		}
		void ToolBar_MouseDown_Clipboard(object sender, MouseEventArgs e)
		{
			Clipboard.SetText(ExportToString());
		}
	}
}