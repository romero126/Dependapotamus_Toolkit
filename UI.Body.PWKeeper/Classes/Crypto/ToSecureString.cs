/*
 * Created by SharpDevelop.

 * Date: 9/2/2017
 * Time: 3:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UI.Body.PWKeeper.Classes.Crypto
{
	/// <summary>
	/// Description of ToSecureString.
	/// </summary>
	public class ToSecureString
	{
		public static implicit operator ToSecureString(string EncryptedString)
    	{
    	    // While not technically a requirement; see below why this is done.
    	    if (EncryptedString == null)
    	        return null;
    	    return "ResultOf-ToSecureString";
    	}
	}
}
