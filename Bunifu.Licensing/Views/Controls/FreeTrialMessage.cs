using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Bunifu.Licensing.Views.Controls
{
	// Token: 0x02000024 RID: 36
	[ToolboxItem(false)]
	[DebuggerStepThrough]
	[DefaultEvent("Click")]
	[DefaultProperty("Hidden")]
	[Description("Provides a free-trial message view in the activation window.")]
	internal class FreeTrialMessage : UserControl
	{
		// Token: 0x06000198 RID: 408 RVA: 0x00015BC1 File Offset: 0x00013DC1
		public FreeTrialMessage()
		{
			this.InitializeComponent();
			this.ImproveTextRendering();
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00015BE7 File Offset: 0x00013DE7
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00015BF0 File Offset: 0x00013DF0
		[Category("Appearance")]
		[Description("Sets a value indicating whether the free-trial message's components will be displayed.")]
		public bool Hidden
		{
			get
			{
				return this._hidden;
			}
			set
			{
				this._hidden = value;
				if (value)
				{
					this.lblMessage.Hide();
					this.lblSideQuote.Hide();
					this.lblQuoteContainer.Hide();
					this.lnkFreeTrialSignup.Hide();
				}
				else
				{
					this.lblMessage.Show();
					this.lblSideQuote.Show();
					this.lblQuoteContainer.Show();
					this.lnkFreeTrialSignup.Show();
				}
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00015C70 File Offset: 0x00013E70
		private void ImproveTextRendering()
		{
			this.lblMessage.UseCompatibleTextRendering = false;
			this.lblSideQuote.UseCompatibleTextRendering = false;
			this.lblQuoteContainer.UseCompatibleTextRendering = false;
			this.lnkFreeTrialSignup.UseCompatibleTextRendering = false;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00015CA7 File Offset: 0x00013EA7
		private void lnkFreeTrialSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://bunifuframework.com/free-download");
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00015CB8 File Offset: 0x00013EB8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00015CF0 File Offset: 0x00013EF0
		private void InitializeComponent()
		{
			this.components = new Container();
			this.lblMessage = new Label();
			this.lnkFreeTrialSignup = new LinkLabel();
			this.lblSideQuote = new Label();
			this.lblQuoteContainer = new Label();
			this.toolTip = new ToolTip(this.components);
			base.SuspendLayout();
			this.lblMessage.Anchor = AnchorStyles.Left;
			this.lblMessage.AutoSize = true;
			this.lblMessage.BackColor = Color.FromArgb(235, 244, 255);
			this.lblMessage.Font = new Font("Segoe UI", 9f);
			this.lblMessage.ForeColor = Color.FromArgb(64, 64, 64);
			this.lblMessage.Location = new Point(20, 14);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new Size(292, 15);
			this.lblMessage.TabIndex = 12;
			this.lblMessage.Text = "If you haven't yet registered for a free trial, please visit:";
			this.lnkFreeTrialSignup.ActiveLinkColor = Color.LimeGreen;
			this.lnkFreeTrialSignup.Anchor = AnchorStyles.Left;
			this.lnkFreeTrialSignup.AutoSize = true;
			this.lnkFreeTrialSignup.BackColor = Color.FromArgb(235, 244, 255);
			this.lnkFreeTrialSignup.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lnkFreeTrialSignup.LinkBehavior = LinkBehavior.AlwaysUnderline;
			this.lnkFreeTrialSignup.LinkColor = Color.DodgerBlue;
			this.lnkFreeTrialSignup.Location = new Point(20, 30);
			this.lnkFreeTrialSignup.Name = "lnkFreeTrialSignup";
			this.lnkFreeTrialSignup.Size = new Size(249, 15);
			this.lnkFreeTrialSignup.TabIndex = 13;
			this.lnkFreeTrialSignup.TabStop = true;
			this.lnkFreeTrialSignup.Text = "https://bunifuframework.com/free-download";
			this.toolTip.SetToolTip(this.lnkFreeTrialSignup, "Register with your email for a 14-day free trial...");
			this.lnkFreeTrialSignup.LinkClicked += this.lnkFreeTrialSignup_LinkClicked;
			this.lblSideQuote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.lblSideQuote.BackColor = Color.FromArgb(105, 181, 255);
			this.lblSideQuote.Font = new Font("Segoe UI", 9f);
			this.lblSideQuote.ForeColor = Color.Black;
			this.lblSideQuote.Location = new Point(9, 7);
			this.lblSideQuote.Name = "lblSideQuote";
			this.lblSideQuote.Size = new Size(3, 47);
			this.lblSideQuote.TabIndex = 14;
			this.lblQuoteContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.lblQuoteContainer.BackColor = Color.FromArgb(235, 244, 255);
			this.lblQuoteContainer.Font = new Font("Segoe UI", 9f);
			this.lblQuoteContainer.ForeColor = Color.Black;
			this.lblQuoteContainer.Location = new Point(12, 7);
			this.lblQuoteContainer.Name = "lblQuoteContainer";
			this.lblQuoteContainer.Size = new Size(362, 47);
			this.lblQuoteContainer.TabIndex = 15;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.lblSideQuote);
			base.Controls.Add(this.lnkFreeTrialSignup);
			base.Controls.Add(this.lblMessage);
			base.Controls.Add(this.lblQuoteContainer);
			base.Name = "FreeTrialMessage";
			base.Size = new Size(383, 60);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000123 RID: 291
		private bool _hidden = false;

		// Token: 0x04000124 RID: 292
		private IContainer components = null;

		// Token: 0x04000125 RID: 293
		private Label lblMessage;

		// Token: 0x04000126 RID: 294
		private LinkLabel lnkFreeTrialSignup;

		// Token: 0x04000127 RID: 295
		private Label lblSideQuote;

		// Token: 0x04000128 RID: 296
		private Label lblQuoteContainer;

		// Token: 0x04000129 RID: 297
		private ToolTip toolTip;
	}
}
