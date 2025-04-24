using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200000C RID: 12
	internal interface ITransitionType
	{
		// Token: 0x06000128 RID: 296
		void onTimer(int iTime, out double dPercentage, out bool bCompleted);
	}
}
