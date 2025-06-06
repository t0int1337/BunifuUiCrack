using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000018 RID: 24
	internal class TransitionType_Acceleration : ITransitionType
	{
		// Token: 0x0600015E RID: 350 RVA: 0x000144E0 File Offset: 0x000126E0
		public TransitionType_Acceleration(int iTransitionTime)
		{
			bool flag = iTransitionTime <= 0;
			if (flag)
			{
				throw new Exception("Transition time must be greater than zero.");
			}
			this.m_dTransitionTime = (double)iTransitionTime;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00014524 File Offset: 0x00012724
		public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
		{
			double num = (double)iTime / this.m_dTransitionTime;
			dPercentage = num * num;
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

		// Token: 0x0400010C RID: 268
		private double m_dTransitionTime = 0.0;
	}
}
