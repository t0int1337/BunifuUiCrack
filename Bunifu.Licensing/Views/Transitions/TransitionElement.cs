using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000016 RID: 22
	internal class TransitionElement
	{
		// Token: 0x06000150 RID: 336 RVA: 0x0001410B File Offset: 0x0001230B
		public TransitionElement(double endTime, double endValue, InterpolationMethod interpolationMethod)
		{
			this.EndTime = endTime;
			this.EndValue = endValue;
			this.InterpolationMethod = interpolationMethod;
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0001412D File Offset: 0x0001232D
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00014135 File Offset: 0x00012335
		public double EndTime { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000153 RID: 339 RVA: 0x0001413E File Offset: 0x0001233E
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00014146 File Offset: 0x00012346
		public double EndValue { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000155 RID: 341 RVA: 0x0001414F File Offset: 0x0001234F
		// (set) Token: 0x06000156 RID: 342 RVA: 0x00014157 File Offset: 0x00012357
		public InterpolationMethod InterpolationMethod { get; set; }
	}
}
