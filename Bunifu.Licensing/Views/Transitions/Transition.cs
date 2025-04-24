using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000013 RID: 19
	[DebuggerStepThrough]
	internal class Transition
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00013A70 File Offset: 0x00011C70
		static Transition()
		{
			Transition.registerType(new ManagedType_Int());
			Transition.registerType(new ManagedType_Float());
			Transition.registerType(new ManagedType_Double());
			Transition.registerType(new ManagedType_Color());
			Transition.registerType(new ManagedType_String());
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600013F RID: 319 RVA: 0x00013AC0 File Offset: 0x00011CC0
		// (remove) Token: 0x06000140 RID: 320 RVA: 0x00013AF8 File Offset: 0x00011CF8
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<Transition.Args> TransitionCompletedEvent;

		// Token: 0x06000141 RID: 321 RVA: 0x00013B30 File Offset: 0x00011D30
		public static void run(object target, string strPropertyName, object destinationValue, ITransitionType transitionMethod)
		{
			Transition transition = new Transition(transitionMethod);
			transition.add(target, strPropertyName, destinationValue);
			transition.run();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00013B56 File Offset: 0x00011D56
		public static void run(object target, string strPropertyName, object initialValue, object destinationValue, ITransitionType transitionMethod)
		{
			Utility.setValue(target, strPropertyName, initialValue);
			Transition.run(target, strPropertyName, destinationValue, transitionMethod);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00013B70 File Offset: 0x00011D70
		public static void runChain(params Transition[] transitions)
		{
			TransitionChain transitionChain = new TransitionChain(transitions);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00013B85 File Offset: 0x00011D85
		public Transition(ITransitionType transitionMethod)
		{
			this.m_TransitionMethod = transitionMethod;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00013BC0 File Offset: 0x00011DC0
		public void add(object target, string strPropertyName, object destinationValue)
		{
			Type type = target.GetType();
			PropertyInfo property = type.GetProperty(strPropertyName);
			bool flag = property == null;
			if (flag)
			{
				throw new Exception("Object: " + target.ToString() + " does not have the property: " + strPropertyName);
			}
			Type propertyType = property.PropertyType;
			bool flag2 = !Transition.m_mapManagedTypes.ContainsKey(propertyType);
			if (flag2)
			{
				throw new Exception("Transition does not handle properties of type: " + propertyType.ToString());
			}
			bool flag3 = !property.CanRead || !property.CanWrite;
			if (flag3)
			{
				throw new Exception("Property is not both gettable and settable: " + strPropertyName);
			}
			IManagedType managedType = Transition.m_mapManagedTypes[propertyType];
			Transition.TransitionedPropertyInfo transitionedPropertyInfo = new Transition.TransitionedPropertyInfo();
			transitionedPropertyInfo.endValue = destinationValue;
			transitionedPropertyInfo.target = target;
			transitionedPropertyInfo.propertyInfo = property;
			transitionedPropertyInfo.managedType = managedType;
			object @lock = this.m_Lock;
			lock (@lock)
			{
				this.m_listTransitionedProperties.Add(transitionedPropertyInfo);
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00013CDC File Offset: 0x00011EDC
		public void run()
		{
			foreach (Transition.TransitionedPropertyInfo transitionedPropertyInfo in this.m_listTransitionedProperties)
			{
				object value = transitionedPropertyInfo.propertyInfo.GetValue(transitionedPropertyInfo.target, null);
				transitionedPropertyInfo.startValue = transitionedPropertyInfo.managedType.copy(value);
			}
			this.m_Stopwatch.Reset();
			this.m_Stopwatch.Start();
			TransitionManager.getInstance().register(this);
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00013D70 File Offset: 0x00011F70
		internal IList<Transition.TransitionedPropertyInfo> TransitionedProperties
		{
			get
			{
				return this.m_listTransitionedProperties;
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00013D88 File Offset: 0x00011F88
		internal void removeProperty(Transition.TransitionedPropertyInfo info)
		{
			object @lock = this.m_Lock;
			lock (@lock)
			{
				this.m_listTransitionedProperties.Remove(info);
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00013DD4 File Offset: 0x00011FD4
		internal void onTimer()
		{
			int num = (int)this.m_Stopwatch.ElapsedMilliseconds;
			double num2;
			bool flag;
			this.m_TransitionMethod.onTimer(num, out num2, out flag);
			IList<Transition.TransitionedPropertyInfo> list = new List<Transition.TransitionedPropertyInfo>();
			object @lock = this.m_Lock;
			lock (@lock)
			{
				foreach (Transition.TransitionedPropertyInfo transitionedPropertyInfo in this.m_listTransitionedProperties)
				{
					list.Add(transitionedPropertyInfo.copy());
				}
			}
			foreach (Transition.TransitionedPropertyInfo transitionedPropertyInfo2 in list)
			{
				object intermediateValue = transitionedPropertyInfo2.managedType.getIntermediateValue(transitionedPropertyInfo2.startValue, transitionedPropertyInfo2.endValue, num2);
				Transition.PropertyUpdateArgs propertyUpdateArgs = new Transition.PropertyUpdateArgs(transitionedPropertyInfo2.target, transitionedPropertyInfo2.propertyInfo, intermediateValue);
				this.setProperty(this, propertyUpdateArgs);
			}
			bool flag3 = flag;
			if (flag3)
			{
				this.m_Stopwatch.Stop();
				Utility.raiseEvent<Transition.Args>(this.TransitionCompletedEvent, this, new Transition.Args());
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00013F28 File Offset: 0x00012128
		private void setProperty(object sender, Transition.PropertyUpdateArgs args)
		{
			try
			{
				bool flag = this.isDisposed(args.target);
				if (!flag)
				{
					ISynchronizeInvoke synchronizeInvoke = args.target as ISynchronizeInvoke;
					bool flag2 = synchronizeInvoke != null && synchronizeInvoke.InvokeRequired;
					if (flag2)
					{
						IAsyncResult asyncResult = synchronizeInvoke.BeginInvoke(new EventHandler<Transition.PropertyUpdateArgs>(this.setProperty), new object[] { sender, args });
						asyncResult.AsyncWaitHandle.WaitOne(50);
					}
					else
					{
						args.propertyInfo.SetValue(args.target, args.value, null);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00013FCC File Offset: 0x000121CC
		private bool isDisposed(object target)
		{
			Control control = target as Control;
			bool flag = control == null;
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				bool flag3 = control.IsDisposed || control.Disposing;
				flag2 = flag3;
			}
			return flag2;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00014010 File Offset: 0x00012210
		private static void registerType(IManagedType transitionType)
		{
			Type managedType = transitionType.getManagedType();
			Transition.m_mapManagedTypes[managedType] = transitionType;
		}

		// Token: 0x040000FA RID: 250
		private static IDictionary<Type, IManagedType> m_mapManagedTypes = new Dictionary<Type, IManagedType>();

		// Token: 0x040000FB RID: 251
		private ITransitionType m_TransitionMethod = null;

		// Token: 0x040000FC RID: 252
		private IList<Transition.TransitionedPropertyInfo> m_listTransitionedProperties = new List<Transition.TransitionedPropertyInfo>();

		// Token: 0x040000FD RID: 253
		private Stopwatch m_Stopwatch = new Stopwatch();

		// Token: 0x040000FE RID: 254
		private object m_Lock = new object();

		// Token: 0x02000045 RID: 69
		public class Args : EventArgs
		{
		}

		// Token: 0x02000046 RID: 70
		internal class TransitionedPropertyInfo
		{
			// Token: 0x06000282 RID: 642 RVA: 0x00018094 File Offset: 0x00016294
			public Transition.TransitionedPropertyInfo copy()
			{
				return new Transition.TransitionedPropertyInfo
				{
					startValue = this.startValue,
					endValue = this.endValue,
					target = this.target,
					propertyInfo = this.propertyInfo,
					managedType = this.managedType
				};
			}

			// Token: 0x040001B4 RID: 436
			public object startValue;

			// Token: 0x040001B5 RID: 437
			public object endValue;

			// Token: 0x040001B6 RID: 438
			public object target;

			// Token: 0x040001B7 RID: 439
			public PropertyInfo propertyInfo;

			// Token: 0x040001B8 RID: 440
			public IManagedType managedType;
		}

		// Token: 0x02000047 RID: 71
		private class PropertyUpdateArgs : EventArgs
		{
			// Token: 0x06000284 RID: 644 RVA: 0x000180F2 File Offset: 0x000162F2
			public PropertyUpdateArgs(object t, PropertyInfo pi, object v)
			{
				this.target = t;
				this.propertyInfo = pi;
				this.value = v;
			}

			// Token: 0x040001B9 RID: 441
			public object target;

			// Token: 0x040001BA RID: 442
			public PropertyInfo propertyInfo;

			// Token: 0x040001BB RID: 443
			public object value;
		}
	}
}
