using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Bunifu.Licensing.Models
{
	// Token: 0x0200002F RID: 47
	[DebuggerStepThrough]
	internal sealed class Record : License
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00016569 File Offset: 0x00014769
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x00016571 File Offset: 0x00014771
		public bool IsValid { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0001657A File Offset: 0x0001477A
		// (set) Token: 0x060001DB RID: 475 RVA: 0x00016582 File Offset: 0x00014782
		public int ID { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0001658B File Offset: 0x0001478B
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00016593 File Offset: 0x00014793
		public string UUID { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001DE RID: 478 RVA: 0x0001659C File Offset: 0x0001479C
		public override string LicenseKey
		{
			get
			{
				return this._licenseKey;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001DF RID: 479 RVA: 0x000165A4 File Offset: 0x000147A4
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x000165AC File Offset: 0x000147AC
		public DateTime? CreatedAt { get; set; } = new DateTime?(DateTime.MinValue);

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x000165B5 File Offset: 0x000147B5
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x000165BD File Offset: 0x000147BD
		public DateTime? LastSeen { get; set; } = new DateTime?(DateTime.MinValue);

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x000165C6 File Offset: 0x000147C6
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x000165CE File Offset: 0x000147CE
		public DateTime? RemovedAt { get; internal set; } = new DateTime?(DateTime.MinValue);

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x000165D7 File Offset: 0x000147D7
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x000165DF File Offset: 0x000147DF
		public Client Client { get; set; } = new Client();

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x000165E8 File Offset: 0x000147E8
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x000165F0 File Offset: 0x000147F0
		public Device Device { get; set; } = new Device();

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000165F9 File Offset: 0x000147F9
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00016601 File Offset: 0x00014801
		public v2License License { get; set; } = new v2License();

		// Token: 0x060001EB RID: 491 RVA: 0x0001660A File Offset: 0x0001480A
		public override void Dispose()
		{
		}

		// Token: 0x04000156 RID: 342
		internal string _licenseKey;
	}
}
