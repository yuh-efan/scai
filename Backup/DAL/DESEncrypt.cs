using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;

namespace WZ.Common
{
    public class DESEncrypt_DbHelp
    {
        private static string md5Key = FormsAuthentication.HashPasswordForStoringInConfigFile("s#ug^qs&df5T", "md5").Substring(0, 8);
        private static byte[] byteKey = Encoding.ASCII.GetBytes(md5Key);

        public static string Decrypt(string Text)
        {
            return Decrypt(Text, byteKey);
        }

        public static string Decrypt(string Text, byte[] sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            int num = Text.Length / 2;
            byte[] buffer = new byte[num];
            for (int i = 0; i < num; i++)
            {
                int num3 = Convert.ToInt32(Text.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte)num3;
            }
            provider.Key = sKey;
            provider.IV = sKey;
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            try
            {
                stream2.FlushFinalBlock();
            }
            catch// (Exception exception)
            {
                return string.Empty;
                //throw new Exception(exception.Message + " : " + Text);
            }
            return Encoding.Default.GetString(stream.ToArray());
        }

        public static string Encrypt(string Text)
        {
            return Encrypt(Text, byteKey);
        }

        public static string Encrypt(string Text, byte[] sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(Text);
            provider.Key = sKey;
            provider.IV = sKey;
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            return builder.ToString();
        }
    }

}
