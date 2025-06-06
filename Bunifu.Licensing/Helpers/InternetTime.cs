using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace Bunifu.Licensing.Helpers
{
	// Token: 0x02000035 RID: 53
	[DebuggerStepThrough]
	internal sealed class InternetTime
	{
		// Token: 0x0600025F RID: 607 RVA: 0x00017740 File Offset: 0x00015940
		public static DateTime GetDateTime()
		{
			DateTime dateTime;
			try
			{
				using (WebResponse response = WebRequest.Create("http://www.google.com").GetResponse())
				{
					dateTime = DateTime.ParseExact(response.Headers["date"], "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
				}
			}
			catch (WebException)
			{
				dateTime = DateTime.Now;
			}
			return dateTime;
		}
	}
}
