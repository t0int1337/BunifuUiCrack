using System;
using System.Collections.Generic;

namespace Bunifu.Licensing.Views.Transitions
{
	// Token: 0x02000014 RID: 20
	internal class TransitionChain
	{
		// Token: 0x0600014D RID: 333 RVA: 0x00014034 File Offset: 0x00012234
		public TransitionChain(params Transition[] transitions)
		{
			foreach (Transition transition in transitions)
			{
				this.m_listTransitions.AddLast(transition);
			}
			this.runNextTransition();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00014080 File Offset: 0x00012280
		private void runNextTransition()
		{
			bool flag = this.m_listTransitions.Count == 0;
			if (!flag)
			{
				Transition value = this.m_listTransitions.First.Value;
				value.TransitionCompletedEvent += this.onTransitionCompleted;
				value.run();
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000140D0 File Offset: 0x000122D0
		private void onTransitionCompleted(object sender, Transition.Args e)
		{
			Transition transition = (Transition)sender;
			transition.TransitionCompletedEvent -= this.onTransitionCompleted;
			this.m_listTransitions.RemoveFirst();
			this.runNextTransition();
		}

		// Token: 0x040000FF RID: 255
		private LinkedList<Transition> m_listTransitions = new LinkedList<Transition>();
	}
}
