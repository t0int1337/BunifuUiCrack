using System;
using System.Collections.Generic;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200001D RID: 29
	internal class TransitionType_Flash : TransitionType_UserDefined
	{
		// Token: 0x06000167 RID: 359 RVA: 0x000147B0 File Offset: 0x000129B0
		public TransitionType_Flash(int iNumberOfFlashes, int iFlashTime)
		{
			double num = 100.0 / (double)iNumberOfFlashes;
			IList<TransitionElement> list = new List<TransitionElement>();
			for (int i = 0; i < iNumberOfFlashes; i++)
			{
				double num2 = (double)i * num;
				double num3 = num2 + num;
				double num4 = (num2 + num3) / 2.0;
				list.Add(new TransitionElement(num4, 100.0, InterpolationMethod.EaseInEaseOut));
				list.Add(new TransitionElement(num3, 0.0, InterpolationMethod.EaseInEaseOut));
			}
			base.setup(list, iFlashTime * iNumberOfFlashes);
		}
	}
}
