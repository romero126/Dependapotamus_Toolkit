/*
 * Created by SharpDevelop.

 * Date: 9/2/2017
 * Time: 3:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using System.IO;

namespace UI.Body.PWKeeper.Classes.Crypto
{
	/// <summary>
	/// Description of AES.
	/// </summary>
	public class AES
	{
        private const int AesBlockSize = 128;
        private const int AesKeySize = 256;
        private const CipherMode CiperMode = CipherMode.CBC;
        
        private string Base64AesKey;
        public void SetAESKey(string base64Encoded256bitAesKey)
        {
        	Base64AesKey = base64Encoded256bitAesKey ?? "tksYWspvM78u0hs/PfUyMJ3G/3P5ditaQYw2i3iqMUI=";
        }
        public AES()
        {
            Base64AesKey = "tksYWspvM78u0hs/PfUyMJ3G/3P5ditaQYw2i3iqMUI=";
        }
        public AES(string base64Encoded256bitAesKey)
        {
            Base64AesKey = base64Encoded256bitAesKey ?? "tksYWspvM78u0hs/PfUyMJ3G/3P5ditaQYw2i3iqMUI=";
        }

        private AesManaged GetAesManaged(byte[] IV = null)
        {
            var aesManaged = new AesManaged();
            aesManaged.Mode = CiperMode;
            aesManaged.Padding = PaddingMode.Zeros;
            aesManaged.BlockSize = AesBlockSize;
            aesManaged.KeySize = AesKeySize;
            if (IV != null)
            {
                aesManaged.IV = IV;
            }
            aesManaged.Key = Convert.FromBase64String(Base64AesKey);
            return aesManaged;
        }

        public string GetString(string encryptedString)
        {
            var bytes = Convert.FromBase64String(encryptedString);
            var IV = bytes.Take(16).ToArray();
            using (var aesManaged = GetAesManaged(IV))
            {
                var decryptor = aesManaged.CreateDecryptor();
                var unencryptedData = decryptor.TransformFinalBlock(bytes, 16, bytes.Length - 16);
                var unencryptedString = Encoding.UTF8.GetString(unencryptedData);
                return unencryptedString.Trim('\0');
            }
        }

        public string SetString(string unencryptedString)
        {
            var bytes = Encoding.UTF8.GetBytes(unencryptedString);
            using (var aesManaged = GetAesManaged())
            {
                var encryptor = aesManaged.CreateEncryptor();
                var encryptedData = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                var fullData = new byte[16 + encryptedData.Length];
                aesManaged.IV.CopyTo(fullData, 0);
                encryptedData.CopyTo(fullData, 16);
                var encryptedString = Convert.ToBase64String(fullData);
                return encryptedString;
            }
        }
	}
}
