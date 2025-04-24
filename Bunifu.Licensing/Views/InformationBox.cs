using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Views.Transitions;

namespace Bunifu.Licensing.Views
{
	// Token: 0x02000006 RID: 6
	[DebuggerStepThrough]
	internal partial class InformationBox : Form
	{
		// Token: 0x06000089 RID: 137 RVA: 0x000093C1 File Offset: 0x000075C1
		public InformationBox()
		{
			this.InitializeComponent();
			this.ImproveTextRendering();
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000093E0 File Offset: 0x000075E0
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000093E8 File Offset: 0x000075E8
		public string MoreInformationText { get; set; }

		// Token: 0x0600008C RID: 140 RVA: 0x000093F1 File Offset: 0x000075F1
		public new void Show()
		{
			this.lblMessage.Top = (this.pnlBody.Height - this.lblMessage.Height) / 2;
			base.Opacity = 1.0;
			base.Show();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00009430 File Offset: 0x00007630
		public new DialogResult ShowDialog()
		{
			try
			{
				this.lblMessage.Top = (this.pnlBody.Height - this.lblMessage.Height) / 2;
				base.Opacity = 1.0;
			}
			catch (Exception)
			{
			}
			return base.ShowDialog();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00009498 File Offset: 0x00007698
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

		// Token: 0x0600008F RID: 143 RVA: 0x000094E8 File Offset: 0x000076E8
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

		// Token: 0x06000090 RID: 144 RVA: 0x00009538 File Offset: 0x00007738
		public bool IsTextURL(string text)
		{
			return Uri.IsWellFormedUriString(text, UriKind.Absolute);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000955C File Offset: 0x0000775C
		private void ImproveTextRendering()
		{
			this.btnOkay.UseCompatibleTextRendering = false;
			this.btnCancel.UseCompatibleTextRendering = false;
			this.lblMessage.UseCompatibleTextRendering = false;
			this.lnkMoreInfo.UseCompatibleTextRendering = false;
			this.lblWindowTitle.UseCompatibleTextRendering = false;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000095AB File Offset: 0x000077AB
		private void ShowVisualMovementCues()
		{
			base.Opacity = 0.8;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000095BE File Offset: 0x000077BE
		private void HideVisualMovementCues()
		{
			base.Opacity = 1.0;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000095D4 File Offset: 0x000077D4
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

		// Token: 0x06000095 RID: 149 RVA: 0x000096B8 File Offset: 0x000078B8
		private void InformationBox_Load(object sender, EventArgs e)
		{
			this.ApplyShadows();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000096C2 File Offset: 0x000078C2
		private void InformationBox_Shown(object sender, EventArgs e)
		{
			this.lblMessage.Top = (this.pnlBody.Height - this.lblMessage.Height) / 2;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000096EA File Offset: 0x000078EA
		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00009700 File Offset: 0x00007900
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

		// Token: 0x06000099 RID: 153 RVA: 0x0000977C File Offset: 0x0000797C
		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			this._drag = true;
			this.Cursor = Cursors.Default;
			this._mousex = Cursor.Position.X - base.Left;
			this._mousey = Cursor.Position.Y - base.Top;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000097D4 File Offset: 0x000079D4
		private void LnkMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bool flag = this.IsTextURL(this.MoreInformationText);
			if (flag)
			{
				Process.Start(this.MoreInformationText);
			}
			else
			{
				MessageBox.Show(this.MoreInformationText, "Error Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00009818 File Offset: 0x00007A18
		private void PbClose_Click(object sender, EventArgs e)
		{
			bool visible = this.btnCancel.Visible;
			if (visible)
			{
				base.DialogResult = DialogResult.Cancel;
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
			this.Close();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00009850 File Offset: 0x00007A50
		private void InformationBox_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Escape;
			if (flag)
			{
				base.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00009880 File Offset: 0x00007A80
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

		// Token: 0x04000063 RID: 99
		private bool _drag;

		// Token: 0x04000064 RID: 100
		private int _mousey;

		// Token: 0x04000065 RID: 101
		private int _mousex;

		// Token: 0x02000041 RID: 65
		internal enum InformationBoxIcons
		{
			// Token: 0x040001A3 RID: 419
			Information,
			// Token: 0x040001A4 RID: 420
			Warning,
			// Token: 0x040001A5 RID: 421
			Alert,
			// Token: 0x040001A6 RID: 422
			Error
		}
	}
}
