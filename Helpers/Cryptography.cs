using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BunifuLicenseGenerator
{
    public class Cryptography
    {
        private const string SHA_KEY = "011c3c04-09f0-42ea-8932-f413a9d67a6b";

        private static RijndaelManaged NewRijndaelManaged( string salt )
        {
            bool flag = salt == null;
            if (flag)
            {
                throw new ArgumentNullException("salt");
            }
            byte[] bytes = Encoding.ASCII.GetBytes(salt);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("011c3c04-09f0-42ea-8932-f413a9d67a6b", bytes);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
            return rijndaelManaged;
        }
        public static string Encrypt( string plainText )
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes(SHA_KEY);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("011c3c04-09f0-42ea-8932-f413a9d67a6b", saltBytes);

            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);

            ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string Decrypt( string cipherText )
        {
            if (!IsBase64String(cipherText))
                throw new Exception("The cipherText input parameter is not base64 encoded");

            byte[] saltBytes = Encoding.ASCII.GetBytes(SHA_KEY);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("011c3c04-09f0-42ea-8932-f413a9d67a6b", saltBytes);

            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);

            ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
            byte[] encryptedBytes = Convert.FromBase64String(cipherText);

            using (MemoryStream ms = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        public static bool IsBase64String( string base64String )
        {
            base64String = base64String.Trim();
            return base64String.Length % 4 == 0 && Regex.IsMatch(base64String, "^[a-zA-Z0-9\\+/]*={0,3}$", RegexOptions.None);
        }
        public Cryptography()
        {
        }
    }
}
