using System;
using System.Collections.Generic;
using System.Timers;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000017 RID: 23
	internal class TransitionManager
	{
		// Token: 0x06000157 RID: 343 RVA: 0x00014160 File Offset: 0x00012360
		public static TransitionManager getInstance()
		{
			bool flag = TransitionManager.m_Instance == null;
			if (flag)
			{
				TransitionManager.m_Instance = new TransitionManager();
			}
			return TransitionManager.m_Instance;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00014190 File Offset: 0x00012390
		public void register(Transition transition)
		{
			object @lock = this.m_Lock;
			lock (@lock)
			{
				this.removeDuplicates(transition);
				this.m_Transitions[transition] = true;
				transition.TransitionCompletedEvent += this.onTransitionCompleted;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000141F8 File Offset: 0x000123F8
		private void removeDuplicates(Transition transition)
		{
			foreach (KeyValuePair<Transition, bool> keyValuePair in this.m_Transitions)
			{
				this.removeDuplicates(transition, keyValuePair.Key);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00014254 File Offset: 0x00012454
		private void removeDuplicates(Transition newTransition, Transition oldTransition)
		{
			IList<Transition.TransitionedPropertyInfo> transitionedProperties = newTransition.TransitionedProperties;
			IList<Transition.TransitionedPropertyInfo> transitionedProperties2 = oldTransition.TransitionedProperties;
			for (int i = transitionedProperties2.Count - 1; i >= 0; i--)
			{
				Transition.TransitionedPropertyInfo transitionedPropertyInfo = transitionedProperties2[i];
				foreach (Transition.TransitionedPropertyInfo transitionedPropertyInfo2 in transitionedProperties)
				{
					bool flag = transitionedPropertyInfo.target == transitionedPropertyInfo2.target && transitionedPropertyInfo.propertyInfo == transitionedPropertyInfo2.propertyInfo;
					if (flag)
					{
						oldTransition.removeProperty(transitionedPropertyInfo);
					}
				}
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00014308 File Offset: 0x00012508
		private TransitionManager()
		{
			this.m_Timer = new Timer(15.0);
			this.m_Timer.Elapsed += this.onTimerElapsed;
			this.m_Timer.Enabled = true;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00014374 File Offset: 0x00012574
		private void onTimerElapsed(object sender, ElapsedEventArgs e)
		{
			bool flag = this.m_Timer == null;
			if (!flag)
			{
				this.m_Timer.Enabled = false;
				object @lock = this.m_Lock;
				IList<Transition> list;
				lock (@lock)
				{
					list = new List<Transition>();
					foreach (KeyValuePair<Transition, bool> keyValuePair in this.m_Transitions)
					{
						list.Add(keyValuePair.Key);
					}
				}
				foreach (Transition transition in list)
				{
					transition.onTimer();
				}
				this.m_Timer.Enabled = true;
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00014478 File Offset: 0x00012678
		private void onTransitionCompleted(object sender, Transition.Args e)
		{
			Transition transition = (Transition)sender;
			transition.TransitionCompletedEvent -= this.onTransitionCompleted;
			object @lock = this.m_Lock;
			lock (@lock)
			{
				this.m_Transitions.Remove(transition);
			}
		}

		// Token: 0x04000108 RID: 264
		private static TransitionManager m_Instance;

		// Token: 0x04000109 RID: 265
		private IDictionary<Transition, bool> m_Transitions = new Dictionary<Transition, bool>();

		// Token: 0x0400010A RID: 266
		private Timer m_Timer = null;

		// Token: 0x0400010B RID: 267
		private object m_Lock = new object();
	}
}
