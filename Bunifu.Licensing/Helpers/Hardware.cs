using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Bunifu.Licensing.Helpers
{
	// Token: 0x02000034 RID: 52
	[DebuggerStepThrough]
	internal sealed class Hardware
	{
		// Token: 0x0600024E RID: 590 RVA: 0x00017100 File Offset: 0x00015300
		public static string GetUniqueID()
		{
			return Hardware.Value();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00017118 File Offset: 0x00015318
		public static string GetOSSerial()
		{
			ManagementObject managementObject = new ManagementObject("Win32_OperatingSystem=@");
			return (string)managementObject["SerialNumber"];
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00017148 File Offset: 0x00015348
		public static string GetOSName()
		{
			string text = string.Empty;
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						text = managementObject["Caption"].ToString();
					}
				}
			}
			catch (Exception)
			{
			}
			return text;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000171D8 File Offset: 0x000153D8
		public override string ToString()
		{
			return Hardware.Value();
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000171F0 File Offset: 0x000153F0
		private static string Value()
		{
			bool flag = string.IsNullOrEmpty(Hardware._fingerPrint);
			if (flag)
			{
				Hardware._fingerPrint = Hardware.GetHash(string.Concat(new string[]
				{
					"CPU >> ",
					Hardware.CpuId(),
					"\nBIOS >> ",
					Hardware.BiosId(),
					"\nBASE >> ",
					Hardware.BaseId(),
					"\nVIDEO >> ",
					Hardware.VideoId()
				}));
			}
			return Hardware._fingerPrint;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0001726C File Offset: 0x0001546C
		private static string GetHash(string s)
		{
			MD5 md = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			return Hardware.GetHexString(md.ComputeHash(bytes));
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0001729C File Offset: 0x0001549C
		private static string GetHexString(IList<byte> bt)
		{
			string text = string.Empty;
			for (int i = 0; i < bt.Count; i++)
			{
				byte b = bt[i];
				int num = (int)b;
				int num2 = num & 15;
				int num3 = (num >> 4) & 15;
				bool flag = num3 > 9;
				if (flag)
				{
					text += ((char)(num3 - 10 + 65)).ToString(CultureInfo.InvariantCulture);
				}
				else
				{
					text += num3.ToString(CultureInfo.InvariantCulture);
				}
				bool flag2 = num2 > 9;
				if (flag2)
				{
					text += ((char)(num2 - 10 + 65)).ToString(CultureInfo.InvariantCulture);
				}
				else
				{
					text += num2.ToString(CultureInfo.InvariantCulture);
				}
				bool flag3 = i + 1 != bt.Count && (i + 1) % 2 == 0;
				if (flag3)
				{
					text += "-";
				}
			}
			return text;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00017394 File Offset: 0x00015594
		private static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
		{
			string text = "";
			ManagementClass managementClass = new ManagementClass(wmiClass);
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementBaseObject managementBaseObject in instances)
			{
				bool flag = managementBaseObject[wmiMustBeTrue].ToString() != "True";
				if (!flag)
				{
					bool flag2 = text != "";
					if (!flag2)
					{
						try
						{
							text = managementBaseObject[wmiProperty].ToString();
							break;
						}
						catch
						{
						}
					}
				}
			}
			return text;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0001744C File Offset: 0x0001564C
		private static string Identifier(string wmiClass, string wmiProperty)
		{
			string text = "";
			ManagementClass managementClass = new ManagementClass(wmiClass);
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementBaseObject managementBaseObject in instances)
			{
				bool flag = text != "";
				if (!flag)
				{
					try
					{
						bool flag2 = managementBaseObject[wmiProperty] != null;
						if (flag2)
						{
							text = managementBaseObject[wmiProperty].ToString();
						}
						break;
					}
					catch
					{
					}
				}
			}
			return text;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x000174F8 File Offset: 0x000156F8
		private static string CpuId()
		{
			string text = Hardware.Identifier("Win32_Processor", "UniqueId");
			bool flag = text != "";
			string text2;
			if (flag)
			{
				text2 = text;
			}
			else
			{
				text = Hardware.Identifier("Win32_Processor", "ProcessorId");
				bool flag2 = text != "";
				if (flag2)
				{
					text2 = text;
				}
				else
				{
					text = Hardware.Identifier("Win32_Processor", "Name");
					bool flag3 = text == "";
					if (flag3)
					{
						text = Hardware.Identifier("Win32_Processor", "Manufacturer");
					}
					text += Hardware.Identifier("Win32_Processor", "MaxClockSpeed");
					text2 = text;
				}
			}
			return text2;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00017598 File Offset: 0x00015798
		private static string BiosId()
		{
			return string.Concat(new string[]
			{
				Hardware.Identifier("Win32_BIOS", "Manufacturer"),
				Hardware.Identifier("Win32_BIOS", "SMBIOSBIOSVersion"),
				Hardware.Identifier("Win32_BIOS", "IdentificationCode"),
				Hardware.Identifier("Win32_BIOS", "SerialNumber"),
				Hardware.Identifier("Win32_BIOS", "ReleaseDate"),
				Hardware.Identifier("Win32_BIOS", "Version")
			});
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00017624 File Offset: 0x00015824
		private static string DiskId()
		{
			return Hardware.Identifier("Win32_DiskDrive", "Model") + Hardware.Identifier("Win32_DiskDrive", "Manufacturer") + Hardware.Identifier("Win32_DiskDrive", "Signature") + Hardware.Identifier("Win32_DiskDrive", "TotalHeads");
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00017678 File Offset: 0x00015878
		private static string BaseId()
		{
			return Hardware.Identifier("Win32_BaseBoard", "Model") + Hardware.Identifier("Win32_BaseBoard", "Manufacturer") + Hardware.Identifier("Win32_BaseBoard", "Name") + Hardware.Identifier("Win32_BaseBoard", "SerialNumber");
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000176CC File Offset: 0x000158CC
		private static string VideoId()
		{
			return Hardware.Identifier("Win32_VideoController", "DriverVersion") + Hardware.Identifier("Win32_VideoController", "Name");
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00017704 File Offset: 0x00015904
		private static string MacId()
		{
			return Hardware.Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
		}

		// Token: 0x04000187 RID: 391
		private static string _fingerPrint = string.Empty;
	}
}
