using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200001C RID: 28
	internal class TransitionType_EaseInEaseOut : ITransitionType
	{
		// Token: 0x06000165 RID: 357 RVA: 0x00014720 File Offset: 0x00012920
		public TransitionType_EaseInEaseOut(int iTransitionTime)
		{
			bool flag = iTransitionTime <= 0;
			if (flag)
			{
				throw new Exception("Transition time must be greater than zero.");
			}
			this.m_dTransitionTime = (double)iTransitionTime;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00014764 File Offset: 0x00012964
		public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
		{
			double num = (double)iTime / this.m_dTransitionTime;
			dPercentage = Utility.convertLinearToEaseInEaseOut(num);
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

		// Token: 0x0400010F RID: 271
		private double m_dTransitionTime = 0.0;
	}
}
