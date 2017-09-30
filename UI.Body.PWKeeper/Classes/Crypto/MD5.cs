/*
 * Created by SharpDevelop.

 * Date: 9/2/2017
 * Time: 4:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.IO;

namespace UI.Body.PWKeeper.Classes.Crypto
{
	/// <summary>
	/// Description of MD5.
	/// </summary>
	public class MD5Hash
	{
		static public String ConvertToMD5(string plaintext, int salt) {
        	using (var md5 = MD5.Create())
        	{
        		
        		byte[] byteArray = Encoding.UTF8.GetBytes(plaintext);
        		byte[] hash = md5.ComputeHash(byteArray);
        		
        		string sb = "";
        		foreach (byte i in hash) {
        			sb += i.ToString("x2");
        		}
        		if (salt == 1)
        			return sb;

        		salt--;
    			return ConvertToMD5(sb, salt);
 
        	}
		}
	}
}
