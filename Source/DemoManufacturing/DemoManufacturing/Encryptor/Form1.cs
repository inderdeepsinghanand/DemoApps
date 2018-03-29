using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Encryptor.DataEncrypterDecrypter;

namespace Encryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (plaintext.Text != string.Empty)
            {


                var key = GetKey();
                MessageBox.Show(key);
                //Here key is of 128 bit  
                //Key should be either of 128 bit or of 192 bit  
                label1.Text = CryptoEngine.Encrypt(plaintext.Text, key);

                 
    if(label1.Text != string.Empty)  
    {  
        //Key shpuld be same for encryption and decryption  
        label2.Text = CryptoEngine.Decrypt(label1.Text, key);  
    } 


                
            }  
        }

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
    }




    namespace DataEncrypterDecrypter
    {
        public class CryptoEngine
        {
            public static string Encrypt(string input, string key)
            {
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            public static string Decrypt(string input, string key)
            {
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
}