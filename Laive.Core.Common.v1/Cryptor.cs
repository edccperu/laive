using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Laive.Core.Common
{
   public class Cryptor
   {

      private Guid _objGUI = new Guid("{F26ED1BE-3225-43A0-AF35-9B4C254CF044}");

      public byte[] GetEncodeBytes(string plainText)
      {
         return Encoding.UTF8.GetBytes(plainText);
      }

      private string GetDecodeBytes(byte[] encodeBytes)
      {
         return Encoding.UTF8.GetString(encodeBytes);
      }

      private byte[] GetMD5EncodeBytes(byte[] encodeBytes)
      {
         MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

         byte[] hashedBytes = md5Hasher.ComputeHash(encodeBytes);

         return hashedBytes;
      }

      public byte[] Encrypt(string plainText)
      {
         return Encrypt(plainText, _objGUI.ToByteArray());
      }

      public byte[] Encrypt(string plainText, byte[] publicKey)
      {

         RijndaelManaged objCrypRij = new RijndaelManaged();

         byte[] bytIV = GetMD5EncodeBytes(publicKey);

         objCrypRij.IV = bytIV;

         PasswordDeriveBytes pdb = new PasswordDeriveBytes(GetDecodeBytes(publicKey), new byte[0]);
         objCrypRij.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);

         MemoryStream msText = new MemoryStream(plainText.Length * 2);
         CryptoStream encStream = new CryptoStream(msText, objCrypRij.CreateEncryptor(), CryptoStreamMode.Write);

         byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
         encStream.Write(plainBytes, 0, plainBytes.Length);
         encStream.FlushFinalBlock();
         byte[] encryptedBytes = new byte[msText.Length];
         msText.Position = 0;
         msText.Read(encryptedBytes, 0, Convert.ToInt32(msText.Length));
         encStream.Close();

         return encryptedBytes;

      }

      public byte[] Decrypt(byte[] encrypted)
      {

         return Decrypt(encrypted, _objGUI.ToByteArray());
      }

      public byte[] Decrypt(byte[] encrypted, byte[] publicKey)
      {

         RijndaelManaged objCrypRij = new RijndaelManaged();

         byte[] bytIV = GetMD5EncodeBytes(publicKey);

         objCrypRij.IV = bytIV;

         PasswordDeriveBytes pdb = new PasswordDeriveBytes(GetDecodeBytes(publicKey), new byte[0]);

         objCrypRij.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);

         byte[] encryptedBytes = encrypted;

         MemoryStream msText = new MemoryStream(encrypted.GetLength(0));

         CryptoStream decStream = new CryptoStream(msText, objCrypRij.CreateDecryptor(), CryptoStreamMode.Write);
         decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
         decStream.FlushFinalBlock();
         byte[] plainBytes = new byte[msText.Length];
         msText.Position = 0;
         msText.Read(plainBytes, 0, Convert.ToInt32(msText.Length));
         decStream.Close();

         return plainBytes;
      }

   }
}
