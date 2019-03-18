using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebAPIEnd2EndEncryption.SHA512EncryptionEngine
{
    public static class EncryptionHelper
    {
        const string HashSalt= "2E3BFC35E01856B78CD9FB267FF9Z1C594CEB7BE43050BDF4ABD9B40XN8126C2F6B1972A44293D1A1DB7C6FEF7143D4B1A48DB387C62FAC35D4F67FAB2DF7E94B29C"; 
        public static string EncryptSha512(string value)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(HashSalt);
            HMACSHA512 hMACSHA = new HMACSHA512(keyByte);

            byte[] messageBytes = encoding.GetBytes(value);
            byte[] hashmessage = hMACSHA.ComputeHash(messageBytes);

            return ByteToString(hashmessage);
        }

        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
    }
}