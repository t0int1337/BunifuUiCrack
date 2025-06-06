using System;
using System.Diagnostics;
using Bunifu.Licensing.Options;
using Newtonsoft.Json;

namespace Bunifu.Licensing.Models
{
	// Token: 0x0200002E RID: 46
	[DebuggerStepThrough]
	internal sealed class Product
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x0001652D File Offset: 0x0001472D
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00016535 File Offset: 0x00014735
		[JsonProperty(PropertyName = "id")]
		public int ID { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0001653E File Offset: 0x0001473E
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00016546 File Offset: 0x00014746
		[JsonProperty(PropertyName = "name")]
		public ProductTypes Name { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x0001654F File Offset: 0x0001474F
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00016557 File Offset: 0x00014757
		[JsonProperty(PropertyName = "uuid")]
		public string UUID { get; set; }
	}
}
