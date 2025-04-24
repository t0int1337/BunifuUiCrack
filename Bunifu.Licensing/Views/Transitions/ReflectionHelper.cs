using System;
using System.Reflection;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000012 RID: 18
	internal static class ReflectionHelper
	{
		// Token: 0x0600013D RID: 317 RVA: 0x000139D4 File Offset: 0x00011BD4
		public static object GetPropValue(this object obj, string propName)
		{
#if NET5_0_OR_GREATER
			string[] array = propName.Split('.', StringSplitOptions.None);
#else
			string[] array = propName.Split(new char[] { '.' });
#endif
			bool flag = array.Length == 1;
			object obj2;
			if (flag)
			{
				obj2 = obj.GetType().GetProperty(propName).GetValue(obj, null);
			}
			else
			{
				foreach (string text in array)
				{
					bool flag2 = obj == null;
					if (flag2)
					{
						return null;
					}
					Type type = obj.GetType();
					PropertyInfo property = type.GetProperty(text);
					bool flag3 = property == null;
					if (flag3)
					{
						return null;
					}
					obj = property.GetValue(obj, null);
				}
				obj2 = obj;
			}
			return obj2;
		}
	}
}
