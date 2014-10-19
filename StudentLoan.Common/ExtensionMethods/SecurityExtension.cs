using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace StudentLoan.Common
{
    /// <summary>
    /// 加密解密类
    /// </summary>
    public static class SecurityExtension
    {
        /// <summary>
        /// 获取字符串的MD5值
        /// </summary>
        /// <param name="target"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string MD5(this string target, int length = 32)
        {
            if (length == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(target, "MD5").ToLower().Substring(8, 16);
            }
            else   //32位加密 
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(target, "MD5").ToLower();
            }
        }

        /// <summary>
        /// 获取指定文件的MD5值
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string getFilesMD5Hash(this string target)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            FileStream stream = new FileStream(target, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);

            md5.ComputeHash(stream);

            stream.Close();

            byte[] hash = md5.Hash;

            StringBuilder sb = new StringBuilder();

            foreach (byte b in hash)
            {
                sb.Append(string.Format("{0:X2}", b));
            }

            return sb.ToString();
        }




        /// <summary>
        /// DES加密算法
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <param name="sKey">加密码Key</param>
        /// <returns>正确返回加密后的结果，错误返回源字符串</returns>

        public static string ToDESEncrypt(string encryptString, string sKey, CipherMode mode = CipherMode.CBC)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(sKey);
                byte[] keyIV = keyBytes;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);

                DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
                // java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式

                desProvider.Mode = mode;

                MemoryStream memStream = new MemoryStream();
                CryptoStream crypStream = new CryptoStream(memStream, desProvider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);

                crypStream.Write(inputByteArray, 0, inputByteArray.Length);
                crypStream.FlushFinalBlock();
                return Convert.ToBase64String(memStream.ToArray());

            }

            catch
            {
                return encryptString;
            }
        }


        /// <summary>
        /// DES解密算法
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <param name="sKey">加密Key</param>
        /// <returns>正确返回加密后的结果，错误返回源字符串</returns>
        public static string ToDESDecrypt(string decryptString, string sKey, CipherMode mode = CipherMode.CBC)
        {

            byte[] keyBytes = Encoding.UTF8.GetBytes(sKey);
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);

            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

            // java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
            desProvider.Mode = mode;

            MemoryStream memStream = new MemoryStream();

            CryptoStream crypStream = new CryptoStream(memStream, desProvider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);

            crypStream.Write(inputByteArray, 0, inputByteArray.Length);

            crypStream.FlushFinalBlock();

            return Encoding.Default.GetString(memStream.ToArray());

        }


    }

    public static class DESHelper
    {
        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "DTcms");
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========解密========

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "DTcms");
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
    }
}
