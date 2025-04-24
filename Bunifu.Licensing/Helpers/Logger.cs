#if NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Bunifu.Licensing.Options;

namespace Bunifu.Licensing.Helpers
{
	// Token: 0x02000036 RID: 54
	[DebuggerStepThrough]
	internal static class Logger
	{
		// Token: 0x06000261 RID: 609 RVA: 0x000177C8 File Offset: 0x000159C8
		public static bool Add(string message)
		{
			bool flag2;
			try
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
				defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
				defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(LicenseValidator.Product);
				defaultInterpolatedStringHandler.AppendLiteral("\\Log.txt");
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				Registry.Licensing.CreateDirectoryIfNoneExists(LicenseValidator.Product.ToString());
				bool flag = !File.Exists(text);
				if (flag)
				{
					File.WriteAllText(text, string.Empty);
				}
				using (StreamWriter streamWriter = File.AppendText(text))
				{
					streamWriter.WriteLine("[" + DateTime.Now.ToString("dd/MM/yy hh:mm:ss") + "] " + message);
				}
				flag2 = true;
			}
			catch (Exception)
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000178B0 File Offset: 0x00015AB0
		public static bool Clear()
		{
			bool flag;
			try
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
				defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
				defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(LicenseValidator.Product);
				defaultInterpolatedStringHandler.AppendLiteral("\\Log.txt");
				string text = defaultInterpolatedStringHandler.ToStringAndClear();
				Registry.Licensing.CreateDirectoryIfNoneExists(LicenseValidator.Product.ToString());
				File.WriteAllText(text, string.Empty);
				flag = true;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}
	}
}
