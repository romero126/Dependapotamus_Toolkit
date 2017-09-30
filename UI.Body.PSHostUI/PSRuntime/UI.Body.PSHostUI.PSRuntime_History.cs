/*
 * Created by SharpDevelop.
 * Date: 08/15/2017
 * Time: 13:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UI.Body.PSHostUI
{
	/// <summary>
	/// Description of UserControl1.
	/// </summary>
	public partial class PSRuntime
	{
		private int history_pos;
		public List<string> history;
		public void history_init() {
			history_pos = 0;
			history = new List<string>();
		}
		public void history_add(string data) {
			history.Add(data);
		}
		public void history_gotostart()
		{
			history_pos = 0;
		}
		public void history_gotoend()
		{
			history_pos = history.Count-1;			;
		}	
		public void history_reset() {
			history_pos = -1;
		}
		public string history_getdata()
		{
			return history[history_pos].ToString();
		}
		public int history_getpos()
		{
			return history_pos;
		}
		public int history_count()
		{
			return history.Count;
		}
		public void history_next()
		{
			if (history_pos == -1)
				return;
			
			history_pos += 1;
			if (history_pos > (history.Count-1))
				history_pos = (history.Count - 1);
		}
		public void history_prev()
		{
			if (history_pos == -1)
				history_pos = history.Count;
			
			// Fix a bug
			if (history_pos < 2)
				history_pos = 2;
			
			history_pos -= 1;
			if (history_pos > (history.Count -1))
				return;
		}
	}
}
