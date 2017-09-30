/*
 * Created by SharpDevelop.

 * Date: 08/31/2017
 * Time: 20:52
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
		
		public string EncKey;
		public Main()
		{
			InitializeComponent();
			Password.KeyUp += (sender, e) => {
				PWHash.Content = Classes.Crypto.MD5Hash.ConvertToMD5(Password.Text, 5);
			};
		}
		void Button_Click(object sender, RoutedEventArgs e)
		{
			Classes.Crypto.AES v = new Classes.Crypto.AES(PWHash.Content.ToString());
			OutputText.Text = v.SetString(InputText.Text);
		}
		void Decrypt_Click(object sender, RoutedEventArgs e)
		{
			Classes.Crypto.AES v = new Classes.Crypto.AES(PWHash.Content.ToString());
			DecryptText.Text = v.GetString(OutputText.Text);
		}

	}
}