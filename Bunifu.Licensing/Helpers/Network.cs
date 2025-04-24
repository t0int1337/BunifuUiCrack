using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Bunifu.Licensing.Helpers
{
	// Token: 0x02000037 RID: 55
	[DebuggerStepThrough]
	internal sealed class Network
	{
		// Token: 0x06000263 RID: 611
		[DllImport("wininet.dll")]
		private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

		// Token: 0x06000264 RID: 612 RVA: 0x00017938 File Offset: 0x00015B38
		public static bool IsAvailable()
		{
			int num;
			return Network.InternetGetConnectedState(out num, 0);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00017954 File Offset: 0x00015B54
		public static bool IsAvailable(long minimumSpeed)
		{
			bool flag = !NetworkInterface.GetIsNetworkAvailable();
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
				{
					bool flag3 = networkInterface.OperationalStatus != OperationalStatus.Up || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Tunnel;
					if (!flag3)
					{
						bool flag4 = networkInterface.Speed < minimumSpeed;
						if (!flag4)
						{
							bool flag5 = networkInterface.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0 || networkInterface.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0;
							if (!flag5)
							{
								bool flag6 = networkInterface.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase);
								if (!flag6)
								{
									return true;
								}
							}
						}
					}
				}
				flag2 = false;
			}
			return flag2;
		}
	}
}
