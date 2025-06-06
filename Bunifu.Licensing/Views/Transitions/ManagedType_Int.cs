using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000010 RID: 16
	internal class ManagedType_Int : IManagedType
	{
		// Token: 0x06000135 RID: 309 RVA: 0x00013834 File Offset: 0x00011A34
		public Type getManagedType()
		{
			return typeof(int);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00013850 File Offset: 0x00011A50
		public object copy(object o)
		{
			int num = (int)o;
			return num;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00013870 File Offset: 0x00011A70
		public object getIntermediateValue(object start, object end, double dPercentage)
		{
			int num = (int)start;
			int num2 = (int)end;
			return Utility.interpolate(num, num2, dPercentage);
		}
	}
}
