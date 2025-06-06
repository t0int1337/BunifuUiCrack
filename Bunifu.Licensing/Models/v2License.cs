using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Options;

namespace Bunifu.Licensing.Models
{
	// Token: 0x02000031 RID: 49
	[DebuggerStepThrough]
	internal sealed class v2License : License
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0001686B File Offset: 0x00014A6B
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00016873 File Offset: 0x00014A73
		public int ID { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0001687C File Offset: 0x00014A7C
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00016884 File Offset: 0x00014A84
		public int? LicenseKeyID { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0001688D File Offset: 0x00014A8D
		// (set) Token: 0x06000212 RID: 530 RVA: 0x00016895 File Offset: 0x00014A95
		public int? BundleID { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0001689E File Offset: 0x00014A9E
		// (set) Token: 0x06000214 RID: 532 RVA: 0x000168A6 File Offset: 0x00014AA6
		public int? TeamID { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000215 RID: 533 RVA: 0x000168AF File Offset: 0x00014AAF
		// (set) Token: 0x06000216 RID: 534 RVA: 0x000168B7 File Offset: 0x00014AB7
		public int? UserID { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000217 RID: 535 RVA: 0x000168C0 File Offset: 0x00014AC0
		// (set) Token: 0x06000218 RID: 536 RVA: 0x000168C8 File Offset: 0x00014AC8
		public int PurchaseID { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000219 RID: 537 RVA: 0x000168D1 File Offset: 0x00014AD1
		// (set) Token: 0x0600021A RID: 538 RVA: 0x000168D9 File Offset: 0x00014AD9
		public int TotalDays { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600021B RID: 539 RVA: 0x000168E2 File Offset: 0x00014AE2
		// (set) Token: 0x0600021C RID: 540 RVA: 0x000168EA File Offset: 0x00014AEA
		public int MaxDevices { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600021D RID: 541 RVA: 0x000168F3 File Offset: 0x00014AF3
		// (set) Token: 0x0600021E RID: 542 RVA: 0x000168FB File Offset: 0x00014AFB
		public int Activations { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00016904 File Offset: 0x00014B04
		// (set) Token: 0x06000220 RID: 544 RVA: 0x0001690C File Offset: 0x00014B0C
		public int RemainingDevices { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00016918 File Offset: 0x00014B18
		public int RemainingDays
		{
			get
			{
				DateTime dateTime = DateTime.Now;
				bool flag = Network.IsAvailable();
				if (flag)
				{
					dateTime = InternetTime.GetDateTime();
				}
				return (int)(this.ExpiryDate - dateTime).TotalDays + 1;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000222 RID: 546 RVA: 0x00016956 File Offset: 0x00014B56
		// (set) Token: 0x06000223 RID: 547 RVA: 0x0001695E File Offset: 0x00014B5E
		public string UUID { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00016967 File Offset: 0x00014B67
		// (set) Token: 0x06000225 RID: 549 RVA: 0x0001696F File Offset: 0x00014B6F
		public string Plan { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00016978 File Offset: 0x00014B78
		// (set) Token: 0x06000227 RID: 551 RVA: 0x00016980 File Offset: 0x00014B80
		public string RenewalURL { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00016989 File Offset: 0x00014B89
		public override string LicenseKey
		{
			get
			{
				return this._licenseKey;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00016991 File Offset: 0x00014B91
		// (set) Token: 0x0600022A RID: 554 RVA: 0x00016999 File Offset: 0x00014B99
		public DateTime CreatedAt { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600022B RID: 555 RVA: 0x000169A4 File Offset: 0x00014BA4
		public DateTime ExpiryDate
		{
			get
			{
				return this.CreatedAt.AddDays((double)this.TotalDays);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600022C RID: 556 RVA: 0x000169C6 File Offset: 0x00014BC6
		// (set) Token: 0x0600022D RID: 557 RVA: 0x000169CE File Offset: 0x00014BCE
		public ProductTypes Product { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600022E RID: 558 RVA: 0x000169D7 File Offset: 0x00014BD7
		// (set) Token: 0x0600022F RID: 559 RVA: 0x000169DF File Offset: 0x00014BDF
		public List<Product> ProductsLicensed { get; set; } = new List<Product>();

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000230 RID: 560 RVA: 0x000169E8 File Offset: 0x00014BE8
		// (set) Token: 0x06000231 RID: 561 RVA: 0x000169F0 File Offset: 0x00014BF0
		public LicenseTypes Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
				bool flag = this.TotalDays > 14 && this.TotalDays <= 365;
				if (flag)
				{
					this._type = LicenseTypes.Premium;
				}
				else
				{
					bool flag2 = this.TotalDays >= 1000000;
					if (flag2)
					{
						this._type = LicenseTypes.Enterprise;
					}
				}
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00016A4A File Offset: 0x00014C4A
		// (set) Token: 0x06000233 RID: 563 RVA: 0x00016A54 File Offset: 0x00014C54
		public StatusOptions Status
		{
			get
			{
				return this._status;
			}
			set
			{
				DateTime dateTime = DateTime.Now;
				bool flag = Network.IsAvailable();
				if (flag)
				{
					dateTime = InternetTime.GetDateTime();
				}
				int num = dateTime.Date.CompareTo(this.ExpiryDate.Date);
				bool flag2 = num == 0 || num == 1;
				if (flag2)
				{
					this._status = StatusOptions.Expired;
				}
				else
				{
					this._status = value;
				}
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00016AB6 File Offset: 0x00014CB6
		public override void Dispose()
		{
		}

		// Token: 0x0400016E RID: 366
		private int _remainingDays;

		// Token: 0x0400016F RID: 367
		internal string _licenseKey;

		// Token: 0x04000170 RID: 368
		private LicenseTypes _type;

		// Token: 0x04000171 RID: 369
		private StatusOptions _status;
	}
}
