using System;
using System.Collections.Generic;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000019 RID: 25
	internal class TransitionType_Bounce : TransitionType_UserDefined
	{
		// Token: 0x06000160 RID: 352 RVA: 0x0001456C File Offset: 0x0001276C
		public TransitionType_Bounce(int iTransitionTime)
		{
			base.setup(new List<TransitionElement>
			{
				new TransitionElement(50.0, 100.0, InterpolationMethod.Accleration),
				new TransitionElement(100.0, 0.0, InterpolationMethod.Deceleration)
			}, iTransitionTime);
		}
	}
}
