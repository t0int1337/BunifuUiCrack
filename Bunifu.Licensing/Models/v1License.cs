using System;
using System.ComponentModel;
using System.Diagnostics;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Options;

namespace Bunifu.Licensing.Models
{
	// Token: 0x02000030 RID: 48
	[DebuggerStepThrough]
	internal sealed class v1License : License
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00016675 File Offset: 0x00014875
		// (set) Token: 0x060001EE RID: 494 RVA: 0x0001667D File Offset: 0x0001487D
		public bool IsValid { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00016686 File Offset: 0x00014886
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x0001668E File Offset: 0x0001488E
		public int ID { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00016697 File Offset: 0x00014897
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x0001669F File Offset: 0x0001489F
		public int ClientID { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x000166A8 File Offset: 0x000148A8
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x000166B0 File Offset: 0x000148B0
		public int TotalDays { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x000166B9 File Offset: 0x000148B9
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x000166C1 File Offset: 0x000148C1
		public int Activations { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x000166CA File Offset: 0x000148CA
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x000166D2 File Offset: 0x000148D2
		public string Email { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x000166DB File Offset: 0x000148DB
		public override string LicenseKey
		{
			get
			{
				return this._licenseKey;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001FA RID: 506 RVA: 0x000166E3 File Offset: 0x000148E3
		// (set) Token: 0x060001FB RID: 507 RVA: 0x000166EB File Offset: 0x000148EB
		public string HardwareID { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001FC RID: 508 RVA: 0x000166F4 File Offset: 0x000148F4
		// (set) Token: 0x060001FD RID: 509 RVA: 0x000166FC File Offset: 0x000148FC
		public string ProductName { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00016708 File Offset: 0x00014908
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
				return (int)(this.ExpiryDate - dateTime).TotalDays;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00016744 File Offset: 0x00014944
		// (set) Token: 0x06000200 RID: 512 RVA: 0x0001674C File Offset: 0x0001494C
		public DateTime LastSeen { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00016755 File Offset: 0x00014955
		// (set) Token: 0x06000202 RID: 514 RVA: 0x0001675D File Offset: 0x0001495D
		public DateTime CreatedAt { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00016766 File Offset: 0x00014966
		// (set) Token: 0x06000204 RID: 516 RVA: 0x0001676E File Offset: 0x0001496E
		public DateTime PurchaseDate { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00016778 File Offset: 0x00014978
		public DateTime ExpiryDate
		{
			get
			{
				return this.CreatedAt.AddDays((double)this.TotalDays);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0001679C File Offset: 0x0001499C
		public LicenseTypes Type
		{
			get
			{
				bool flag = this.LicenseKey.StartsWith("FREE");
				LicenseTypes licenseTypes;
				if (flag)
				{
					licenseTypes = LicenseTypes.Trial;
				}
				else
				{
					bool flag2 = this.TotalDays >= 10000;
					if (flag2)
					{
						licenseTypes = LicenseTypes.Enterprise;
					}
					else
					{
						licenseTypes = LicenseTypes.Premium;
					}
				}
				return licenseTypes;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000207 RID: 519 RVA: 0x000167E1 File Offset: 0x000149E1
		// (set) Token: 0x06000208 RID: 520 RVA: 0x000167EC File Offset: 0x000149EC
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

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0001684E File Offset: 0x00014A4E
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00016856 File Offset: 0x00014A56
		public ProductTypes Product { get; set; }

		// Token: 0x0600020B RID: 523 RVA: 0x0001685F File Offset: 0x00014A5F
		public override void Dispose()
		{
		}

		// Token: 0x04000160 RID: 352
		internal string _licenseKey;

		// Token: 0x04000161 RID: 353
		private StatusOptions _status;
	}
}
