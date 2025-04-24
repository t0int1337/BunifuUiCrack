using System;
using System.ComponentModel;
using System.Reflection;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000021 RID: 33
	internal class Utility
	{
		// Token: 0x06000170 RID: 368 RVA: 0x00014BBC File Offset: 0x00012DBC
		public static object getValue(object target, string strPropertyName)
		{
			Type type = target.GetType();
			PropertyInfo property = type.GetProperty(strPropertyName);
			bool flag = property == null;
			if (flag)
			{
				throw new Exception("Object: " + target.ToString() + " does not have the property: " + strPropertyName);
			}
			return property.GetValue(target, null);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00014C10 File Offset: 0x00012E10
		public static void setValue(object target, string strPropertyName, object value)
		{
			Type type = target.GetType();
			PropertyInfo property = type.GetProperty(strPropertyName);
			bool flag = property == null;
			if (flag)
			{
				throw new Exception("Object: " + target.ToString() + " does not have the property: " + strPropertyName);
			}
			property.SetValue(target, value, null);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00014C60 File Offset: 0x00012E60
		public static double interpolate(double d1, double d2, double dPercentage)
		{
			double num = d2 - d1;
			double num2 = num * dPercentage;
			return d1 + num2;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00014C80 File Offset: 0x00012E80
		public static int interpolate(int i1, int i2, double dPercentage)
		{
			return (int)Utility.interpolate((double)i1, (double)i2, dPercentage);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00014CA0 File Offset: 0x00012EA0
		public static float interpolate(float f1, float f2, double dPercentage)
		{
			return (float)Utility.interpolate((double)f1, (double)f2, dPercentage);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00014CC0 File Offset: 0x00012EC0
		public static double convertLinearToEaseInEaseOut(double dElapsed)
		{
			double num = ((dElapsed > 0.5) ? 0.5 : dElapsed);
			double num2 = ((dElapsed > 0.5) ? (dElapsed - 0.5) : 0.0);
			return 2.0 * num * num + 2.0 * num2 * (1.0 - num2);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00014D38 File Offset: 0x00012F38
		public static double convertLinearToAcceleration(double dElapsed)
		{
			return dElapsed * dElapsed;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00014D50 File Offset: 0x00012F50
		public static double convertLinearToDeceleration(double dElapsed)
		{
			return dElapsed * (2.0 - dElapsed);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00014D70 File Offset: 0x00012F70
		public static void raiseEvent<T>(EventHandler<T> theEvent, object sender, T args) where T : EventArgs
		{
			bool flag = theEvent == null;
			if (!flag)
			{
				foreach (EventHandler<T> eventHandler in theEvent.GetInvocationList())
				{
					try
					{
						ISynchronizeInvoke synchronizeInvoke = eventHandler.Target as ISynchronizeInvoke;
						bool flag2 = synchronizeInvoke == null || !synchronizeInvoke.InvokeRequired;
						if (flag2)
						{
							eventHandler(sender, args);
						}
						else
						{
							synchronizeInvoke.BeginInvoke(eventHandler, new object[] { sender, args });
						}
					}
					catch (Exception)
					{
					}
				}
			}
		}
	}
}
