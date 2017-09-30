/*
 * Created by SharpDevelop.

 * Date: 09/09/2017
 * Time: 20:48
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
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace UI.Elements.UX
{
	/// <summary>
	/// Interaction logic for SetPassword.xaml
	/// </summary>
	public partial class SetPassword : UserControl
	{
		public SetPassword()
		{
			InitializeComponent();
			Pass1.Updated += Event_PasswordChanged;
			Pass2.Updated += Event_PasswordChanged;
		}
		
		public event EventHandler PasswordSaved;
		private int score;
		public string GetPassword {
			get {
				if (score < 3)
					return null;
				if (Pass1.Value == Pass2.Value)
					return Pass1.Value;
				return null;
			}
		}

		public void Event_PasswordChanged(object sender, EventArgs e) {
			score = 1;
			if (Pass1.Value.Length >= 6)
				score++;
			if (Pass1.Value.Length >= 12)
				score++;
			if (Regex.IsMatch(Pass1.Value, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript))
				score++;
			if (Regex.IsMatch(Pass1.Value, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript) )
				score++;
			if (Regex.IsMatch(Pass1.Value, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript))
        		score++;
			if (Pass1.Value.Length < 4)
				score = 1;
			if (Pass1.Value.Length < 1)
				score = 0;

			switch (score)
			{
				case 0:
					ComplexityScore.Content = "Empty";
					ComplexityScoreBG.Background = Brushes.Red;
					break;
				case 1:
					ComplexityScore.Content = "Very Weak";
					ComplexityScoreBG.Background = Brushes.OrangeRed;
					break;
				case 2:
					ComplexityScore.Content = "Weak";
					ComplexityScoreBG.Background = Brushes.Orange;
					break;
				case 3:
					ComplexityScore.Content = "Medium";
					ComplexityScoreBG.Background = Brushes.Yellow;
					break;
				case 4:
					ComplexityScore.Content = "Strong";
					ComplexityScoreBG.Background = Brushes.YellowGreen;
					break;
				case 5:
					ComplexityScore.Content = "Very Strong";
					ComplexityScoreBG.Background = Brushes.Green;
					break;
				
			}
			
			// Password Advisor
			Label.Content = "";
			if (Pass1.Value != Pass2.Value)
				Label.Content = "Passwords must match!";
			if (score < 3)
				Label.Content = "Password too weak!";

			
		}
		void SavePassword_Click(object sender, EventArgs e)
		{
			if (PasswordSaved != null)
				PasswordSaved(this, EventArgs.Empty);
		}
			
	}
}