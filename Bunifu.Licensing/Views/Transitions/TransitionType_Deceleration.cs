using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200001B RID: 27
	internal class TransitionType_Deceleration : ITransitionType
	{
		// Token: 0x06000163 RID: 355 RVA: 0x00014688 File Offset: 0x00012888
		public TransitionType_Deceleration(int iTransitionTime)
		{
			bool flag = iTransitionTime <= 0;
			if (flag)
			{
				throw new Exception("Transition time must be greater than zero.");
			}
			this.m_dTransitionTime = (double)iTransitionTime;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000146CC File Offset: 0x000128CC
		public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
		{
			double num = (double)iTime / this.m_dTransitionTime;
			dPercentage = num * (2.0 - num);
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

		// Token: 0x0400010E RID: 270
		private double m_dTransitionTime = 0.0;
	}
}
