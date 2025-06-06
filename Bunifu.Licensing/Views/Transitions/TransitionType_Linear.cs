using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200001E RID: 30
	internal class TransitionType_Linear : ITransitionType
	{
		// Token: 0x06000168 RID: 360 RVA: 0x00014844 File Offset: 0x00012A44
		public TransitionType_Linear(int iTransitionTime)
		{
			bool flag = iTransitionTime <= 0;
			if (flag)
			{
				throw new Exception("Transition time must be greater than zero.");
			}
			this.m_dTransitionTime = (double)iTransitionTime;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00014888 File Offset: 0x00012A88
		public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
		{
			dPercentage = (double)iTime / this.m_dTransitionTime;
			bool flag = dPercentage >= 1.0;
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

		// Token: 0x04000110 RID: 272
		private double m_dTransitionTime = 0.0;
	}
}
