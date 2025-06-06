using System;
using System.Drawing;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x0200000D RID: 13
	internal class ManagedType_Color : IManagedType
	{
		// Token: 0x06000129 RID: 297 RVA: 0x00013650 File Offset: 0x00011850
		public Type getManagedType()
		{
			return typeof(Color);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0001366C File Offset: 0x0001186C
		public object copy(object o)
		{
			Color color = Color.FromArgb(((Color)o).ToArgb());
			return color;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00013698 File Offset: 0x00011898
		public object getIntermediateValue(object start, object end, double dPercentage)
		{
			Color color = (Color)start;
			Color color2 = (Color)end;
			int r = (int)color.R;
			int g = (int)color.G;
			int b = (int)color.B;
			int a = (int)color.A;
			int r2 = (int)color2.R;
			int g2 = (int)color2.G;
			int b2 = (int)color2.B;
			int a2 = (int)color2.A;
			int num = Utility.interpolate(r, r2, dPercentage);
			int num2 = Utility.interpolate(g, g2, dPercentage);
			int num3 = Utility.interpolate(b, b2, dPercentage);
			int num4 = Utility.interpolate(a, a2, dPercentage);
			return Color.FromArgb(num4, num, num2, num3);
		}
	}
}
