﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Admin_API.Utility
{
    public static class EncryptDecrypt
    {
        private static TripleDESCryptoServiceProvider m_des = new TripleDESCryptoServiceProvider();
        //Define the string Handler
        private static UTF8Encoding m_utf8 = new UTF8Encoding();
        //Define the local Propertirs Array
        private static byte[] m_key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 13, 15, 16, 17, 18, 19, 20, 21, 22, 24, 23 };
        private static byte[] m_iv = { 8, 7, 6, 5, 4, 3, 2, 1 };

        private static byte[] Encypt(byte[] input)
        {
            return Transform(input, m_des.CreateEncryptor(m_key, m_iv));
        }

        private static byte[] Decrypt(byte[] input)
        {
            return Transform(input, m_des.CreateDecryptor(m_key, m_iv));
        }

        public static string Encypt(string text)
        {
            byte[] input = m_utf8.GetBytes(text);
            byte[] output = Transform(input, m_des.CreateEncryptor(m_key, m_iv));
            return Convert.ToBase64String(output);
        }

        public static string Decrypt(string text)
        {
            byte[] input = Convert.FromBase64String(text);
            byte[] output = Transform(input, m_des.CreateDecryptor(m_key, m_iv));
            return m_utf8.GetString(output);
        }

        private static byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
        {
            //Create the Neccessary streams
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, cryptoTransform, CryptoStreamMode.Write);
            //transform the bytes as requested
            cryptoStream.Write(input, 0, input.Length);
            cryptoStream.FlushFinalBlock();
            //Reasd the memory stream and convert it to byte array
            memStream.Position = 0;
            byte[] result = new byte[Convert.ToInt32(memStream.Length - 1) + 1];
            memStream.Read(result, 0, Convert.ToInt32(result.Length));
            memStream.Close();
            cryptoStream.Close();
            return result;
        }

        public static string Encrypt_Code(string password)
        {
            string pwdstring = string.Empty;
            byte[] pwd_encode = new byte[password.Length];
            pwd_encode = Encoding.UTF8.GetBytes(password);
            pwdstring = Convert.ToBase64String(pwd_encode);
            return pwdstring;
        }
        public static string Decrypt_Code(string encryptpassword)
        {
            string pwdstring = string.Empty;
            UTF8Encoding encode_pwd = new UTF8Encoding();
            Decoder Decode = encode_pwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpassword);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            pwdstring = new String(decoded_char);
            return pwdstring;
        }
    }
}
