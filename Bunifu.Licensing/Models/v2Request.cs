using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Bunifu.Licensing.Models
{
	// Token: 0x02000032 RID: 50
	[DebuggerStepThrough]
	internal sealed class v2Request
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00016ACD File Offset: 0x00014CCD
		// (set) Token: 0x06000237 RID: 567 RVA: 0x00016AD5 File Offset: 0x00014CD5
		[JsonProperty(PropertyName = "key")]
		public string LicenseKey { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00016ADE File Offset: 0x00014CDE
		// (set) Token: 0x06000239 RID: 569 RVA: 0x00016AE6 File Offset: 0x00014CE6
		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00016AEF File Offset: 0x00014CEF
		// (set) Token: 0x0600023B RID: 571 RVA: 0x00016AF7 File Offset: 0x00014CF7
		[JsonProperty(PropertyName = "name")]
		public string DeviceName { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00016B00 File Offset: 0x00014D00
		// (set) Token: 0x0600023D RID: 573 RVA: 0x00016B08 File Offset: 0x00014D08
		[JsonProperty(PropertyName = "os")]
		public string OS { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00016B11 File Offset: 0x00014D11
		// (set) Token: 0x0600023F RID: 575 RVA: 0x00016B19 File Offset: 0x00014D19
		[JsonProperty(PropertyName = "hw_id")]
		public string DeviceID { get; set; }

		// Token: 0x06000240 RID: 576 RVA: 0x00016B24 File Offset: 0x00014D24
		public override string ToString()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}
	}
}
