using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200000F RID: 15
	internal class ManagedType_Float : IManagedType
	{
		// Token: 0x06000131 RID: 305 RVA: 0x000137C0 File Offset: 0x000119C0
		public Type getManagedType()
		{
			return typeof(float);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000137DC File Offset: 0x000119DC
		public object copy(object o)
		{
			float num = (float)o;
			return num;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000137FC File Offset: 0x000119FC
		public object getIntermediateValue(object start, object end, double dPercentage)
		{
			float num = (float)start;
			float num2 = (float)end;
			return Utility.interpolate(num, num2, dPercentage);
		}
	}
}
