using System;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000011 RID: 17
	internal class ManagedType_String : IManagedType
	{
		// Token: 0x06000139 RID: 313 RVA: 0x000138A8 File Offset: 0x00011AA8
		public Type getManagedType()
		{
			return typeof(string);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000138C4 File Offset: 0x00011AC4
		public object copy(object o)
		{
			string text = (string)o;
			return new string(text.ToCharArray());
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000138E8 File Offset: 0x00011AE8
		public object getIntermediateValue(object start, object end, double dPercentage)
		{
			string text = (string)start;
			string text2 = (string)end;
			int length = text.Length;
			int length2 = text2.Length;
			int num = Utility.interpolate(length, length2, dPercentage);
			char[] array = new char[num];
			for (int i = 0; i < num; i++)
			{
				char c = 'a';
				bool flag = i < length;
				if (flag)
				{
					c = text[i];
				}
				char c2 = 'a';
				bool flag2 = i < length2;
				if (flag2)
				{
					c2 = text2[i];
				}
				bool flag3 = c2 == ' ';
				char c3;
				if (flag3)
				{
					c3 = ' ';
				}
				else
				{
					int num2 = Convert.ToInt32(c);
					int num3 = Convert.ToInt32(c2);
					int num4 = Utility.interpolate(num2, num3, dPercentage);
					c3 = Convert.ToChar(num4);
				}
				array[i] = c3;
			}
			return new string(array);
		}
	}
}
