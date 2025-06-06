using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200001A RID: 26
	internal class TransitionType_CriticalDamping : ITransitionType
	{
		// Token: 0x06000161 RID: 353 RVA: 0x000145D0 File Offset: 0x000127D0
		public TransitionType_CriticalDamping(int iTransitionTime)
		{
			bool flag = iTransitionTime <= 0;
			if (flag)
			{
				throw new Exception("Transition time must be greater than zero.");
			}
			this.m_dTransitionTime = (double)iTransitionTime;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00014614 File Offset: 0x00012814
		public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
		{
			double num = (double)iTime / this.m_dTransitionTime;
			dPercentage = (1.0 - Math.Exp(-1.0 * num * 5.0)) / 0.993262053;
			bool flag = num >= 1.0;
			if (flag)
			{
				dPercentage = 1.0;
				bCompleted = true;
			}
			else
			{
				bCompleted = false;
			}
		}

		// Token: 0x0400010D RID: 269
		private double m_dTransitionTime = 0.0;
	}
}
