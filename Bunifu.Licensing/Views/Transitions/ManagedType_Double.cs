using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200000E RID: 14
	internal class ManagedType_Double : IManagedType
	{
		// Token: 0x0600012D RID: 301 RVA: 0x0001374C File Offset: 0x0001194C
		public Type getManagedType()
		{
			return typeof(double);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00013768 File Offset: 0x00011968
		public object copy(object o)
		{
			double num = (double)o;
			return num;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00013788 File Offset: 0x00011988
		public object getIntermediateValue(object start, object end, double dPercentage)
		{
			double num = (double)start;
			double num2 = (double)end;
			return Utility.interpolate(num, num2, dPercentage);
		}
	}
}
