using System;
using System.Diagnostics;

namespace Bunifu.Licensing.Models
{
	// Token: 0x0200002D RID: 45
	[DebuggerStepThrough]
	internal sealed class Device
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x000164BE File Offset: 0x000146BE
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x000164C6 File Offset: 0x000146C6
		public int ID { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x000164CF File Offset: 0x000146CF
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x000164D7 File Offset: 0x000146D7
		public bool Blocked { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x000164E0 File Offset: 0x000146E0
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x000164E8 File Offset: 0x000146E8
		public string Name { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001CA RID: 458 RVA: 0x000164F1 File Offset: 0x000146F1
		// (set) Token: 0x060001CB RID: 459 RVA: 0x000164F9 File Offset: 0x000146F9
		public string OS { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00016502 File Offset: 0x00014702
		// (set) Token: 0x060001CD RID: 461 RVA: 0x0001650A File Offset: 0x0001470A
		public string HardwareID { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00016513 File Offset: 0x00014713
		// (set) Token: 0x060001CF RID: 463 RVA: 0x0001651B File Offset: 0x0001471B
		public DateTime LastSeen { get; internal set; }
	}
}
