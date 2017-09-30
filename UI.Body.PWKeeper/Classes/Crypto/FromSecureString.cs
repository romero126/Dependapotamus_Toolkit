/*
 * Created by SharpDevelop.

 * Date: 9/2/2017
 * Time: 3:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UI.Body.PWKeeper.Classes.Crypto
{
	/// <summary>
	/// Description of FromSecureString.
	/// </summary>
	public class FromSecureString
	{
		public static implicit operator FromSecureString(string EncryptedString)
    	{
    	    // While not technically a requirement; see below why this is done.
    	    if (EncryptedString == null)
    	        return null;
    	    return "ResultOf-FromSecureString";
    	}
	}
}
