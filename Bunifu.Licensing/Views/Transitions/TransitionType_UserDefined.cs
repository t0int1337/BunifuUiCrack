using System;
using System.Collections.Generic;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000020 RID: 32
	internal class TransitionType_UserDefined : ITransitionType
	{
		// Token: 0x0600016B RID: 363 RVA: 0x0001492E File Offset: 0x00012B2E
		public TransitionType_UserDefined()
		{
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00014955 File Offset: 0x00012B55
		public TransitionType_UserDefined(IList<TransitionElement> elements, int iTransitionTime)
		{
			this.setup(elements, iTransitionTime);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00014988 File Offset: 0x00012B88
		public void setup(IList<TransitionElement> elements, int iTransitionTime)
		{
			this.m_Elements = elements;
			this.m_dTransitionTime = (double)iTransitionTime;
			bool flag = elements.Count == 0;
			if (flag)
			{
				throw new Exception("The list of elements passed to the constructor of TransitionType_UserDefined had zero elements. It must have at least one element.");
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000149C0 File Offset: 0x00012BC0
		public void onTimer(int iTime, out double dPercentage, out bool bCompleted)
		{
			double num = (double)iTime / this.m_dTransitionTime;
			double num2;
			double num3;
			double num4;
			double num5;
			InterpolationMethod interpolationMethod;
			this.getElementInfo(num, out num2, out num3, out num4, out num5, out interpolationMethod);
			double num6 = num3 - num2;
			double num7 = num - num2;
			double num8 = num7 / num6;
			double num9;
			switch (interpolationMethod)
			{
			case InterpolationMethod.Linear:
				num9 = num8;
				break;
			case InterpolationMethod.Accleration:
				num9 = Utility.convertLinearToAcceleration(num8);
				break;
			case InterpolationMethod.Deceleration:
				num9 = Utility.convertLinearToDeceleration(num8);
				break;
			case InterpolationMethod.EaseInEaseOut:
				num9 = Utility.convertLinearToEaseInEaseOut(num8);
				break;
			default:
				throw new Exception("Interpolation method not handled: " + interpolationMethod.ToString());
			}
			dPercentage = Utility.interpolate(num4, num5, num9);
			bool flag = (double)iTime >= this.m_dTransitionTime;
			if (flag)
			{
				bCompleted = true;
				dPercentage = num5;
			}
			else
			{
				bCompleted = false;
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00014A90 File Offset: 0x00012C90
		private void getElementInfo(double dTimeFraction, out double dStartTime, out double dEndTime, out double dStartValue, out double dEndValue, out InterpolationMethod eInterpolationMethod)
		{
			int count = this.m_Elements.Count;
			while (this.m_iCurrentElement < count)
			{
				TransitionElement transitionElement = this.m_Elements[this.m_iCurrentElement];
				double num = transitionElement.EndTime / 100.0;
				bool flag = dTimeFraction < num;
				if (flag)
				{
					break;
				}
				this.m_iCurrentElement++;
			}
			bool flag2 = this.m_iCurrentElement == count;
			if (flag2)
			{
				this.m_iCurrentElement = count - 1;
			}
			dStartTime = 0.0;
			dStartValue = 0.0;
			bool flag3 = this.m_iCurrentElement > 0;
			if (flag3)
			{
				TransitionElement transitionElement2 = this.m_Elements[this.m_iCurrentElement - 1];
				dStartTime = transitionElement2.EndTime / 100.0;
				dStartValue = transitionElement2.EndValue / 100.0;
			}
			TransitionElement transitionElement3 = this.m_Elements[this.m_iCurrentElement];
			dEndTime = transitionElement3.EndTime / 100.0;
			dEndValue = transitionElement3.EndValue / 100.0;
			eInterpolationMethod = transitionElement3.InterpolationMethod;
		}

		// Token: 0x04000111 RID: 273
		private IList<TransitionElement> m_Elements = null;

		// Token: 0x04000112 RID: 274
		private double m_dTransitionTime = 0.0;

		// Token: 0x04000113 RID: 275
		private int m_iCurrentElement = 0;
	}
}
