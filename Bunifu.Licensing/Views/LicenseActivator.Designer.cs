namespace Bunifu.Licensing.Views
{
	// Token: 0x02000009 RID: 9
	//global::System.Diagnostics.DebuggerStepThrough]
	internal partial class LicenseActivator : global::System.Windows.Forms.Form
	{
		// Token: 0x06000101 RID: 257 RVA: 0x0000FA6C File Offset: 0x0000DC6C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000FAA4 File Offset: 0x0000DCA4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Bunifu.Licensing.Views.LicenseActivator));
			this.lblWindowTitle = new global::System.Windows.Forms.Label();
			this.pnlHeader = new global::System.Windows.Forms.Panel();
			this.bdrRight = new global::System.Windows.Forms.Label();
			this.bdrLeft = new global::System.Windows.Forms.Label();
			this.bdrTop = new global::System.Windows.Forms.Label();
			this.lblDescription = new global::System.Windows.Forms.Label();
			this.lblTitle = new global::System.Windows.Forms.Label();
			this.bdrHeader = new global::System.Windows.Forms.Panel();
			this.pbIcon = new global::System.Windows.Forms.PictureBox();
			this.pbClose = new global::System.Windows.Forms.PictureBox();
			this.btnActivate = new global::System.Windows.Forms.Button();
			this.pblFooter = new global::System.Windows.Forms.Panel();
			this.bdrBottom = new global::System.Windows.Forms.Label();
			this.bdrBottomRight = new global::System.Windows.Forms.Label();
			this.bdrBottomLeft = new global::System.Windows.Forms.Label();
			this.lblLinksSeparator2 = new global::System.Windows.Forms.Label();
			this.lnkRenew = new global::System.Windows.Forms.LinkLabel();
			this.brdFooterSeparator = new global::System.Windows.Forms.Panel();
			this.lblLinksSeparator1 = new global::System.Windows.Forms.Label();
			this.lnkSupport = new global::System.Windows.Forms.LinkLabel();
			this.lnkHome = new global::System.Windows.Forms.LinkLabel();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.toolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.pbLicenseKeyError = new global::System.Windows.Forms.PictureBox();
			this.pbEmailError = new global::System.Windows.Forms.PictureBox();
			this.chkTrial = new global::System.Windows.Forms.CheckBox();
			this.pbEmail = new global::System.Windows.Forms.PictureBox();
			this.pbLicenseKey = new global::System.Windows.Forms.PictureBox();
			this.pnlContent = new global::System.Windows.Forms.Panel();
			this.bdrMidRight = new global::System.Windows.Forms.Label();
			this.bdrMidLeft = new global::System.Windows.Forms.Label();
			this.lblLicenseKey = new global::System.Windows.Forms.Label();
			this.lblEmail = new global::System.Windows.Forms.Label();
			this.txtEmail = new global::System.Windows.Forms.TextBox();
			this.txtLicenseKey = new global::System.Windows.Forms.TextBox();
			this.boxLicenseKey = new global::Bunifu.Licensing.Views.Controls.Box();
			this.boxEmail = new global::Bunifu.Licensing.Views.Controls.Box();
			this.cmsLicenseKeyMenu = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyFromClipboardToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.pnlHeader.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).BeginInit();
			this.pblFooter.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbLicenseKeyError).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbEmailError).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbEmail).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbLicenseKey).BeginInit();
			this.pnlContent.SuspendLayout();
			this.cmsLicenseKeyMenu.SuspendLayout();
			base.SuspendLayout();
			this.lblWindowTitle.AutoSize = true;
			this.lblWindowTitle.BackColor = global::System.Drawing.Color.Transparent;
			this.lblWindowTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblWindowTitle.ForeColor = global::System.Drawing.Color.FromArgb(111, 114, 119);
			this.lblWindowTitle.Location = new global::System.Drawing.Point(30, 8);
			this.lblWindowTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWindowTitle.Name = "lblWindowTitle";
			this.lblWindowTitle.Size = new global::System.Drawing.Size(128, 20);
			this.lblWindowTitle.TabIndex = 0;
			this.lblWindowTitle.Text = "Bunifu Framework";
			this.lblWindowTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblWindowTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblWindowTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.pnlHeader.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pnlHeader.Controls.Add(this.bdrRight);
			this.pnlHeader.Controls.Add(this.bdrLeft);
			this.pnlHeader.Controls.Add(this.bdrTop);
			this.pnlHeader.Controls.Add(this.lblDescription);
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Controls.Add(this.bdrHeader);
			this.pnlHeader.Controls.Add(this.pbIcon);
			this.pnlHeader.Controls.Add(this.pbClose);
			this.pnlHeader.Controls.Add(this.lblWindowTitle);
			this.pnlHeader.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new global::System.Drawing.Point(0, 0);
			this.pnlHeader.Margin = new global::System.Windows.Forms.Padding(2);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new global::System.Drawing.Size(588, 115);
			this.pnlHeader.TabIndex = 2;
			this.pnlHeader.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pnlHeader.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pnlHeader.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.bdrRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrRight.Location = new global::System.Drawing.Point(587, 1);
			this.bdrRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrRight.Name = "bdrRight";
			this.bdrRight.Size = new global::System.Drawing.Size(1, 113);
			this.bdrRight.TabIndex = 41;
			this.bdrLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrLeft.Location = new global::System.Drawing.Point(0, 1);
			this.bdrLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrLeft.Name = "bdrLeft";
			this.bdrLeft.Size = new global::System.Drawing.Size(1, 113);
			this.bdrLeft.TabIndex = 40;
			this.bdrTop.BackColor = global::System.Drawing.Color.Silver;
			this.bdrTop.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.bdrTop.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrTop.ForeColor = global::System.Drawing.Color.Black;
			this.bdrTop.Location = new global::System.Drawing.Point(0, 0);
			this.bdrTop.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrTop.Name = "bdrTop";
			this.bdrTop.Size = new global::System.Drawing.Size(588, 1);
			this.bdrTop.TabIndex = 39;
			this.lblDescription.AutoSize = true;
			this.lblDescription.BackColor = global::System.Drawing.Color.Transparent;
			this.lblDescription.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblDescription.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblDescription.Location = new global::System.Drawing.Point(19, 80);
			this.lblDescription.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new global::System.Drawing.Size(313, 20);
			this.lblDescription.TabIndex = 6;
			this.lblDescription.Text = "Please provide your license details to proceed";
			this.lblDescription.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblDescription.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblDescription.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.lblTitle.AutoSize = true;
			this.lblTitle.BackColor = global::System.Drawing.Color.Transparent;
			this.lblTitle.Font = new global::System.Drawing.Font("Segoe UI", 15.75f);
			this.lblTitle.ForeColor = global::System.Drawing.Color.Black;
			this.lblTitle.Location = new global::System.Drawing.Point(18, 46);
			this.lblTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new global::System.Drawing.Size(227, 37);
			this.lblTitle.TabIndex = 5;
			this.lblTitle.Text = "Activate Bunifu UI";
			this.lblTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.bdrHeader.BackColor = global::System.Drawing.Color.Gainsboro;
			this.bdrHeader.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrHeader.Location = new global::System.Drawing.Point(0, 114);
			this.bdrHeader.Margin = new global::System.Windows.Forms.Padding(2);
			this.bdrHeader.Name = "bdrHeader";
			this.bdrHeader.Size = new global::System.Drawing.Size(588, 1);
			this.bdrHeader.TabIndex = 12;
			this.pbIcon.BackColor = global::System.Drawing.Color.Transparent;
			this.pbIcon.Image = global::Bunifu.Licensing.Properties.Resources.bunifu_framework_logo;
			this.pbIcon.Location = new global::System.Drawing.Point(10, 9);
			this.pbIcon.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new global::System.Drawing.Size(18, 16);
			this.pbIcon.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbIcon.TabIndex = 3;
			this.pbIcon.TabStop = false;
			this.pbIcon.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pbIcon.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pbIcon.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.pbClose.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.pbClose.BackColor = global::System.Drawing.Color.Transparent;
			this.pbClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClose.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbClose.Image");
			this.pbClose.Location = new global::System.Drawing.Point(552, 10);
			this.pbClose.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new global::System.Drawing.Size(25, 18);
			this.pbClose.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbClose.TabIndex = 4;
			this.pbClose.TabStop = false;
			this.toolTip.SetToolTip(this.pbClose, "Cancel activation");
			this.pbClose.Click += new global::System.EventHandler(this.OnClickClose);
			this.btnActivate.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnActivate.BackColor = global::System.Drawing.Color.DodgerBlue;
			this.btnActivate.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnActivate.FlatAppearance.BorderColor = global::System.Drawing.Color.DodgerBlue;
			this.btnActivate.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnActivate.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnActivate.ForeColor = global::System.Drawing.Color.White;
			this.btnActivate.Location = new global::System.Drawing.Point(447, 11);
			this.btnActivate.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnActivate.Name = "btnActivate";
			this.btnActivate.Size = new global::System.Drawing.Size(129, 37);
			this.btnActivate.TabIndex = 2;
			this.btnActivate.Text = "Activate";
			this.toolTip.SetToolTip(this.btnActivate, "Activate your license");
			this.btnActivate.UseVisualStyleBackColor = false;
			this.btnActivate.Click += new global::System.EventHandler(this.BtnActivate_Click);
			this.btnActivate.MouseLeave += new global::System.EventHandler(this.btnActivate_MouseLeave);
			this.pblFooter.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pblFooter.Controls.Add(this.bdrBottom);
			this.pblFooter.Controls.Add(this.bdrBottomRight);
			this.pblFooter.Controls.Add(this.bdrBottomLeft);
			this.pblFooter.Controls.Add(this.lblLinksSeparator2);
			this.pblFooter.Controls.Add(this.lnkRenew);
			this.pblFooter.Controls.Add(this.brdFooterSeparator);
			this.pblFooter.Controls.Add(this.lblLinksSeparator1);
			this.pblFooter.Controls.Add(this.lnkSupport);
			this.pblFooter.Controls.Add(this.lnkHome);
			this.pblFooter.Controls.Add(this.btnCancel);
			this.pblFooter.Controls.Add(this.btnActivate);
			this.pblFooter.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.pblFooter.Location = new global::System.Drawing.Point(0, 322);
			this.pblFooter.Margin = new global::System.Windows.Forms.Padding(2);
			this.pblFooter.Name = "pblFooter";
			this.pblFooter.Size = new global::System.Drawing.Size(588, 58);
			this.pblFooter.TabIndex = 12;
			this.bdrBottom.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrBottom.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottom.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottom.Location = new global::System.Drawing.Point(1, 57);
			this.bdrBottom.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottom.Name = "bdrBottom";
			this.bdrBottom.Size = new global::System.Drawing.Size(586, 1);
			this.bdrBottom.TabIndex = 40;
			this.bdrBottomRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottomRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrBottomRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottomRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottomRight.Location = new global::System.Drawing.Point(587, 1);
			this.bdrBottomRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottomRight.Name = "bdrBottomRight";
			this.bdrBottomRight.Size = new global::System.Drawing.Size(1, 57);
			this.bdrBottomRight.TabIndex = 38;
			this.bdrBottomLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottomLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrBottomLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottomLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottomLeft.Location = new global::System.Drawing.Point(0, 1);
			this.bdrBottomLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottomLeft.Name = "bdrBottomLeft";
			this.bdrBottomLeft.Size = new global::System.Drawing.Size(1, 57);
			this.bdrBottomLeft.TabIndex = 36;
			this.lblLinksSeparator2.AutoSize = true;
			this.lblLinksSeparator2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLinksSeparator2.ForeColor = global::System.Drawing.Color.DarkGray;
			this.lblLinksSeparator2.Location = new global::System.Drawing.Point(141, 19);
			this.lblLinksSeparator2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLinksSeparator2.Name = "lblLinksSeparator2";
			this.lblLinksSeparator2.Size = new global::System.Drawing.Size(15, 20);
			this.lblLinksSeparator2.TabIndex = 21;
			this.lblLinksSeparator2.Text = "•";
			this.lnkRenew.AutoSize = true;
			this.lnkRenew.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkRenew.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkRenew.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkRenew.Location = new global::System.Drawing.Point(154, 19);
			this.lnkRenew.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkRenew.Name = "lnkRenew";
			this.lnkRenew.Size = new global::System.Drawing.Size(53, 20);
			this.lnkRenew.TabIndex = 20;
			this.lnkRenew.TabStop = true;
			this.lnkRenew.Text = "Renew";
			this.toolTip.SetToolTip(this.lnkRenew, "Renew your license");
			this.lnkRenew.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnClickRenewLink);
			this.brdFooterSeparator.BackColor = global::System.Drawing.Color.Gainsboro;
			this.brdFooterSeparator.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.brdFooterSeparator.Location = new global::System.Drawing.Point(0, 0);
			this.brdFooterSeparator.Margin = new global::System.Windows.Forms.Padding(2);
			this.brdFooterSeparator.Name = "brdFooterSeparator";
			this.brdFooterSeparator.Size = new global::System.Drawing.Size(588, 1);
			this.brdFooterSeparator.TabIndex = 19;
			this.lblLinksSeparator1.AutoSize = true;
			this.lblLinksSeparator1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLinksSeparator1.ForeColor = global::System.Drawing.Color.DarkGray;
			this.lblLinksSeparator1.Location = new global::System.Drawing.Point(65, 19);
			this.lblLinksSeparator1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLinksSeparator1.Name = "lblLinksSeparator1";
			this.lblLinksSeparator1.Size = new global::System.Drawing.Size(15, 20);
			this.lblLinksSeparator1.TabIndex = 18;
			this.lblLinksSeparator1.Text = "•";
			this.lnkSupport.AutoSize = true;
			this.lnkSupport.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkSupport.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkSupport.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkSupport.Location = new global::System.Drawing.Point(78, 19);
			this.lnkSupport.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkSupport.Name = "lnkSupport";
			this.lnkSupport.Size = new global::System.Drawing.Size(62, 20);
			this.lnkSupport.TabIndex = 4;
			this.lnkSupport.TabStop = true;
			this.lnkSupport.Text = "Support";
			this.toolTip.SetToolTip(this.lnkSupport, "Visit customer support page");
			this.lnkSupport.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnClickSupportLink);
			this.lnkHome.AutoSize = true;
			this.lnkHome.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkHome.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkHome.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkHome.Location = new global::System.Drawing.Point(16, 19);
			this.lnkHome.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkHome.Name = "lnkHome";
			this.lnkHome.Size = new global::System.Drawing.Size(50, 20);
			this.lnkHome.TabIndex = 5;
			this.lnkHome.TabStop = true;
			this.lnkHome.Text = "Home";
			this.toolTip.SetToolTip(this.lnkHome, "Visit Bunifu Framework homepage");
			this.lnkHome.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnClickHomeLink);
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.btnCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnCancel.FlatAppearance.BorderColor = global::System.Drawing.Color.LightGray;
			this.btnCancel.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnCancel.ForeColor = global::System.Drawing.Color.DimGray;
			this.btnCancel.Location = new global::System.Drawing.Point(313, 11);
			this.btnCancel.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(129, 37);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.toolTip.SetToolTip(this.btnCancel, "Cancel activation");
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.OnClickCancel);
			this.pbLicenseKeyError.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.pbLicenseKeyError.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbLicenseKeyError.Image");
			this.pbLicenseKeyError.Location = new global::System.Drawing.Point(524, 150);
			this.pbLicenseKeyError.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbLicenseKeyError.Name = "pbLicenseKeyError";
			this.pbLicenseKeyError.Size = new global::System.Drawing.Size(22, 16);
			this.pbLicenseKeyError.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbLicenseKeyError.TabIndex = 18;
			this.pbLicenseKeyError.TabStop = false;
			this.toolTip.SetToolTip(this.pbLicenseKeyError, "Please provide a valid license key");
			this.pbLicenseKeyError.Visible = false;
			this.pbEmailError.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.pbEmailError.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbEmailError.Image");
			this.pbEmailError.Location = new global::System.Drawing.Point(531, 60);
			this.pbEmailError.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbEmailError.Name = "pbEmailError";
			this.pbEmailError.Size = new global::System.Drawing.Size(22, 16);
			this.pbEmailError.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbEmailError.TabIndex = 14;
			this.pbEmailError.TabStop = false;
			this.toolTip.SetToolTip(this.pbEmailError, "Please provide a valid email address");
			this.pbEmailError.Visible = false;
			this.chkTrial.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.chkTrial.AutoSize = true;
			this.chkTrial.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.chkTrial.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.chkTrial.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.chkTrial.ForeColor = global::System.Drawing.Color.Black;
			this.chkTrial.Location = new global::System.Drawing.Point(504, 20);
			this.chkTrial.Margin = new global::System.Windows.Forms.Padding(2);
			this.chkTrial.Name = "chkTrial";
			this.chkTrial.Size = new global::System.Drawing.Size(55, 24);
			this.chkTrial.TabIndex = 20;
			this.chkTrial.Text = "Trial";
			this.toolTip.SetToolTip(this.chkTrial, "Activate a free trial license (Ctrl + T)");
			this.chkTrial.UseVisualStyleBackColor = true;
			this.chkTrial.Visible = false;
			this.chkTrial.CheckedChanged += new global::System.EventHandler(this.OnTrialChecked);
			this.chkTrial.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.OnEntriesKeyDown);
			this.pbEmail.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.pbEmail.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbEmail.Image");
			this.pbEmail.Location = new global::System.Drawing.Point(32, 62);
			this.pbEmail.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbEmail.Name = "pbEmail";
			this.pbEmail.Size = new global::System.Drawing.Size(22, 12);
			this.pbEmail.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbEmail.TabIndex = 39;
			this.pbEmail.TabStop = false;
			this.toolTip.SetToolTip(this.pbEmail, "Please provide a valid email address");
			this.pbEmail.Click += new global::System.EventHandler(this.OnClickEmailIcon);
			this.pbLicenseKey.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.pbLicenseKey.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbLicenseKey.Image");
			this.pbLicenseKey.Location = new global::System.Drawing.Point(32, 151);
			this.pbLicenseKey.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbLicenseKey.Name = "pbLicenseKey";
			this.pbLicenseKey.Size = new global::System.Drawing.Size(22, 14);
			this.pbLicenseKey.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbLicenseKey.TabIndex = 40;
			this.pbLicenseKey.TabStop = false;
			this.toolTip.SetToolTip(this.pbLicenseKey, "Please provide your received license key");
			this.pbLicenseKey.Click += new global::System.EventHandler(this.OnClickLicenseKeyIcon);
			this.pnlContent.BackColor = global::System.Drawing.Color.White;
			this.pnlContent.Controls.Add(this.pbLicenseKey);
			this.pnlContent.Controls.Add(this.pbEmail);
			this.pnlContent.Controls.Add(this.bdrMidRight);
			this.pnlContent.Controls.Add(this.bdrMidLeft);
			this.pnlContent.Controls.Add(this.chkTrial);
			this.pnlContent.Controls.Add(this.pbLicenseKeyError);
			this.pnlContent.Controls.Add(this.pbEmailError);
			this.pnlContent.Controls.Add(this.lblLicenseKey);
			this.pnlContent.Controls.Add(this.lblEmail);
			this.pnlContent.Controls.Add(this.txtEmail);
			this.pnlContent.Controls.Add(this.txtLicenseKey);
			this.pnlContent.Controls.Add(this.boxLicenseKey);
			this.pnlContent.Controls.Add(this.boxEmail);
			this.pnlContent.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new global::System.Drawing.Point(0, 115);
			this.pnlContent.Margin = new global::System.Windows.Forms.Padding(2);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new global::System.Drawing.Size(588, 207);
			this.pnlContent.TabIndex = 13;
			this.bdrMidRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrMidRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrMidRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidRight.Location = new global::System.Drawing.Point(587, 0);
			this.bdrMidRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrMidRight.Name = "bdrMidRight";
			this.bdrMidRight.Size = new global::System.Drawing.Size(1, 207);
			this.bdrMidRight.TabIndex = 38;
			this.bdrMidLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrMidLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrMidLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidLeft.Location = new global::System.Drawing.Point(0, 0);
			this.bdrMidLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrMidLeft.Name = "bdrMidLeft";
			this.bdrMidLeft.Size = new global::System.Drawing.Size(1, 207);
			this.bdrMidLeft.TabIndex = 36;
			this.lblLicenseKey.AutoSize = true;
			this.lblLicenseKey.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLicenseKey.ForeColor = global::System.Drawing.Color.Black;
			this.lblLicenseKey.Location = new global::System.Drawing.Point(26, 112);
			this.lblLicenseKey.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLicenseKey.Name = "lblLicenseKey";
			this.lblLicenseKey.Size = new global::System.Drawing.Size(419, 20);
			this.lblLicenseKey.TabIndex = 13;
			this.lblLicenseKey.Text = "Enter your valid product license key, e.g. 88a62167p2954r3h15";
			this.lblEmail.AutoSize = true;
			this.lblEmail.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblEmail.ForeColor = global::System.Drawing.Color.Black;
			this.lblEmail.Location = new global::System.Drawing.Point(26, 22);
			this.lblEmail.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new global::System.Drawing.Size(408, 20);
			this.lblEmail.TabIndex = 11;
			this.lblEmail.Text = "Enter your purchase email address, e.g. johndoe@gmail.com";
			this.txtEmail.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.Append;
			this.txtEmail.BackColor = global::System.Drawing.Color.White;
			this.txtEmail.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtEmail.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold);
			this.txtEmail.ForeColor = global::System.Drawing.Color.Black;
			this.txtEmail.Location = new global::System.Drawing.Point(58, 55);
			this.txtEmail.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new global::System.Drawing.Size(496, 27);
			this.txtEmail.TabIndex = 0;
			this.txtEmail.Enter += new global::System.EventHandler(this.OnEnterEmailInput);
			this.txtEmail.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.OnEntriesKeyDown);
			this.txtEmail.Leave += new global::System.EventHandler(this.OnLeaveEmailInput);
			this.txtLicenseKey.BackColor = global::System.Drawing.Color.White;
			this.txtLicenseKey.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtLicenseKey.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold);
			this.txtLicenseKey.ForeColor = global::System.Drawing.Color.Black;
			this.txtLicenseKey.Location = new global::System.Drawing.Point(58, 145);
			this.txtLicenseKey.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtLicenseKey.Name = "txtLicenseKey";
			this.txtLicenseKey.Size = new global::System.Drawing.Size(496, 27);
			this.txtLicenseKey.TabIndex = 1;
			this.txtLicenseKey.Enter += new global::System.EventHandler(this.OnEnterLicenseKeyInput);
			this.txtLicenseKey.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.OnEntriesKeyDown);
			this.txtLicenseKey.Leave += new global::System.EventHandler(this.OnLeaveLicenseKeyInput);
			this.boxLicenseKey.BackColor = global::System.Drawing.Color.Transparent;
			this.boxLicenseKey.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.boxLicenseKey.LineColor = global::System.Drawing.Color.LightGray;
			this.boxLicenseKey.LineStyle = global::Bunifu.Licensing.Views.Controls.Box.LineStyles.Solid;
			this.boxLicenseKey.Location = new global::System.Drawing.Point(26, 138);
			this.boxLicenseKey.Margin = new global::System.Windows.Forms.Padding(2);
			this.boxLicenseKey.Name = "boxLicenseKey";
			this.boxLicenseKey.Size = new global::System.Drawing.Size(536, 41);
			this.boxLicenseKey.TabIndex = 17;
			this.boxLicenseKey.LineColorChanged += new global::System.EventHandler(this.OnLicenseKeyBoxColorChanged);
			this.boxLicenseKey.Click += new global::System.EventHandler(this.OnClickLicenseKeyBox);
			this.boxEmail.BackColor = global::System.Drawing.Color.Transparent;
			this.boxEmail.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.boxEmail.LineColor = global::System.Drawing.Color.LightGray;
			this.boxEmail.LineStyle = global::Bunifu.Licensing.Views.Controls.Box.LineStyles.Solid;
			this.boxEmail.Location = new global::System.Drawing.Point(26, 48);
			this.boxEmail.Margin = new global::System.Windows.Forms.Padding(2);
			this.boxEmail.Name = "boxEmail";
			this.boxEmail.Size = new global::System.Drawing.Size(536, 41);
			this.boxEmail.TabIndex = 16;
			this.boxEmail.LineColorChanged += new global::System.EventHandler(this.OnEmailBoxColorChanged);
			this.boxEmail.Click += new global::System.EventHandler(this.OnClickEmailBox);
			this.cmsLicenseKeyMenu.ImageScalingSize = new global::System.Drawing.Size(20, 20);
			this.cmsLicenseKeyMenu.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.copyFromClipboardToolStripMenuItem });
			this.cmsLicenseKeyMenu.Name = "cmsLicenseKeyMenu";
			this.cmsLicenseKeyMenu.Size = new global::System.Drawing.Size(223, 30);
			this.copyFromClipboardToolStripMenuItem.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("copyFromClipboardToolStripMenuItem.Image");
			this.copyFromClipboardToolStripMenuItem.Name = "copyFromClipboardToolStripMenuItem";
			this.copyFromClipboardToolStripMenuItem.Size = new global::System.Drawing.Size(222, 26);
			this.copyFromClipboardToolStripMenuItem.Text = "Copy from Clipboard";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(588, 380);
			base.Controls.Add(this.pnlContent);
			base.Controls.Add(this.pblFooter);
			base.Controls.Add(this.pnlHeader);
			this.DoubleBuffered = true;
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "LicenseActivator";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bunifu Framework: Activate License";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.OnClose);
			base.Load += new global::System.EventHandler(this.OnLoad);
			base.Shown += new global::System.EventHandler(this.OnShow);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.OnEntriesKeyDown);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).EndInit();
			this.pblFooter.ResumeLayout(false);
			this.pblFooter.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbLicenseKeyError).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbEmailError).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbEmail).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbLicenseKey).EndInit();
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			this.cmsLicenseKeyMenu.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040000B7 RID: 183
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.Label lblWindowTitle;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.Panel pnlHeader;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.Label lblTitle;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.PictureBox pbIcon;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Label lblDescription;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Button btnActivate;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.Panel pblFooter;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.ToolTip toolTip;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Panel pnlContent;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Label lblLicenseKey;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Label lblEmail;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Panel bdrHeader;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.LinkLabel lnkHome;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.LinkLabel lnkSupport;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Label lblLinksSeparator1;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Panel brdFooterSeparator;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.ContextMenuStrip cmsLicenseKeyMenu;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.ToolStripMenuItem copyFromClipboardToolStripMenuItem;

		// Token: 0x040000CB RID: 203
		private global::Bunifu.Licensing.Views.Controls.Box boxLicenseKey;

		// Token: 0x040000CC RID: 204
		private global::Bunifu.Licensing.Views.Controls.Box boxEmail;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.PictureBox pbEmailError;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.PictureBox pbLicenseKeyError;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Label lblLinksSeparator2;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.LinkLabel lnkRenew;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.CheckBox chkTrial;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Label bdrTop;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.Label bdrLeft;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Label bdrBottomLeft;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Label bdrMidLeft;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.Label bdrRight;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Label bdrBottomRight;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Label bdrMidRight;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Label bdrBottom;

		// Token: 0x040000DA RID: 218
		internal global::System.Windows.Forms.TextBox txtLicenseKey;

		// Token: 0x040000DB RID: 219
		internal global::System.Windows.Forms.TextBox txtEmail;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.PictureBox pbEmail;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.PictureBox pbLicenseKey;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.PictureBox pbClose;
	}
}
