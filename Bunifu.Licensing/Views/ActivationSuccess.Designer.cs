namespace Bunifu.Licensing.Views
{
	// Token: 0x02000004 RID: 4
	//global::System.Diagnostics.DebuggerStepThrough]
	internal partial class ActivationSuccess : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00005168 File Offset: 0x00003368
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000051A0 File Offset: 0x000033A0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Bunifu.Licensing.Views.ActivationSuccess));
			this.pnlHeader = new global::System.Windows.Forms.Panel();
			this.bdrLeft = new global::System.Windows.Forms.Label();
			this.bdrRight = new global::System.Windows.Forms.Label();
			this.bdrTop = new global::System.Windows.Forms.Label();
			this.pbIconLarge = new global::System.Windows.Forms.PictureBox();
			this.lblTitle = new global::System.Windows.Forms.Label();
			this.bdrHeader = new global::System.Windows.Forms.Panel();
			this.pbIcon = new global::System.Windows.Forms.PictureBox();
			this.pbClose = new global::System.Windows.Forms.PictureBox();
			this.lblWindowTitle = new global::System.Windows.Forms.Label();
			this.lblDescription = new global::System.Windows.Forms.Label();
			this.lblPurchaseEmailTitle = new global::System.Windows.Forms.Label();
			this.lblPurchaseEmail = new global::System.Windows.Forms.Label();
			this.lblLicenseKey = new global::System.Windows.Forms.Label();
			this.lblLicenseKeyTitle = new global::System.Windows.Forms.Label();
			this.lblProductName = new global::System.Windows.Forms.Label();
			this.lblProductTitle = new global::System.Windows.Forms.Label();
			this.lblActivations = new global::System.Windows.Forms.Label();
			this.lblActivationsTitle = new global::System.Windows.Forms.Label();
			this.lblExpiryDate = new global::System.Windows.Forms.Label();
			this.lblExpiryDateTitle = new global::System.Windows.Forms.Label();
			this.lblRemainingDays = new global::System.Windows.Forms.Label();
			this.lblRemainingDaysTitle = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.pnlFooter = new global::System.Windows.Forms.Panel();
			this.bdrBottom = new global::System.Windows.Forms.Label();
			this.bdrBottomLeft = new global::System.Windows.Forms.Label();
			this.bdrBottomRight = new global::System.Windows.Forms.Label();
			this.lblBullet2 = new global::System.Windows.Forms.Label();
			this.lnkRenew = new global::System.Windows.Forms.LinkLabel();
			this.brdFooterSeparator = new global::System.Windows.Forms.Panel();
			this.lblBullet1 = new global::System.Windows.Forms.Label();
			this.lnkSupport = new global::System.Windows.Forms.LinkLabel();
			this.lnkHome = new global::System.Windows.Forms.LinkLabel();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.lnkViewLicenseFile = new global::System.Windows.Forms.LinkLabel();
			this.lblLicenseType = new global::System.Windows.Forms.Label();
			this.lblLicenseTypeTitle = new global::System.Windows.Forms.Label();
			this.bdrMidRight = new global::System.Windows.Forms.Label();
			this.bdrMidLeft = new global::System.Windows.Forms.Label();
			this.lblPlanName = new global::System.Windows.Forms.Label();
			this.lblPlanTitle = new global::System.Windows.Forms.Label();
			this.lblRemainingDevices = new global::System.Windows.Forms.Label();
			this.lblRemainingDevicesTitle = new global::System.Windows.Forms.Label();
			this.ctaAlert = new global::Bunifu.Licensing.Views.Controls.Alert();
			this.pnlHeader.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIconLarge).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).BeginInit();
			this.pnlFooter.SuspendLayout();
			base.SuspendLayout();
			this.pnlHeader.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pnlHeader.Controls.Add(this.bdrLeft);
			this.pnlHeader.Controls.Add(this.bdrRight);
			this.pnlHeader.Controls.Add(this.bdrTop);
			this.pnlHeader.Controls.Add(this.pbIconLarge);
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Controls.Add(this.bdrHeader);
			this.pnlHeader.Controls.Add(this.pbIcon);
			this.pnlHeader.Controls.Add(this.pbClose);
			this.pnlHeader.Controls.Add(this.lblWindowTitle);
			this.pnlHeader.Controls.Add(this.lblDescription);
			this.pnlHeader.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new global::System.Drawing.Point(0, 0);
			this.pnlHeader.Margin = new global::System.Windows.Forms.Padding(2);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new global::System.Drawing.Size(499, 145);
			this.pnlHeader.TabIndex = 3;
			this.pnlHeader.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pnlHeader.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pnlHeader.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.bdrLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrLeft.Location = new global::System.Drawing.Point(0, 1);
			this.bdrLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrLeft.Name = "bdrLeft";
			this.bdrLeft.Size = new global::System.Drawing.Size(1, 143);
			this.bdrLeft.TabIndex = 53;
			this.bdrRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrRight.Location = new global::System.Drawing.Point(498, 1);
			this.bdrRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrRight.Name = "bdrRight";
			this.bdrRight.Size = new global::System.Drawing.Size(1, 143);
			this.bdrRight.TabIndex = 52;
			this.bdrTop.BackColor = global::System.Drawing.Color.Silver;
			this.bdrTop.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.bdrTop.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrTop.ForeColor = global::System.Drawing.Color.Black;
			this.bdrTop.Location = new global::System.Drawing.Point(0, 0);
			this.bdrTop.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrTop.Name = "bdrTop";
			this.bdrTop.Size = new global::System.Drawing.Size(499, 1);
			this.bdrTop.TabIndex = 51;
			this.pbIconLarge.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.pbIconLarge.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbIconLarge.Image");
			this.pbIconLarge.Location = new global::System.Drawing.Point(218, 36);
			this.pbIconLarge.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbIconLarge.Name = "pbIconLarge";
			this.pbIconLarge.Size = new global::System.Drawing.Size(62, 56);
			this.pbIconLarge.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbIconLarge.TabIndex = 13;
			this.pbIconLarge.TabStop = false;
			this.pbIconLarge.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pbIconLarge.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pbIconLarge.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.lblTitle.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Bold);
			this.lblTitle.ForeColor = global::System.Drawing.Color.Black;
			this.lblTitle.Location = new global::System.Drawing.Point(99, 89);
			this.lblTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new global::System.Drawing.Size(301, 28);
			this.lblTitle.TabIndex = 5;
			this.lblTitle.Text = "License successfully activated!";
			this.lblTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.bdrHeader.BackColor = global::System.Drawing.Color.Gainsboro;
			this.bdrHeader.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrHeader.Location = new global::System.Drawing.Point(0, 144);
			this.bdrHeader.Margin = new global::System.Windows.Forms.Padding(2);
			this.bdrHeader.Name = "bdrHeader";
			this.bdrHeader.Size = new global::System.Drawing.Size(499, 1);
			this.bdrHeader.TabIndex = 12;
			this.pbIcon.Image = global::Bunifu.Licensing.Properties.Resources.bunifu_framework_logo;
			this.pbIcon.Location = new global::System.Drawing.Point(12, 8);
			this.pbIcon.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new global::System.Drawing.Size(21, 22);
			this.pbIcon.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbIcon.TabIndex = 3;
			this.pbIcon.TabStop = false;
			this.pbIcon.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pbIcon.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pbIcon.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.pbClose.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.pbClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClose.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbClose.Image");
			this.pbClose.Location = new global::System.Drawing.Point(465, 10);
			this.pbClose.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new global::System.Drawing.Size(25, 18);
			this.pbClose.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbClose.TabIndex = 4;
			this.pbClose.TabStop = false;
			this.toolTip1.SetToolTip(this.pbClose, "Close (Escape/Enter)");
			this.pbClose.Click += new global::System.EventHandler(this.PbClose_Click);
			this.lblWindowTitle.AutoSize = true;
			this.lblWindowTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblWindowTitle.ForeColor = global::System.Drawing.Color.FromArgb(111, 114, 119);
			this.lblWindowTitle.Location = new global::System.Drawing.Point(34, 9);
			this.lblWindowTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWindowTitle.Name = "lblWindowTitle";
			this.lblWindowTitle.Size = new global::System.Drawing.Size(124, 20);
			this.lblWindowTitle.TabIndex = 50;
			this.lblWindowTitle.Text = "License Activated";
			this.lblWindowTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblWindowTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblWindowTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.lblDescription.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.lblDescription.AutoSize = true;
			this.lblDescription.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblDescription.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblDescription.Location = new global::System.Drawing.Point(70, 116);
			this.lblDescription.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new global::System.Drawing.Size(358, 20);
			this.lblDescription.TabIndex = 6;
			this.lblDescription.Text = "Your license was successfully activated for this device";
			this.lblDescription.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblDescription.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblDescription.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.lblPurchaseEmailTitle.AutoSize = true;
			this.lblPurchaseEmailTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblPurchaseEmailTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblPurchaseEmailTitle.Location = new global::System.Drawing.Point(31, 228);
			this.lblPurchaseEmailTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblPurchaseEmailTitle.Name = "lblPurchaseEmailTitle";
			this.lblPurchaseEmailTitle.Size = new global::System.Drawing.Size(111, 20);
			this.lblPurchaseEmailTitle.TabIndex = 14;
			this.lblPurchaseEmailTitle.Text = "Purchase Email:";
			this.lblPurchaseEmail.AutoSize = true;
			this.lblPurchaseEmail.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblPurchaseEmail.ForeColor = global::System.Drawing.Color.Black;
			this.lblPurchaseEmail.Location = new global::System.Drawing.Point(159, 228);
			this.lblPurchaseEmail.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblPurchaseEmail.Name = "lblPurchaseEmail";
			this.lblPurchaseEmail.Size = new global::System.Drawing.Size(0, 20);
			this.lblPurchaseEmail.TabIndex = 15;
			this.lblLicenseKey.AutoSize = true;
			this.lblLicenseKey.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLicenseKey.ForeColor = global::System.Drawing.Color.Black;
			this.lblLicenseKey.Location = new global::System.Drawing.Point(159, 249);
			this.lblLicenseKey.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLicenseKey.Name = "lblLicenseKey";
			this.lblLicenseKey.Size = new global::System.Drawing.Size(0, 20);
			this.lblLicenseKey.TabIndex = 17;
			this.lblLicenseKeyTitle.AutoSize = true;
			this.lblLicenseKeyTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLicenseKeyTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblLicenseKeyTitle.Location = new global::System.Drawing.Point(31, 249);
			this.lblLicenseKeyTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLicenseKeyTitle.Name = "lblLicenseKeyTitle";
			this.lblLicenseKeyTitle.Size = new global::System.Drawing.Size(88, 20);
			this.lblLicenseKeyTitle.TabIndex = 16;
			this.lblLicenseKeyTitle.Text = "License Key:";
			this.lblProductName.AutoSize = true;
			this.lblProductName.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold);
			this.lblProductName.ForeColor = global::System.Drawing.Color.Black;
			this.lblProductName.Location = new global::System.Drawing.Point(159, 165);
			this.lblProductName.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new global::System.Drawing.Size(0, 20);
			this.lblProductName.TabIndex = 19;
			this.lblProductTitle.AutoSize = true;
			this.lblProductTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblProductTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblProductTitle.Location = new global::System.Drawing.Point(31, 165);
			this.lblProductTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblProductTitle.Name = "lblProductTitle";
			this.lblProductTitle.Size = new global::System.Drawing.Size(63, 20);
			this.lblProductTitle.TabIndex = 18;
			this.lblProductTitle.Text = "Product:";
			this.lblActivations.AutoSize = true;
			this.lblActivations.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblActivations.ForeColor = global::System.Drawing.Color.Black;
			this.lblActivations.Location = new global::System.Drawing.Point(159, 270);
			this.lblActivations.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblActivations.Name = "lblActivations";
			this.lblActivations.Size = new global::System.Drawing.Size(0, 20);
			this.lblActivations.TabIndex = 21;
			this.lblActivationsTitle.AutoSize = true;
			this.lblActivationsTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblActivationsTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblActivationsTitle.Location = new global::System.Drawing.Point(31, 270);
			this.lblActivationsTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblActivationsTitle.Name = "lblActivationsTitle";
			this.lblActivationsTitle.Size = new global::System.Drawing.Size(85, 20);
			this.lblActivationsTitle.TabIndex = 20;
			this.lblActivationsTitle.Text = "Activations:";
			this.lblExpiryDate.AutoSize = true;
			this.lblExpiryDate.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblExpiryDate.ForeColor = global::System.Drawing.Color.Black;
			this.lblExpiryDate.Location = new global::System.Drawing.Point(159, 312);
			this.lblExpiryDate.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblExpiryDate.Name = "lblExpiryDate";
			this.lblExpiryDate.Size = new global::System.Drawing.Size(0, 20);
			this.lblExpiryDate.TabIndex = 23;
			this.lblExpiryDateTitle.AutoSize = true;
			this.lblExpiryDateTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblExpiryDateTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblExpiryDateTitle.Location = new global::System.Drawing.Point(31, 312);
			this.lblExpiryDateTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblExpiryDateTitle.Name = "lblExpiryDateTitle";
			this.lblExpiryDateTitle.Size = new global::System.Drawing.Size(88, 20);
			this.lblExpiryDateTitle.TabIndex = 22;
			this.lblExpiryDateTitle.Text = "Expiry Date:";
			this.lblRemainingDays.AutoSize = true;
			this.lblRemainingDays.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblRemainingDays.ForeColor = global::System.Drawing.Color.Black;
			this.lblRemainingDays.Location = new global::System.Drawing.Point(159, 332);
			this.lblRemainingDays.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblRemainingDays.Name = "lblRemainingDays";
			this.lblRemainingDays.Size = new global::System.Drawing.Size(0, 20);
			this.lblRemainingDays.TabIndex = 25;
			this.lblRemainingDaysTitle.AutoSize = true;
			this.lblRemainingDaysTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblRemainingDaysTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblRemainingDaysTitle.Location = new global::System.Drawing.Point(31, 332);
			this.lblRemainingDaysTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblRemainingDaysTitle.Name = "lblRemainingDaysTitle";
			this.lblRemainingDaysTitle.Size = new global::System.Drawing.Size(119, 20);
			this.lblRemainingDaysTitle.TabIndex = 24;
			this.lblRemainingDaysTitle.Text = "Remaining Days:";
			this.btnClose.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnClose.BackColor = global::System.Drawing.Color.DodgerBlue;
			this.btnClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnClose.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = global::System.Drawing.Color.DodgerBlue;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnClose.ForeColor = global::System.Drawing.Color.White;
			this.btnClose.Location = new global::System.Drawing.Point(392, 12);
			this.btnClose.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(95, 35);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.toolTip1.SetToolTip(this.btnClose, "Close (Escape/Enter)");
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.BtnClose_Click);
			this.pnlFooter.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pnlFooter.Controls.Add(this.bdrBottom);
			this.pnlFooter.Controls.Add(this.bdrBottomLeft);
			this.pnlFooter.Controls.Add(this.bdrBottomRight);
			this.pnlFooter.Controls.Add(this.lblBullet2);
			this.pnlFooter.Controls.Add(this.lnkRenew);
			this.pnlFooter.Controls.Add(this.brdFooterSeparator);
			this.pnlFooter.Controls.Add(this.btnClose);
			this.pnlFooter.Controls.Add(this.lblBullet1);
			this.pnlFooter.Controls.Add(this.lnkSupport);
			this.pnlFooter.Controls.Add(this.lnkHome);
			this.pnlFooter.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.pnlFooter.Location = new global::System.Drawing.Point(0, 507);
			this.pnlFooter.Margin = new global::System.Windows.Forms.Padding(2);
			this.pnlFooter.Name = "pnlFooter";
			this.pnlFooter.Size = new global::System.Drawing.Size(499, 58);
			this.pnlFooter.TabIndex = 27;
			this.bdrBottom.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrBottom.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottom.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottom.Location = new global::System.Drawing.Point(1, 57);
			this.bdrBottom.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottom.Name = "bdrBottom";
			this.bdrBottom.Size = new global::System.Drawing.Size(497, 1);
			this.bdrBottom.TabIndex = 44;
			this.bdrBottomLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottomLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrBottomLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottomLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottomLeft.Location = new global::System.Drawing.Point(0, 1);
			this.bdrBottomLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottomLeft.Name = "bdrBottomLeft";
			this.bdrBottomLeft.Size = new global::System.Drawing.Size(1, 57);
			this.bdrBottomLeft.TabIndex = 43;
			this.bdrBottomRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottomRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrBottomRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottomRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottomRight.Location = new global::System.Drawing.Point(498, 1);
			this.bdrBottomRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottomRight.Name = "bdrBottomRight";
			this.bdrBottomRight.Size = new global::System.Drawing.Size(1, 57);
			this.bdrBottomRight.TabIndex = 42;
			this.lblBullet2.AutoSize = true;
			this.lblBullet2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblBullet2.ForeColor = global::System.Drawing.Color.DarkGray;
			this.lblBullet2.Location = new global::System.Drawing.Point(138, 18);
			this.lblBullet2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblBullet2.Name = "lblBullet2";
			this.lblBullet2.Size = new global::System.Drawing.Size(15, 20);
			this.lblBullet2.TabIndex = 28;
			this.lblBullet2.Text = "•";
			this.lnkRenew.AutoSize = true;
			this.lnkRenew.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkRenew.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkRenew.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkRenew.Location = new global::System.Drawing.Point(150, 18);
			this.lnkRenew.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkRenew.Name = "lnkRenew";
			this.lnkRenew.Size = new global::System.Drawing.Size(53, 20);
			this.lnkRenew.TabIndex = 27;
			this.lnkRenew.TabStop = true;
			this.lnkRenew.Text = "Renew";
			this.toolTip1.SetToolTip(this.lnkRenew, "Renew your license(s)");
			this.lnkRenew.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkRenew_LinkClicked);
			this.brdFooterSeparator.BackColor = global::System.Drawing.Color.Gainsboro;
			this.brdFooterSeparator.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.brdFooterSeparator.Location = new global::System.Drawing.Point(0, 0);
			this.brdFooterSeparator.Margin = new global::System.Windows.Forms.Padding(2);
			this.brdFooterSeparator.Name = "brdFooterSeparator";
			this.brdFooterSeparator.Size = new global::System.Drawing.Size(499, 1);
			this.brdFooterSeparator.TabIndex = 19;
			this.lblBullet1.AutoSize = true;
			this.lblBullet1.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblBullet1.ForeColor = global::System.Drawing.Color.DarkGray;
			this.lblBullet1.Location = new global::System.Drawing.Point(64, 18);
			this.lblBullet1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblBullet1.Name = "lblBullet1";
			this.lblBullet1.Size = new global::System.Drawing.Size(15, 20);
			this.lblBullet1.TabIndex = 18;
			this.lblBullet1.Text = "•";
			this.lnkSupport.AutoSize = true;
			this.lnkSupport.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkSupport.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkSupport.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkSupport.Location = new global::System.Drawing.Point(78, 18);
			this.lnkSupport.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkSupport.Name = "lnkSupport";
			this.lnkSupport.Size = new global::System.Drawing.Size(62, 20);
			this.lnkSupport.TabIndex = 4;
			this.lnkSupport.TabStop = true;
			this.lnkSupport.Text = "Support";
			this.toolTip1.SetToolTip(this.lnkSupport, "Visit the customer support page");
			this.lnkSupport.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSupport_LinkClicked);
			this.lnkHome.AutoSize = true;
			this.lnkHome.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkHome.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkHome.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkHome.Location = new global::System.Drawing.Point(16, 18);
			this.lnkHome.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkHome.Name = "lnkHome";
			this.lnkHome.Size = new global::System.Drawing.Size(50, 20);
			this.lnkHome.TabIndex = 5;
			this.lnkHome.TabStop = true;
			this.lnkHome.Text = "Home";
			this.toolTip1.SetToolTip(this.lnkHome, "Visit Bunifu Framework homepage");
			this.lnkHome.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkHome_LinkClicked);
			this.lnkViewLicenseFile.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.lnkViewLicenseFile.AutoEllipsis = true;
			this.lnkViewLicenseFile.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lnkViewLicenseFile.LinkBehavior = global::System.Windows.Forms.LinkBehavior.AlwaysUnderline;
			this.lnkViewLicenseFile.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkViewLicenseFile.Location = new global::System.Drawing.Point(31, 479);
			this.lnkViewLicenseFile.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkViewLicenseFile.Name = "lnkViewLicenseFile";
			this.lnkViewLicenseFile.Size = new global::System.Drawing.Size(309, 19);
			this.lnkViewLicenseFile.TabIndex = 30;
			this.lnkViewLicenseFile.TabStop = true;
			this.lnkViewLicenseFile.Text = "Navigate to my license details file...";
			this.lnkViewLicenseFile.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkViewLicenseFile_LinkClicked);
			this.lblLicenseType.AutoSize = true;
			this.lblLicenseType.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLicenseType.ForeColor = global::System.Drawing.Color.Black;
			this.lblLicenseType.Location = new global::System.Drawing.Point(159, 208);
			this.lblLicenseType.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLicenseType.Name = "lblLicenseType";
			this.lblLicenseType.Size = new global::System.Drawing.Size(0, 20);
			this.lblLicenseType.TabIndex = 29;
			this.lblLicenseTypeTitle.AutoSize = true;
			this.lblLicenseTypeTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblLicenseTypeTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblLicenseTypeTitle.Location = new global::System.Drawing.Point(31, 208);
			this.lblLicenseTypeTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblLicenseTypeTitle.Name = "lblLicenseTypeTitle";
			this.lblLicenseTypeTitle.Size = new global::System.Drawing.Size(95, 20);
			this.lblLicenseTypeTitle.TabIndex = 28;
			this.lblLicenseTypeTitle.Text = "License Type:";
			this.bdrMidRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrMidRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrMidRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidRight.Location = new global::System.Drawing.Point(498, 145);
			this.bdrMidRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrMidRight.Name = "bdrMidRight";
			this.bdrMidRight.Size = new global::System.Drawing.Size(1, 362);
			this.bdrMidRight.TabIndex = 42;
			this.bdrMidLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrMidLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrMidLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidLeft.Location = new global::System.Drawing.Point(0, 145);
			this.bdrMidLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrMidLeft.Name = "bdrMidLeft";
			this.bdrMidLeft.Size = new global::System.Drawing.Size(1, 362);
			this.bdrMidLeft.TabIndex = 43;
			this.lblPlanName.AutoSize = true;
			this.lblPlanName.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold);
			this.lblPlanName.ForeColor = global::System.Drawing.Color.Black;
			this.lblPlanName.Location = new global::System.Drawing.Point(159, 186);
			this.lblPlanName.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblPlanName.Name = "lblPlanName";
			this.lblPlanName.Size = new global::System.Drawing.Size(0, 20);
			this.lblPlanName.TabIndex = 45;
			this.lblPlanTitle.AutoSize = true;
			this.lblPlanTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblPlanTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblPlanTitle.Location = new global::System.Drawing.Point(31, 186);
			this.lblPlanTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblPlanTitle.Name = "lblPlanTitle";
			this.lblPlanTitle.Size = new global::System.Drawing.Size(111, 20);
			this.lblPlanTitle.TabIndex = 44;
			this.lblPlanTitle.Text = "Plan Purchased:";
			this.lblRemainingDevices.AutoSize = true;
			this.lblRemainingDevices.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblRemainingDevices.ForeColor = global::System.Drawing.Color.Black;
			this.lblRemainingDevices.Location = new global::System.Drawing.Point(159, 291);
			this.lblRemainingDevices.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblRemainingDevices.Name = "lblRemainingDevices";
			this.lblRemainingDevices.Size = new global::System.Drawing.Size(0, 20);
			this.lblRemainingDevices.TabIndex = 50;
			this.lblRemainingDevicesTitle.AutoSize = true;
			this.lblRemainingDevicesTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblRemainingDevicesTitle.ForeColor = global::System.Drawing.Color.DimGray;
			this.lblRemainingDevicesTitle.Location = new global::System.Drawing.Point(31, 291);
			this.lblRemainingDevicesTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblRemainingDevicesTitle.Name = "lblRemainingDevicesTitle";
			this.lblRemainingDevicesTitle.Size = new global::System.Drawing.Size(83, 20);
			this.lblRemainingDevicesTitle.TabIndex = 49;
			this.lblRemainingDevicesTitle.Text = "Remaining:";
			this.ctaAlert.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.ctaAlert.BackColor = global::System.Drawing.Color.FromArgb(255, 251, 230);
			this.ctaAlert.Hidden = false;
			this.ctaAlert.Location = new global::System.Drawing.Point(31, 368);
			this.ctaAlert.Margin = new global::System.Windows.Forms.Padding(2);
			this.ctaAlert.MinimumSize = new global::System.Drawing.Size(0, 105);
			this.ctaAlert.Name = "ctaAlert";
			this.ctaAlert.Size = new global::System.Drawing.Size(436, 105);
			this.ctaAlert.TabIndex = 48;
			base.AcceptButton = this.btnClose;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(499, 565);
			base.Controls.Add(this.lblRemainingDevices);
			base.Controls.Add(this.lblRemainingDevicesTitle);
			base.Controls.Add(this.lblPlanName);
			base.Controls.Add(this.lblPlanTitle);
			base.Controls.Add(this.bdrMidLeft);
			base.Controls.Add(this.bdrMidRight);
			base.Controls.Add(this.lnkViewLicenseFile);
			base.Controls.Add(this.lblLicenseType);
			base.Controls.Add(this.lblLicenseTypeTitle);
			base.Controls.Add(this.pnlFooter);
			base.Controls.Add(this.lblRemainingDays);
			base.Controls.Add(this.lblRemainingDaysTitle);
			base.Controls.Add(this.lblExpiryDate);
			base.Controls.Add(this.lblExpiryDateTitle);
			base.Controls.Add(this.lblActivations);
			base.Controls.Add(this.lblActivationsTitle);
			base.Controls.Add(this.lblProductName);
			base.Controls.Add(this.lblProductTitle);
			base.Controls.Add(this.lblLicenseKey);
			base.Controls.Add(this.lblLicenseKeyTitle);
			base.Controls.Add(this.lblPurchaseEmail);
			base.Controls.Add(this.lblPurchaseEmailTitle);
			base.Controls.Add(this.pnlHeader);
			base.Controls.Add(this.ctaAlert);
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "ActivationSuccess";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bunifu Framework: Activation Successful";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.ActivationSuccess_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.ActivationSuccess_KeyDown);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIconLarge).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).EndInit();
			this.pnlFooter.ResumeLayout(false);
			this.pnlFooter.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000018 RID: 24
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Panel pnlHeader;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Label lblDescription;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Label lblTitle;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Panel bdrHeader;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.PictureBox pbIcon;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.PictureBox pbClose;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label lblWindowTitle;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.PictureBox pbIconLarge;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label lblPurchaseEmailTitle;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Label lblPurchaseEmail;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Label lblLicenseKey;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Label lblLicenseKeyTitle;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Label lblProductName;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label lblProductTitle;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Label lblActivations;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Label lblActivationsTitle;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.Label lblExpiryDate;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.Label lblExpiryDateTitle;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Label lblRemainingDays;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Panel brdFooterSeparator;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Label lblBullet1;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.LinkLabel lnkSupport;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.LinkLabel lnkHome;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Label lblBullet2;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.LinkLabel lnkRenew;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Label lblLicenseType;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label lblLicenseTypeTitle;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label bdrTop;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Label bdrRight;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Label bdrBottomRight;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Label bdrMidRight;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Label bdrLeft;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.Label bdrBottomLeft;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Label bdrMidLeft;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Label bdrBottom;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.Label lblPlanName;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.Label lblPlanTitle;

		// Token: 0x04000040 RID: 64
		public global::Bunifu.Licensing.Views.Controls.Alert ctaAlert;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Label lblRemainingDevices;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Label lblRemainingDevicesTitle;

		// Token: 0x04000043 RID: 67
		public global::System.Windows.Forms.Panel pnlFooter;

		// Token: 0x04000044 RID: 68
		public global::System.Windows.Forms.LinkLabel lnkViewLicenseFile;

		// Token: 0x04000045 RID: 69
		public global::System.Windows.Forms.Label lblRemainingDaysTitle;
	}
}
