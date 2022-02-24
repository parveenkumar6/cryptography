using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CRYPTOGRAPGY.Encryption
{
    public class EncryptDecrypt
    {
        private string _data;

        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string encrypt()
        {
            byte[] bytData;
            byte[] bytKey;
            byte[] bytEncoded;
            byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
            int iKeyLength;
            int iKeyRemaining;
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream;
            RijndaelManaged rijndaelManaged;

            bytData = Encoding.ASCII.GetBytes(_data.ToCharArray());
            iKeyLength = _key.Length;
            if (iKeyLength >= 32)
            {
                _key = _key.Substring(0, 32);
            }
            else
            {
                iKeyRemaining = 32 - iKeyLength;
                _key = _key + new string('X', iKeyRemaining);
            }

            bytKey = Encoding.ASCII.GetBytes(_key.ToCharArray());

            rijndaelManaged = new RijndaelManaged();
            cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);
            cryptoStream.Write(bytData, 0, bytData.Length);
            try
            {
                cryptoStream.FlushFinalBlock();
            }
            catch { }

            bytEncoded = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(bytEncoded);
        }

        public string decrypt()
        {
            byte[] bytData;
            byte[] bytKey;
            //byte[] bytEncoded;
            byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
            int iKeyLength;
            int iKeyRemaining;

            CryptoStream cryptoStream;
            RijndaelManaged rijndaelManaged;

            //bytData = Encoding.ASCII.GetBytes(_data.ToCharArray());
            bytData = Convert.FromBase64String(_data);

            iKeyLength = _key.Length;
            if (iKeyLength >= 32)
            {
                _key = _key.Substring(0, 32);
            }
            else
            {
                iKeyRemaining = 32 - iKeyLength;
                _key = _key + new string('X', iKeyRemaining);
            }

            bytKey = Encoding.ASCII.GetBytes(_key.ToCharArray());

            byte[] bytTemp = new byte[bytData.Length];
            MemoryStream memoryStream = new MemoryStream(bytData);
            rijndaelManaged = new RijndaelManaged();
            cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Read);
            cryptoStream.Read(bytTemp, 0, bytTemp.Length);

            try
            {
                cryptoStream.FlushFinalBlock();
            }
            catch { }

            //bytEncoded = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.ASCII.GetString(bytTemp);
        }
    }
}
  
