using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DataEncrypterDecrypter;

namespace DemoManufacturing.DataAccess
{
    public class ConnectionStringHelper
    {

        public static string GetConnectionString() {
            var connString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            var connectionString = CryptoEngine.Decrypt(connString);

            return connectionString;
        }
    }

}

namespace DataEncrypterDecrypter
{
    public class CryptoEngine
    {
        private static string GetKey()
        {
            var macName = "test1";// Environment.MachineName;

            var length = macName.Length;

            if (macName.Length < 8)
            {
                for (int i = 0; i <= (8 - length); i++)
                {
                    macName += "0";
                }
            }
            var key = "DF(*&@55" + macName.Substring(macName.Length - 8, 8);
            return key;
        }

        public static string Decrypt(string input)
        {
            string key = GetKey();
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}


