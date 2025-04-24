using System;
using System.Collections.Generic;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200001F RID: 31
	internal class TransitionType_ThrowAndCatch : TransitionType_UserDefined
	{
		// Token: 0x0600016A RID: 362 RVA: 0x000148CC File Offset: 0x00012ACC
		public TransitionType_ThrowAndCatch(int iTransitionTime)
		{
			base.setup(new List<TransitionElement>
			{
				new TransitionElement(50.0, 100.0, InterpolationMethod.Deceleration),
				new TransitionElement(100.0, 0.0, InterpolationMethod.Accleration)
			}, iTransitionTime);
		}
	}
}
