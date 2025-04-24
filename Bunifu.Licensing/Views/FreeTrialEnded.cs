#if NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Properties;
using Bunifu.Licensing.Views.Transitions;

namespace Bunifu.Licensing.Views
{
	// Token: 0x02000005 RID: 5
	[DebuggerStepThrough]
	internal partial class FreeTrialEnded : Form
	{
		// Token: 0x0600006E RID: 110 RVA: 0x0000787E File Offset: 0x00005A7E
		public FreeTrialEnded()
		{
			this.InitializeComponent();
			this.ImproveTextRendering();
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000078A5 File Offset: 0x00005AA5
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000078AD File Offset: 0x00005AAD
		internal int TrialDays { get; set; } = 14;

		// Token: 0x06000071 RID: 113 RVA: 0x000078B8 File Offset: 0x00005AB8
		public new void Show()
		{
			base.Opacity = 0.0;
			Control control = this.lblTitle;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Your ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TrialDays);
			defaultInterpolatedStringHandler.AppendLiteral("-day free trial has expired");
			control.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			this.lblTitle.Left = (base.Width - this.lblTitle.Width) / 2;
			base.Show();
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(220));
			transition.add(this, "Opacity", 1.0);
			transition.run();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007974 File Offset: 0x00005B74
		public new DialogResult ShowDialog()
		{
			try
			{
				this.Show();
				base.Opacity = 0.0;
				base.Hide();
				Transition.run(this, "Opacity", 1.0, new TransitionType_EaseInEaseOut(220));
			}
			catch (Exception)
			{
			}
			return base.ShowDialog();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000079E8 File Offset: 0x00005BE8
		public DialogResult ShowDialog(int trialDays)
		{
			this.TrialDays = trialDays;
			return this.ShowDialog();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00007A08 File Offset: 0x00005C08
		public new void Close()
		{
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(100));
			transition.add(this, "Opacity", 0.0);
			transition.run();
			transition.TransitionCompletedEvent += delegate
			{
				base.Close();
			};
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00007A58 File Offset: 0x00005C58
		public new void Hide()
		{
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(100));
			transition.add(this, "Opacity", 0.0);
			transition.run();
			transition.TransitionCompletedEvent += delegate
			{
				base.Hide();
			};
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00007AA8 File Offset: 0x00005CA8
		public bool IsTextURL(string text)
		{
			return Uri.IsWellFormedUriString(text, UriKind.Absolute);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00007ACA File Offset: 0x00005CCA
		private void ImproveTextRendering()
		{
			this.btnViewPricingPlans.UseCompatibleTextRendering = false;
			this.btnCancel.UseCompatibleTextRendering = false;
			this.lblMessage.UseCompatibleTextRendering = false;
			this.lblWindowTitle.UseCompatibleTextRendering = false;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00007B01 File Offset: 0x00005D01
		private void ShowVisualMovementCues()
		{
			base.Opacity = 0.8;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00007B14 File Offset: 0x00005D14
		private void HideVisualMovementCues()
		{
			base.Opacity = 1.0;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00007B28 File Offset: 0x00005D28
		private void ApplyShadows()
		{
			bool flag = Shadower.IsAeroEnabled();
			if (flag)
			{
				Shadower.ApplyShadows(this);
				this.bdrBottom.Hide();
				this.bdrRight.Hide();
				this.bdrLeft.Hide();
				this.bdrTop.Hide();
				this.bdrMidLeft.Hide();
				this.bdrMidRight.Hide();
				this.bdrBottomLeft.Hide();
				this.bdrBottomRight.Hide();
			}
			else
			{
				this.bdrBottom.Show();
				this.bdrRight.Show();
				this.bdrLeft.Show();
				this.bdrTop.Show();
				this.bdrMidLeft.Show();
				this.bdrMidRight.Show();
				this.bdrBottomLeft.Show();
				this.bdrBottomRight.Show();
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00007C0C File Offset: 0x00005E0C
		private void InformationBox_Load(object sender, EventArgs e)
		{
			this.ApplyShadows();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00007C16 File Offset: 0x00005E16
		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00007C2C File Offset: 0x00005E2C
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			bool drag = this._drag;
			if (drag)
			{
				this.Cursor = Cursors.SizeAll;
				this.ShowVisualMovementCues();
				base.Top = Cursor.Position.Y - this._mousey;
				base.Left = Cursor.Position.X - this._mousex;
			}
			else
			{
				this.Cursor = Cursors.Default;
				this.HideVisualMovementCues();
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00007CA8 File Offset: 0x00005EA8
		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			this._drag = true;
			this.Cursor = Cursors.Default;
			this._mousex = Cursor.Position.X - base.Left;
			this._mousey = Cursor.Position.Y - base.Top;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00007CFD File Offset: 0x00005EFD
		private void btnViewPricingPlans_Click(object sender, EventArgs e)
		{
			Process.Start("https://bunifuframework.com/pricing");
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00007D0B File Offset: 0x00005F0B
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00007D20 File Offset: 0x00005F20
		private void pbShrink_Click(object sender, EventArgs e)
		{
			bool flag = base.Height == 444;
			if (flag)
			{
				this.pnlFooter.Hide();
				Transition.run(this, "Height", 145, new TransitionType_EaseInEaseOut(180));
			}
			else
			{
				Transition transition = new Transition(new TransitionType_EaseInEaseOut(180));
				transition.TransitionCompletedEvent += delegate
				{
					this.pnlFooter.Show();
				};
				transition.add(this, "Height", 444);
				transition.run();
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00007DB4 File Offset: 0x00005FB4
		private void InformationBox_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Escape;
			if (flag)
			{
				base.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00007DE4 File Offset: 0x00005FE4
		private void lblMessage_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(this.lblMessage.Text);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x04000046 RID: 70
		private bool _drag;

		// Token: 0x04000047 RID: 71
		private int _mousey;

		// Token: 0x04000048 RID: 72
		private int _mousex;
	}
}
