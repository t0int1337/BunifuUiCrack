using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Bunifu.Licensing.Properties;

namespace Bunifu.Licensing.Helpers
{
	// Token: 0x02000033 RID: 51
	[DebuggerStepThrough]
	internal sealed class Cryptography
	{
		// Token: 0x06000242 RID: 578 RVA: 0x00016B48 File Offset: 0x00014D48
		public static string Encrypt(string text)
		{
			string sha = Resources.SHA;
			bool flag = string.IsNullOrWhiteSpace(text);
			if (flag)
			{
				throw new ArgumentNullException("text");
			}
			RijndaelManaged rijndaelManaged = Cryptography.NewRijndaelManaged(sha);
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			MemoryStream memoryStream = new MemoryStream();
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
			{
				using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
				{
					streamWriter.Write(text);
				}
			}
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00016BFC File Offset: 0x00014DFC
		public static string Encrypt2(string text)
		{
			string sha = Resources.SHA2;
			bool flag = string.IsNullOrWhiteSpace(text);
			if (flag)
			{
				throw new ArgumentNullException("text");
			}
			RijndaelManaged rijndaelManaged = Cryptography.NewRijndaelManaged(sha);
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			MemoryStream memoryStream = new MemoryStream();
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
			{
				using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
				{
					streamWriter.Write(text);
				}
			}
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00016CB0 File Offset: 0x00014EB0
		public static string Decrypt(string cipherText)
		{
			string sha = Resources.SHA;
			bool flag = string.IsNullOrEmpty(cipherText);
			if (flag)
			{
				throw new ArgumentNullException("cipherText");
			}
			bool flag2 = !Cryptography.IsBase64String(cipherText);
			if (flag2)
			{
				throw new Exception("The cipherText input parameter is not base64 encoded");
			}
			RijndaelManaged rijndaelManaged = Cryptography.NewRijndaelManaged(sha);
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			byte[] array = Convert.FromBase64String(cipherText);
			string text;
			using (MemoryStream memoryStream = new MemoryStream(array))
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
				{
					using (StreamReader streamReader = new StreamReader(cryptoStream))
					{
						text = streamReader.ReadToEnd();
					}
				}
			}
			return text;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00016DA0 File Offset: 0x00014FA0
		public static string Decrypt2(string cipherText)
		{
			string sha = Resources.SHA2;
			bool flag = string.IsNullOrEmpty(cipherText);
			if (flag)
			{
				throw new ArgumentNullException("cipherText");
			}
			bool flag2 = !Cryptography.IsBase64String(cipherText);
			if (flag2)
			{
				throw new Exception("The cipherText input parameter is not base64 encoded");
			}
			RijndaelManaged rijndaelManaged = Cryptography.NewRijndaelManaged(sha);
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			byte[] array = Convert.FromBase64String(cipherText);
			string text;
			using (MemoryStream memoryStream = new MemoryStream(array))
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
				{
					using (StreamReader streamReader = new StreamReader(cryptoStream))
					{
						text = streamReader.ReadToEnd();
					}
				}
			}
			return text;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00016E90 File Offset: 0x00015090
		public static string Base64Encode(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00016EB4 File Offset: 0x000150B4
		public static string Base64Decode(string base64EncodedData)
		{
			byte[] array = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(array);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00016ED8 File Offset: 0x000150D8
		public static bool IsBase64String(string base64String)
		{
			base64String = base64String.Trim();
			return base64String.Length % 4 == 0 && Regex.IsMatch(base64String, "^[a-zA-Z0-9\\+/]*={0,3}$", RegexOptions.None);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00016F0C File Offset: 0x0001510C
		public static string ComputeMD5(string rawData)
		{
			bool flag = rawData == null || rawData.Length == 0;
			string text;
			if (flag)
			{
				text = string.Empty;
			}
			else
			{
				MD5 md = new MD5CryptoServiceProvider();
				byte[] bytes = Encoding.Default.GetBytes(rawData);
				byte[] array = md.ComputeHash(bytes);
				text = BitConverter.ToString(array).Replace("-", "").ToLowerInvariant();
			}
			return text;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00016F74 File Offset: 0x00015174
		public static string ComputeSHA1(string rawData)
		{
			string text;
			using (SHA1Managed sha1Managed = new SHA1Managed())
			{
				byte[] array = sha1Managed.ComputeHash(Encoding.UTF8.GetBytes(rawData));
				StringBuilder stringBuilder = new StringBuilder(array.Length * 2);
				foreach (byte b in array)
				{
					stringBuilder.Append(b.ToString("x2"));
				}
				text = stringBuilder.ToString();
			}
			return text;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00017000 File Offset: 0x00015200
		public static string ComputeSHA256(string rawData)
		{
			string text;
			using (SHA256 sha = SHA256.Create())
			{
				byte[] array = sha.ComputeHash(Encoding.UTF8.GetBytes(rawData));
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				text = stringBuilder.ToString();
			}
			return text;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00017084 File Offset: 0x00015284
		private static RijndaelManaged NewRijndaelManaged(string salt)
		{
			bool flag = salt == null;
			if (flag)
			{
				throw new ArgumentNullException("salt");
			}
			byte[] bytes = Encoding.ASCII.GetBytes(salt);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Resources.SHA, bytes);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
			rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
			return rijndaelManaged;
		}
	}
}
