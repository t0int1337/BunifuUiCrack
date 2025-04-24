using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Views.Transitions;

namespace Bunifu.Licensing.Views
{
	// Token: 0x0200000A RID: 10
	[DebuggerStepThrough]
	internal partial class TrialBox : Form
	{
		// Token: 0x0600010B RID: 267 RVA: 0x00012118 File Offset: 0x00010318
		public TrialBox()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00012130 File Offset: 0x00010330
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00012138 File Offset: 0x00010338
		public bool ShowApplyNewLicenseButton
		{
			get
			{
				return this._showApplyNewLicenseButton;
			}
			set
			{
				this._showApplyNewLicenseButton = value;
				if (value)
				{
					this.btnApplyNewLicense.Show();
				}
				else
				{
					this.btnApplyNewLicense.Hide();
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0001216C File Offset: 0x0001036C
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00012174 File Offset: 0x00010374
		public Action OnClickActivatePremium { get; set; }

		// Token: 0x06000110 RID: 272 RVA: 0x00012180 File Offset: 0x00010380
		public new void Show()
		{
			base.Opacity = 0.0;
			base.Show();
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(220));
			transition.add(this, "Opacity", 1.0);
			transition.run();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000121D8 File Offset: 0x000103D8
		public new DialogResult ShowDialog()
		{
			try
			{
				this.Show();
				base.Opacity = 0.0;
				base.StartPosition = FormStartPosition.Manual;
				base.Hide();
				Transition.run(this, "Opacity", 1.0, new TransitionType_EaseInEaseOut(220));
			}
			catch (Exception)
			{
			}
			return base.ShowDialog();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00012254 File Offset: 0x00010454
		public new void Close()
		{
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(220));
			transition.add(this, "Opacity", 0.0);
			transition.run();
			transition.TransitionCompletedEvent += delegate
			{
				base.Close();
			};
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000122A8 File Offset: 0x000104A8
		public new void Hide()
		{
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(220));
			transition.add(this, "Opacity", 0.0);
			transition.run();
			transition.TransitionCompletedEvent += delegate
			{
				base.Hide();
			};
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000122FB File Offset: 0x000104FB
		private void ShowVisualMovementCues()
		{
			base.Opacity = 0.8;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001230E File Offset: 0x0001050E
		private void HideVisualMovementCues()
		{
			base.Opacity = 1.0;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00012324 File Offset: 0x00010524
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
			}
			else
			{
				this.bdrBottom.Show();
				this.bdrRight.Show();
				this.bdrLeft.Show();
				this.bdrTop.Show();
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000123A8 File Offset: 0x000105A8
		private void TrialBox_Load(object sender, EventArgs e)
		{
			this.ApplyShadows();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000123B2 File Offset: 0x000105B2
		private void LnkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://bunifuframework.com");
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000123C0 File Offset: 0x000105C0
		private void PbClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000123CC File Offset: 0x000105CC
		private void btnActivatePremium_Click(object sender, EventArgs e)
		{
			try
			{
				InformationBoxHelper.Show("This will allow you to activate a new license you have purchased. Once activated, kindly ensure you clean and build your project for the license changes to take effect.", "Activate Premium License", "", InformationBox.InformationBoxIcons.Information, "Okay", "");
				base.Invoke(this.OnClickActivatePremium);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00012420 File Offset: 0x00010620
		private void LblTrialLink_Click(object sender, EventArgs e)
		{
			Process.Start("https://bunifuframework.com/free-download/");
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0001242E File Offset: 0x0001062E
		private void LblHotStrings_Click(object sender, EventArgs e)
		{
			Process.Start("https://bunifuframework.com/pricing");
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0001243C File Offset: 0x0001063C
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00012446 File Offset: 0x00010646
		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0001245C File Offset: 0x0001065C
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

		// Token: 0x06000120 RID: 288 RVA: 0x000124D8 File Offset: 0x000106D8
		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			this._drag = true;
			this.Cursor = Cursors.Default;
			this._mousex = Cursor.Position.X - base.Left;
			this._mousey = Cursor.Position.Y - base.Top;
		}

		// Token: 0x040000DF RID: 223
		private bool _drag;

		// Token: 0x040000E0 RID: 224
		private int _mousey;

		// Token: 0x040000E1 RID: 225
		private int _mousex;

		// Token: 0x040000E2 RID: 226
		private bool _showApplyNewLicenseButton;
	}
}
