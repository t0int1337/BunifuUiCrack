namespace Bunifu.Licensing.Views
{
	// Token: 0x0200000A RID: 10
	//global::System.Diagnostics.DebuggerStepThrough]
	internal partial class TrialBox : global::System.Windows.Forms.Form
	{
		// Token: 0x06000121 RID: 289 RVA: 0x00012530 File Offset: 0x00010730
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00012568 File Offset: 0x00010768
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Bunifu.Licensing.Views.TrialBox));
			this.lblDescription = new global::System.Windows.Forms.Label();
			this.toolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.lnkHome = new global::System.Windows.Forms.LinkLabel();
			this.pbClose = new global::System.Windows.Forms.PictureBox();
			this.btnApplyNewLicense = new global::System.Windows.Forms.Button();
			this.pbPreview = new global::System.Windows.Forms.PictureBox();
			this.lblFirstNoticeString = new global::System.Windows.Forms.Label();
			this.lblLinksSeparator1 = new global::System.Windows.Forms.Label();
			this.lblCopyright = new global::System.Windows.Forms.LinkLabel();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.lblContainer = new global::System.Windows.Forms.Label();
			this.brdLeftContainer = new global::System.Windows.Forms.Label();
			this.brdBottomContainer = new global::System.Windows.Forms.Label();
			this.brdTopContainer = new global::System.Windows.Forms.Label();
			this.brdRightContainer = new global::System.Windows.Forms.Label();
			this.bdrLeft = new global::System.Windows.Forms.Label();
			this.bdrRight = new global::System.Windows.Forms.Label();
			this.bdrTop = new global::System.Windows.Forms.Label();
			this.bdrBottom = new global::System.Windows.Forms.Label();
			this.pbTitle = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbPreview).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbTitle).BeginInit();
			base.SuspendLayout();
			this.lblDescription.AutoSize = true;
			this.lblDescription.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblDescription.ForeColor = global::System.Drawing.Color.Black;
			this.lblDescription.Location = new global::System.Drawing.Point(23, 70);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new global::System.Drawing.Size(338, 80);
			this.lblDescription.TabIndex = 6;
			this.lblDescription.Text = "Bunifu Framework empowers developers to build \r\nfaster and more beautiful software products with \r\nless using a ready-made suite of customizable \r\ncontrols and powerful data visualization tools.";
			this.toolTip.ShowAlways = true;
			this.lnkHome.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.lnkHome.AutoSize = true;
			this.lnkHome.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkHome.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkHome.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkHome.Location = new global::System.Drawing.Point(23, 234);
			this.lnkHome.Name = "lnkHome";
			this.lnkHome.Size = new global::System.Drawing.Size(116, 20);
			this.lnkHome.TabIndex = 23;
			this.lnkHome.TabStop = true;
			this.lnkHome.Text = "Visit Homepage";
			this.toolTip.SetToolTip(this.lnkHome, "Visit Bunifu Framework homepage");
			this.lnkHome.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkHome_LinkClicked);
			this.pbClose.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.pbClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClose.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbClose.Image");
			this.pbClose.Location = new global::System.Drawing.Point(613, 10);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new global::System.Drawing.Size(25, 17);
			this.pbClose.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbClose.TabIndex = 36;
			this.pbClose.TabStop = false;
			this.toolTip.SetToolTip(this.pbClose, "Close");
			this.pbClose.Click += new global::System.EventHandler(this.PbClose_Click);
			this.btnApplyNewLicense.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnApplyNewLicense.BackColor = global::System.Drawing.Color.DodgerBlue;
			this.btnApplyNewLicense.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnApplyNewLicense.FlatAppearance.BorderColor = global::System.Drawing.Color.DodgerBlue;
			this.btnApplyNewLicense.FlatAppearance.BorderSize = 2;
			this.btnApplyNewLicense.FlatAppearance.MouseDownBackColor = global::System.Drawing.Color.FromArgb(40, 96, 144);
			this.btnApplyNewLicense.FlatAppearance.MouseOverBackColor = global::System.Drawing.Color.FromArgb(105, 181, 255);
			this.btnApplyNewLicense.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnApplyNewLicense.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnApplyNewLicense.ForeColor = global::System.Drawing.Color.White;
			this.btnApplyNewLicense.Location = new global::System.Drawing.Point(367, 224);
			this.btnApplyNewLicense.Name = "btnApplyNewLicense";
			this.btnApplyNewLicense.Size = new global::System.Drawing.Size(173, 36);
			this.btnApplyNewLicense.TabIndex = 41;
			this.btnApplyNewLicense.Text = "Activate Premium";
			this.toolTip.SetToolTip(this.btnApplyNewLicense, componentResourceManager.GetString("btnApplyNewLicense.ToolTip"));
			this.btnApplyNewLicense.UseVisualStyleBackColor = false;
			this.btnApplyNewLicense.Visible = false;
			this.btnApplyNewLicense.Click += new global::System.EventHandler(this.btnActivatePremium_Click);
			this.pbPreview.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.pbPreview.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbPreview.Image");
			this.pbPreview.Location = new global::System.Drawing.Point(380, 51);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new global::System.Drawing.Size(255, 137);
			this.pbPreview.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbPreview.TabIndex = 15;
			this.pbPreview.TabStop = false;
			this.lblFirstNoticeString.AutoSize = true;
			this.lblFirstNoticeString.BackColor = global::System.Drawing.Color.FromArgb(255, 241, 240);
			this.lblFirstNoticeString.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblFirstNoticeString.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.lblFirstNoticeString.ForeColor = global::System.Drawing.Color.OrangeRed;
			this.lblFirstNoticeString.Location = new global::System.Drawing.Point(32, 168);
			this.lblFirstNoticeString.Name = "lblFirstNoticeString";
			this.lblFirstNoticeString.Size = new global::System.Drawing.Size(295, 46);
			this.lblFirstNoticeString.TabIndex = 16;
			this.lblFirstNoticeString.Text = "This software was developed using a \r\ntrial version of Bunifu Framework.";
			this.lblFirstNoticeString.Click += new global::System.EventHandler(this.LblHotStrings_Click);
			this.lblLinksSeparator1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.lblLinksSeparator1.AutoSize = true;
			this.lblLinksSeparator1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLinksSeparator1.ForeColor = global::System.Drawing.Color.DarkGray;
			this.lblLinksSeparator1.Location = new global::System.Drawing.Point(138, 235);
			this.lblLinksSeparator1.Name = "lblLinksSeparator1";
			this.lblLinksSeparator1.Size = new global::System.Drawing.Size(15, 20);
			this.lblLinksSeparator1.TabIndex = 24;
			this.lblLinksSeparator1.Text = "•";
			this.lblCopyright.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.lblCopyright.AutoSize = true;
			this.lblCopyright.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblCopyright.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblCopyright.LinkColor = global::System.Drawing.Color.Gray;
			this.lblCopyright.Location = new global::System.Drawing.Point(150, 235);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new global::System.Drawing.Size(195, 20);
			this.lblCopyright.TabIndex = 22;
			this.lblCopyright.TabStop = true;
			this.lblCopyright.Text = "© 2021 Bunifu Technologies";
			this.btnClose.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnClose.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.btnClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnClose.FlatAppearance.BorderColor = global::System.Drawing.Color.Silver;
			this.btnClose.FlatAppearance.BorderSize = 2;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnClose.ForeColor = global::System.Drawing.Color.DimGray;
			this.btnClose.Location = new global::System.Drawing.Point(544, 224);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(92, 36);
			this.btnClose.TabIndex = 31;
			this.btnClose.Text = "Ok";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.BtnCancel_Click);
			this.lblContainer.BackColor = global::System.Drawing.Color.FromArgb(255, 241, 240);
			this.lblContainer.Location = new global::System.Drawing.Point(27, 163);
			this.lblContainer.Name = "lblContainer";
			this.lblContainer.Size = new global::System.Drawing.Size(298, 57);
			this.lblContainer.TabIndex = 32;
			this.brdLeftContainer.BackColor = global::System.Drawing.Color.FromArgb(255, 163, 158);
			this.brdLeftContainer.Location = new global::System.Drawing.Point(26, 162);
			this.brdLeftContainer.Name = "brdLeftContainer";
			this.brdLeftContainer.Size = new global::System.Drawing.Size(1, 58);
			this.brdLeftContainer.TabIndex = 33;
			this.brdBottomContainer.BackColor = global::System.Drawing.Color.FromArgb(255, 163, 158);
			this.brdBottomContainer.Location = new global::System.Drawing.Point(27, 219);
			this.brdBottomContainer.Name = "brdBottomContainer";
			this.brdBottomContainer.Size = new global::System.Drawing.Size(301, 1);
			this.brdBottomContainer.TabIndex = 25;
			this.brdTopContainer.BackColor = global::System.Drawing.Color.FromArgb(255, 163, 158);
			this.brdTopContainer.Location = new global::System.Drawing.Point(27, 162);
			this.brdTopContainer.Name = "brdTopContainer";
			this.brdTopContainer.Size = new global::System.Drawing.Size(300, 1);
			this.brdTopContainer.TabIndex = 7;
			this.brdRightContainer.BackColor = global::System.Drawing.Color.FromArgb(255, 163, 158);
			this.brdRightContainer.Location = new global::System.Drawing.Point(327, 162);
			this.brdRightContainer.Name = "brdRightContainer";
			this.brdRightContainer.Size = new global::System.Drawing.Size(1, 57);
			this.brdRightContainer.TabIndex = 34;
			this.bdrLeft.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.bdrLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrLeft.Location = new global::System.Drawing.Point(0, 0);
			this.bdrLeft.Name = "bdrLeft";
			this.bdrLeft.Size = new global::System.Drawing.Size(1, 267);
			this.bdrLeft.TabIndex = 35;
			this.bdrRight.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.bdrRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrRight.Location = new global::System.Drawing.Point(647, 0);
			this.bdrRight.Name = "bdrRight";
			this.bdrRight.Size = new global::System.Drawing.Size(1, 267);
			this.bdrRight.TabIndex = 37;
			this.bdrTop.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.bdrTop.BackColor = global::System.Drawing.Color.Silver;
			this.bdrTop.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrTop.ForeColor = global::System.Drawing.Color.Black;
			this.bdrTop.Location = new global::System.Drawing.Point(1, 0);
			this.bdrTop.Name = "bdrTop";
			this.bdrTop.Size = new global::System.Drawing.Size(647, 1);
			this.bdrTop.TabIndex = 38;
			this.bdrBottom.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.bdrBottom.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottom.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottom.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottom.Location = new global::System.Drawing.Point(1, 266);
			this.bdrBottom.Name = "bdrBottom";
			this.bdrBottom.Size = new global::System.Drawing.Size(647, 1);
			this.bdrBottom.TabIndex = 39;
			this.pbTitle.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbTitle.Image");
			this.pbTitle.Location = new global::System.Drawing.Point(29, 11);
			this.pbTitle.Name = "pbTitle";
			this.pbTitle.Size = new global::System.Drawing.Size(271, 52);
			this.pbTitle.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbTitle.TabIndex = 40;
			this.pbTitle.TabStop = false;
			this.pbTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pbTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pbTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			base.AcceptButton = this.btnClose;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(648, 267);
			base.Controls.Add(this.btnApplyNewLicense);
			base.Controls.Add(this.pbTitle);
			base.Controls.Add(this.bdrBottom);
			base.Controls.Add(this.bdrTop);
			base.Controls.Add(this.bdrRight);
			base.Controls.Add(this.pbClose);
			base.Controls.Add(this.bdrLeft);
			base.Controls.Add(this.brdRightContainer);
			base.Controls.Add(this.brdLeftContainer);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.brdBottomContainer);
			base.Controls.Add(this.lblLinksSeparator1);
			base.Controls.Add(this.lblCopyright);
			base.Controls.Add(this.lnkHome);
			base.Controls.Add(this.lblFirstNoticeString);
			base.Controls.Add(this.pbPreview);
			base.Controls.Add(this.brdTopContainer);
			base.Controls.Add(this.lblContainer);
			base.Controls.Add(this.lblDescription);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Name = "TrialBox";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bunifu Framework Trial";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.TrialBox_Load);
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			base.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			base.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbPreview).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbTitle).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000E4 RID: 228
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.Label lblDescription;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.ToolTip toolTip;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.PictureBox pbPreview;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Label lblFirstNoticeString;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Label lblLinksSeparator1;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.LinkLabel lnkHome;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.LinkLabel lblCopyright;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.Label lblContainer;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.Label brdLeftContainer;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Label brdBottomContainer;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.Label brdTopContainer;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Label brdRightContainer;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.Label bdrLeft;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.PictureBox pbClose;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Label bdrRight;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.Label bdrTop;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Label bdrBottom;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.PictureBox pbTitle;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.Button btnApplyNewLicense;
	}
}
