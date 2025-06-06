using System;
using System.Diagnostics;

namespace Bunifu.Licensing.Models
{
	// Token: 0x0200002C RID: 44
	[DebuggerStepThrough]
	internal sealed class Client
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00016422 File Offset: 0x00014622
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x0001642A File Offset: 0x0001462A
		public bool Blocked { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00016433 File Offset: 0x00014633
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x0001643B File Offset: 0x0001463B
		public bool IsTeamAdmin { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00016444 File Offset: 0x00014644
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x0001644C File Offset: 0x0001464C
		public int ID { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00016455 File Offset: 0x00014655
		// (set) Token: 0x060001BA RID: 442 RVA: 0x0001645D File Offset: 0x0001465D
		public int TeamID { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00016466 File Offset: 0x00014666
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0001646E File Offset: 0x0001466E
		public int WPUserID { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00016477 File Offset: 0x00014677
		// (set) Token: 0x060001BE RID: 446 RVA: 0x0001647F File Offset: 0x0001467F
		public string Name { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00016488 File Offset: 0x00014688
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00016490 File Offset: 0x00014690
		public string Email { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00016499 File Offset: 0x00014699
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x000164A1 File Offset: 0x000146A1
		public DateTime CreatedAt { get; set; } = DateTime.MinValue;
	}
}
