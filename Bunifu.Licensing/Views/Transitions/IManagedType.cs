using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200000B RID: 11
	internal interface IManagedType
	{
		// Token: 0x06000125 RID: 293
		Type getManagedType();

		// Token: 0x06000126 RID: 294
		object copy(object o);

		// Token: 0x06000127 RID: 295
		object getIntermediateValue(object start, object end, double dPercentage);
	}
}
