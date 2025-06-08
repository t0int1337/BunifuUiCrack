using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace BunifuLicenseGenerator
{
    [DebuggerStepThrough]
    public class Hardware
    {
        public static string GetUniqueID()
        {
            return Hardware.Value();
        }

     
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

        public override string ToString()
        {
            return Hardware.Value();
        }

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

        private static string GetHash( string s )
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            return Hardware.GetHexString(md.ComputeHash(bytes));
        }

        private static string GetHexString( IList<byte> bt )
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

        private static string Identifier( string wmiClass, string wmiProperty, string wmiMustBeTrue )
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

        private static string Identifier( string wmiClass, string wmiProperty )
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

        private static string DiskId()
        {
            return Hardware.Identifier("Win32_DiskDrive", "Model") + Hardware.Identifier("Win32_DiskDrive", "Manufacturer") + Hardware.Identifier("Win32_DiskDrive", "Signature") + Hardware.Identifier("Win32_DiskDrive", "TotalHeads");
        }

        private static string BaseId()
        {
            return Hardware.Identifier("Win32_BaseBoard", "Model") + Hardware.Identifier("Win32_BaseBoard", "Manufacturer") + Hardware.Identifier("Win32_BaseBoard", "Name") + Hardware.Identifier("Win32_BaseBoard", "SerialNumber");
        }

        private static string VideoId()
        {
            return Hardware.Identifier("Win32_VideoController", "DriverVersion") + Hardware.Identifier("Win32_VideoController", "Name");
        }

        private static string MacId()
        {
            return Hardware.Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }

        public Hardware()
        {
        }

        // Note: this type is marked as 'beforefieldinit'.
        static Hardware()
        {
        }

        private static string _fingerPrint = string.Empty;
    }
}
