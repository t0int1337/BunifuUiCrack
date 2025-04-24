namespace Bunifu.Licensing.Views
{
	// Token: 0x02000008 RID: 8
	//global::System.Diagnostics.DebuggerStepThrough]
	internal partial class InformationBoxEx : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x0000BB7C File Offset: 0x00009D7C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000BBB4 File Offset: 0x00009DB4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Bunifu.Licensing.Views.InformationBoxEx));
			this.pnlHeader = new global::System.Windows.Forms.Panel();
			this.btnCopyRequestCode = new global::System.Windows.Forms.Button();
			this.btnPasteActivationCode = new global::System.Windows.Forms.Button();
			this.lblDescription = new global::System.Windows.Forms.Label();
			this.lblTitle = new global::System.Windows.Forms.Label();
			this.bdrLeft = new global::System.Windows.Forms.Label();
			this.bdrRight = new global::System.Windows.Forms.Label();
			this.bdrTop = new global::System.Windows.Forms.Label();
			this.bdrHeader = new global::System.Windows.Forms.Panel();
			this.pbIcon = new global::System.Windows.Forms.PictureBox();
			this.pbClose = new global::System.Windows.Forms.PictureBox();
			this.lblWindowTitle = new global::System.Windows.Forms.Label();
			this.lblMessageInfo = new global::System.Windows.Forms.Label();
			this.btnActivate = new global::System.Windows.Forms.Button();
			this.pblFooter = new global::System.Windows.Forms.Panel();
			this.btnSaveRQ = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.bdrBottom = new global::System.Windows.Forms.Label();
			this.bdrBottomLeft = new global::System.Windows.Forms.Label();
			this.bdrBottomRight = new global::System.Windows.Forms.Label();
			this.brdFooterSeparator = new global::System.Windows.Forms.Panel();
			this.toolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.bdrMidRight = new global::System.Windows.Forms.Label();
			this.bdrMidLeft = new global::System.Windows.Forms.Label();
			this.splitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.lblRequestCode = new global::System.Windows.Forms.Label();
			this.txtRequestCode = new global::System.Windows.Forms.TextBox();
			this.bdrMidSeparator = new global::System.Windows.Forms.Panel();
			this.lblActivationCode = new global::System.Windows.Forms.Label();
			this.pnlBrowseForCode = new global::System.Windows.Forms.Panel();
			this.lblActivationCodeFile = new global::System.Windows.Forms.Label();
			this.lblActivationCodeTitle = new global::System.Windows.Forms.Label();
			this.lblTitleBrowseForCode = new global::System.Windows.Forms.Label();
			this.lblTextBrowseForCode = new global::System.Windows.Forms.Label();
			this.pbBrowseForCode = new global::System.Windows.Forms.PictureBox();
			this.boxBrowseForCode = new global::Bunifu.Licensing.Views.Controls.Box();
			this.txtActivationCode = new global::System.Windows.Forms.TextBox();
			this.tmrMessageTimer = new global::System.Windows.Forms.Timer(this.components);
			this.pnlHeader.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).BeginInit();
			this.pblFooter.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.pnlBrowseForCode.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbBrowseForCode).BeginInit();
			base.SuspendLayout();
			this.pnlHeader.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pnlHeader.Controls.Add(this.btnCopyRequestCode);
			this.pnlHeader.Controls.Add(this.btnPasteActivationCode);
			this.pnlHeader.Controls.Add(this.lblDescription);
			this.pnlHeader.Controls.Add(this.lblTitle);
			this.pnlHeader.Controls.Add(this.bdrLeft);
			this.pnlHeader.Controls.Add(this.bdrRight);
			this.pnlHeader.Controls.Add(this.bdrTop);
			this.pnlHeader.Controls.Add(this.bdrHeader);
			this.pnlHeader.Controls.Add(this.pbIcon);
			this.pnlHeader.Controls.Add(this.pbClose);
			this.pnlHeader.Controls.Add(this.lblWindowTitle);
			this.pnlHeader.Controls.Add(this.lblMessageInfo);
			this.pnlHeader.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new global::System.Drawing.Point(0, 0);
			this.pnlHeader.Margin = new global::System.Windows.Forms.Padding(2);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new global::System.Drawing.Size(931, 115);
			this.pnlHeader.TabIndex = 3;
			this.pnlHeader.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pnlHeader.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pnlHeader.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.btnCopyRequestCode.Anchor = global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCopyRequestCode.BackColor = global::System.Drawing.Color.Gainsboro;
			this.btnCopyRequestCode.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnCopyRequestCode.FlatAppearance.BorderColor = global::System.Drawing.Color.Gainsboro;
			this.btnCopyRequestCode.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCopyRequestCode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnCopyRequestCode.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.btnCopyRequestCode.Location = new global::System.Drawing.Point(629, 74);
			this.btnCopyRequestCode.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnCopyRequestCode.Name = "btnCopyRequestCode";
			this.btnCopyRequestCode.Size = new global::System.Drawing.Size(140, 34);
			this.btnCopyRequestCode.TabIndex = 56;
			this.btnCopyRequestCode.Text = "Copy Request Code";
			this.toolTip.SetToolTip(this.btnCopyRequestCode, "Copy your generated request code to the clipboard...");
			this.btnCopyRequestCode.UseVisualStyleBackColor = false;
			this.btnCopyRequestCode.Click += new global::System.EventHandler(this.btnCopyRQ_Click);
			this.btnPasteActivationCode.Anchor = global::System.Windows.Forms.AnchorStyles.Right;
			this.btnPasteActivationCode.BackColor = global::System.Drawing.Color.Silver;
			this.btnPasteActivationCode.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnPasteActivationCode.FlatAppearance.BorderColor = global::System.Drawing.Color.Silver;
			this.btnPasteActivationCode.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnPasteActivationCode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnPasteActivationCode.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.btnPasteActivationCode.Location = new global::System.Drawing.Point(768, 74);
			this.btnPasteActivationCode.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnPasteActivationCode.Name = "btnPasteActivationCode";
			this.btnPasteActivationCode.Size = new global::System.Drawing.Size(154, 34);
			this.btnPasteActivationCode.TabIndex = 47;
			this.btnPasteActivationCode.Text = "Paste Activation Code";
			this.toolTip.SetToolTip(this.btnPasteActivationCode, "Paste the activation code you received from Bunifu...");
			this.btnPasteActivationCode.UseVisualStyleBackColor = false;
			this.btnPasteActivationCode.Click += new global::System.EventHandler(this.btnPasteAC_Click);
			this.lblDescription.AutoSize = true;
			this.lblDescription.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblDescription.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblDescription.Location = new global::System.Drawing.Point(16, 79);
			this.lblDescription.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new global::System.Drawing.Size(446, 20);
			this.lblDescription.TabIndex = 55;
			this.lblDescription.Text = "Please follow the split-view guidelines below for offline activation";
			this.lblDescription.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblDescription.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblDescription.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new global::System.Drawing.Font("Segoe UI", 15.75f);
			this.lblTitle.ForeColor = global::System.Drawing.Color.Black;
			this.lblTitle.Location = new global::System.Drawing.Point(15, 42);
			this.lblTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new global::System.Drawing.Size(329, 37);
			this.lblTitle.TabIndex = 54;
			this.lblTitle.Text = "Activate Bunifu UI (Offline)";
			this.lblTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.bdrLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrLeft.Location = new global::System.Drawing.Point(0, 1);
			this.bdrLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrLeft.Name = "bdrLeft";
			this.bdrLeft.Size = new global::System.Drawing.Size(1, 113);
			this.bdrLeft.TabIndex = 53;
			this.bdrRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrRight.Location = new global::System.Drawing.Point(930, 1);
			this.bdrRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrRight.Name = "bdrRight";
			this.bdrRight.Size = new global::System.Drawing.Size(1, 113);
			this.bdrRight.TabIndex = 52;
			this.bdrTop.BackColor = global::System.Drawing.Color.Silver;
			this.bdrTop.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.bdrTop.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrTop.ForeColor = global::System.Drawing.Color.Black;
			this.bdrTop.Location = new global::System.Drawing.Point(0, 0);
			this.bdrTop.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrTop.Name = "bdrTop";
			this.bdrTop.Size = new global::System.Drawing.Size(931, 1);
			this.bdrTop.TabIndex = 51;
			this.bdrHeader.BackColor = global::System.Drawing.Color.Gainsboro;
			this.bdrHeader.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrHeader.Location = new global::System.Drawing.Point(0, 114);
			this.bdrHeader.Margin = new global::System.Windows.Forms.Padding(2);
			this.bdrHeader.Name = "bdrHeader";
			this.bdrHeader.Size = new global::System.Drawing.Size(931, 1);
			this.bdrHeader.TabIndex = 12;
			this.pbIcon.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbIcon.Image");
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
			this.pbClose.Location = new global::System.Drawing.Point(896, 10);
			this.pbClose.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new global::System.Drawing.Size(25, 18);
			this.pbClose.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbClose.TabIndex = 4;
			this.pbClose.TabStop = false;
			this.toolTip.SetToolTip(this.pbClose, "Close");
			this.pbClose.Click += new global::System.EventHandler(this.pbClose_Click);
			this.lblWindowTitle.AutoSize = true;
			this.lblWindowTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblWindowTitle.ForeColor = global::System.Drawing.Color.FromArgb(111, 114, 119);
			this.lblWindowTitle.Location = new global::System.Drawing.Point(34, 10);
			this.lblWindowTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWindowTitle.Name = "lblWindowTitle";
			this.lblWindowTitle.Size = new global::System.Drawing.Size(125, 20);
			this.lblWindowTitle.TabIndex = 50;
			this.lblWindowTitle.Text = "Offline Activation";
			this.lblWindowTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblWindowTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblWindowTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.lblMessageInfo.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.lblMessageInfo.AutoEllipsis = true;
			this.lblMessageInfo.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblMessageInfo.ForeColor = global::System.Drawing.Color.WhiteSmoke;
			this.lblMessageInfo.Location = new global::System.Drawing.Point(514, 46);
			this.lblMessageInfo.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblMessageInfo.Name = "lblMessageInfo";
			this.lblMessageInfo.Size = new global::System.Drawing.Size(406, 21);
			this.lblMessageInfo.TabIndex = 57;
			this.lblMessageInfo.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnActivate.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnActivate.BackColor = global::System.Drawing.Color.DodgerBlue;
			this.btnActivate.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnActivate.FlatAppearance.BorderColor = global::System.Drawing.Color.DodgerBlue;
			this.btnActivate.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnActivate.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnActivate.ForeColor = global::System.Drawing.Color.White;
			this.btnActivate.Location = new global::System.Drawing.Point(790, 11);
			this.btnActivate.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnActivate.Name = "btnActivate";
			this.btnActivate.Size = new global::System.Drawing.Size(129, 37);
			this.btnActivate.TabIndex = 0;
			this.btnActivate.Text = "Activate";
			this.toolTip.SetToolTip(this.btnActivate, "Activate your license offline");
			this.btnActivate.UseVisualStyleBackColor = false;
			this.btnActivate.Click += new global::System.EventHandler(this.btnActivate_Click);
			this.pblFooter.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pblFooter.Controls.Add(this.btnSaveRQ);
			this.pblFooter.Controls.Add(this.btnCancel);
			this.pblFooter.Controls.Add(this.bdrBottom);
			this.pblFooter.Controls.Add(this.bdrBottomLeft);
			this.pblFooter.Controls.Add(this.bdrBottomRight);
			this.pblFooter.Controls.Add(this.brdFooterSeparator);
			this.pblFooter.Controls.Add(this.btnActivate);
			this.pblFooter.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.pblFooter.Location = new global::System.Drawing.Point(0, 490);
			this.pblFooter.Margin = new global::System.Windows.Forms.Padding(2);
			this.pblFooter.Name = "pblFooter";
			this.pblFooter.Size = new global::System.Drawing.Size(931, 58);
			this.pblFooter.TabIndex = 27;
			this.btnSaveRQ.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.btnSaveRQ.BackColor = global::System.Drawing.Color.Gainsboro;
			this.btnSaveRQ.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnSaveRQ.FlatAppearance.BorderColor = global::System.Drawing.Color.Silver;
			this.btnSaveRQ.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnSaveRQ.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnSaveRQ.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.btnSaveRQ.Location = new global::System.Drawing.Point(11, 11);
			this.btnSaveRQ.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnSaveRQ.Name = "btnSaveRQ";
			this.btnSaveRQ.Size = new global::System.Drawing.Size(182, 37);
			this.btnSaveRQ.TabIndex = 46;
			this.btnSaveRQ.Text = "Save Request Code";
			this.toolTip.SetToolTip(this.btnSaveRQ, "This will save your Request Code as a file for sending to Bunifu...");
			this.btnSaveRQ.UseVisualStyleBackColor = false;
			this.btnSaveRQ.Click += new global::System.EventHandler(this.btnSaveRQ_Click);
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.btnCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnCancel.FlatAppearance.BorderColor = global::System.Drawing.Color.LightGray;
			this.btnCancel.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.btnCancel.ForeColor = global::System.Drawing.Color.DimGray;
			this.btnCancel.Location = new global::System.Drawing.Point(655, 11);
			this.btnCancel.Margin = new global::System.Windows.Forms.Padding(2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(129, 37);
			this.btnCancel.TabIndex = 45;
			this.btnCancel.Text = "Cancel";
			this.toolTip.SetToolTip(this.btnCancel, "Cancel offline activation");
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.bdrBottom.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrBottom.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrBottom.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottom.Location = new global::System.Drawing.Point(1, 57);
			this.bdrBottom.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottom.Name = "bdrBottom";
			this.bdrBottom.Size = new global::System.Drawing.Size(929, 1);
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
			this.bdrBottomRight.Location = new global::System.Drawing.Point(930, 1);
			this.bdrBottomRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrBottomRight.Name = "bdrBottomRight";
			this.bdrBottomRight.Size = new global::System.Drawing.Size(1, 57);
			this.bdrBottomRight.TabIndex = 42;
			this.brdFooterSeparator.BackColor = global::System.Drawing.Color.Gainsboro;
			this.brdFooterSeparator.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.brdFooterSeparator.Location = new global::System.Drawing.Point(0, 0);
			this.brdFooterSeparator.Margin = new global::System.Windows.Forms.Padding(2);
			this.brdFooterSeparator.Name = "brdFooterSeparator";
			this.brdFooterSeparator.Size = new global::System.Drawing.Size(931, 1);
			this.brdFooterSeparator.TabIndex = 19;
			this.bdrMidRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrMidRight.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrMidRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidRight.Location = new global::System.Drawing.Point(930, 115);
			this.bdrMidRight.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrMidRight.Name = "bdrMidRight";
			this.bdrMidRight.Size = new global::System.Drawing.Size(1, 375);
			this.bdrMidRight.TabIndex = 42;
			this.bdrMidLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrMidLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bdrMidLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidLeft.Location = new global::System.Drawing.Point(0, 115);
			this.bdrMidLeft.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.bdrMidLeft.Name = "bdrMidLeft";
			this.bdrMidLeft.Size = new global::System.Drawing.Size(1, 375);
			this.bdrMidLeft.TabIndex = 43;
			this.splitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new global::System.Drawing.Point(1, 115);
			this.splitContainer1.Margin = new global::System.Windows.Forms.Padding(2);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.lblRequestCode);
			this.splitContainer1.Panel1.Controls.Add(this.txtRequestCode);
			this.splitContainer1.Panel1.Controls.Add(this.bdrMidSeparator);
			this.splitContainer1.Panel2.Controls.Add(this.lblActivationCode);
			this.splitContainer1.Panel2.Controls.Add(this.pnlBrowseForCode);
			this.splitContainer1.Panel2.Controls.Add(this.txtActivationCode);
			this.splitContainer1.Size = new global::System.Drawing.Size(929, 375);
			this.splitContainer1.SplitterDistance = 417;
			this.splitContainer1.TabIndex = 44;
			this.lblRequestCode.AutoSize = true;
			this.lblRequestCode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblRequestCode.ForeColor = global::System.Drawing.Color.Black;
			this.lblRequestCode.Location = new global::System.Drawing.Point(11, 12);
			this.lblRequestCode.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblRequestCode.Name = "lblRequestCode";
			this.lblRequestCode.Size = new global::System.Drawing.Size(361, 20);
			this.lblRequestCode.TabIndex = 48;
			this.lblRequestCode.Text = "Submit the Request Code generated below to Bunifu:";
			this.txtRequestCode.AcceptsReturn = true;
			this.txtRequestCode.AcceptsTab = true;
			this.txtRequestCode.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtRequestCode.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.Append;
			this.txtRequestCode.BackColor = global::System.Drawing.Color.White;
			this.txtRequestCode.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtRequestCode.Font = new global::System.Drawing.Font("Consolas", 11.25f, global::System.Drawing.FontStyle.Bold);
			this.txtRequestCode.ForeColor = global::System.Drawing.Color.Black;
			this.txtRequestCode.Location = new global::System.Drawing.Point(14, 40);
			this.txtRequestCode.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtRequestCode.MaxLength = 65536;
			this.txtRequestCode.Multiline = true;
			this.txtRequestCode.Name = "txtRequestCode";
			this.txtRequestCode.ReadOnly = true;
			this.txtRequestCode.Size = new global::System.Drawing.Size(389, 321);
			this.txtRequestCode.TabIndex = 47;
			this.bdrMidSeparator.BackColor = global::System.Drawing.Color.Gainsboro;
			this.bdrMidSeparator.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrMidSeparator.Location = new global::System.Drawing.Point(416, 0);
			this.bdrMidSeparator.Margin = new global::System.Windows.Forms.Padding(2);
			this.bdrMidSeparator.Name = "bdrMidSeparator";
			this.bdrMidSeparator.Size = new global::System.Drawing.Size(1, 375);
			this.bdrMidSeparator.TabIndex = 45;
			this.lblActivationCode.AutoSize = true;
			this.lblActivationCode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblActivationCode.ForeColor = global::System.Drawing.Color.Black;
			this.lblActivationCode.Location = new global::System.Drawing.Point(12, 12);
			this.lblActivationCode.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblActivationCode.Name = "lblActivationCode";
			this.lblActivationCode.Size = new global::System.Drawing.Size(440, 20);
			this.lblActivationCode.TabIndex = 49;
			this.lblActivationCode.Text = "Paste the Activation Code you received below and click 'Activate':";
			this.pnlBrowseForCode.Controls.Add(this.lblActivationCodeFile);
			this.pnlBrowseForCode.Controls.Add(this.lblActivationCodeTitle);
			this.pnlBrowseForCode.Controls.Add(this.lblTitleBrowseForCode);
			this.pnlBrowseForCode.Controls.Add(this.lblTextBrowseForCode);
			this.pnlBrowseForCode.Controls.Add(this.pbBrowseForCode);
			this.pnlBrowseForCode.Controls.Add(this.boxBrowseForCode);
			this.pnlBrowseForCode.Location = new global::System.Drawing.Point(18, 98);
			this.pnlBrowseForCode.Margin = new global::System.Windows.Forms.Padding(2);
			this.pnlBrowseForCode.Name = "pnlBrowseForCode";
			this.pnlBrowseForCode.Size = new global::System.Drawing.Size(470, 169);
			this.pnlBrowseForCode.TabIndex = 59;
			this.lblActivationCodeFile.AutoSize = true;
			this.lblActivationCodeFile.BackColor = global::System.Drawing.Color.FromArgb(250, 250, 250);
			this.lblActivationCodeFile.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblActivationCodeFile.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold);
			this.lblActivationCodeFile.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.lblActivationCodeFile.Location = new global::System.Drawing.Point(145, 128);
			this.lblActivationCodeFile.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblActivationCodeFile.Name = "lblActivationCodeFile";
			this.lblActivationCodeFile.Size = new global::System.Drawing.Size(21, 20);
			this.lblActivationCodeFile.TabIndex = 62;
			this.lblActivationCodeFile.Text = "...";
			this.lblActivationCodeFile.Visible = false;
			this.lblActivationCodeFile.Click += new global::System.EventHandler(this.btnBrowseAC_Click);
			this.lblActivationCodeTitle.AutoSize = true;
			this.lblActivationCodeTitle.BackColor = global::System.Drawing.Color.FromArgb(250, 250, 250);
			this.lblActivationCodeTitle.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblActivationCodeTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblActivationCodeTitle.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.lblActivationCodeTitle.Location = new global::System.Drawing.Point(21, 128);
			this.lblActivationCodeTitle.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblActivationCodeTitle.Name = "lblActivationCodeTitle";
			this.lblActivationCodeTitle.Size = new global::System.Drawing.Size(118, 20);
			this.lblActivationCodeTitle.TabIndex = 61;
			this.lblActivationCodeTitle.Text = "Activation Code:";
			this.lblActivationCodeTitle.Visible = false;
			this.lblActivationCodeTitle.Click += new global::System.EventHandler(this.btnBrowseAC_Click);
			this.lblTitleBrowseForCode.AutoSize = true;
			this.lblTitleBrowseForCode.BackColor = global::System.Drawing.Color.FromArgb(250, 250, 250);
			this.lblTitleBrowseForCode.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblTitleBrowseForCode.Font = new global::System.Drawing.Font("Segoe UI Semibold", 11.25f, global::System.Drawing.FontStyle.Bold);
			this.lblTitleBrowseForCode.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.lblTitleBrowseForCode.Location = new global::System.Drawing.Point(78, 80);
			this.lblTitleBrowseForCode.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTitleBrowseForCode.Name = "lblTitleBrowseForCode";
			this.lblTitleBrowseForCode.Size = new global::System.Drawing.Size(316, 25);
			this.lblTitleBrowseForCode.TabIndex = 49;
			this.lblTitleBrowseForCode.Text = "Browse for received activation code";
			this.lblTitleBrowseForCode.Click += new global::System.EventHandler(this.btnBrowseAC_Click);
			this.lblTextBrowseForCode.AutoSize = true;
			this.lblTextBrowseForCode.BackColor = global::System.Drawing.Color.FromArgb(250, 250, 250);
			this.lblTextBrowseForCode.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.lblTextBrowseForCode.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.lblTextBrowseForCode.ForeColor = global::System.Drawing.Color.Black;
			this.lblTextBrowseForCode.Location = new global::System.Drawing.Point(21, 102);
			this.lblTextBrowseForCode.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTextBrowseForCode.Name = "lblTextBrowseForCode";
			this.lblTextBrowseForCode.Size = new global::System.Drawing.Size(429, 20);
			this.lblTextBrowseForCode.TabIndex = 60;
			this.lblTextBrowseForCode.Text = "Browse for the Activation Code you received and click 'Activate'";
			this.lblTextBrowseForCode.Click += new global::System.EventHandler(this.btnBrowseAC_Click);
			this.pbBrowseForCode.BackColor = global::System.Drawing.Color.FromArgb(250, 250, 250);
			this.pbBrowseForCode.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbBrowseForCode.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbBrowseForCode.Image");
			this.pbBrowseForCode.Location = new global::System.Drawing.Point(202, 26);
			this.pbBrowseForCode.Margin = new global::System.Windows.Forms.Padding(2);
			this.pbBrowseForCode.Name = "pbBrowseForCode";
			this.pbBrowseForCode.Size = new global::System.Drawing.Size(64, 51);
			this.pbBrowseForCode.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbBrowseForCode.TabIndex = 58;
			this.pbBrowseForCode.TabStop = false;
			this.pbBrowseForCode.Click += new global::System.EventHandler(this.btnBrowseAC_Click);
			this.boxBrowseForCode.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.boxBrowseForCode.BackColor = global::System.Drawing.Color.FromArgb(250, 250, 250);
			this.boxBrowseForCode.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.boxBrowseForCode.ForeColor = global::System.Drawing.Color.DimGray;
			this.boxBrowseForCode.LineColor = global::System.Drawing.Color.DimGray;
			this.boxBrowseForCode.LineStyle = global::Bunifu.Licensing.Views.Controls.Box.LineStyles.Dashed;
			this.boxBrowseForCode.Location = new global::System.Drawing.Point(2, 2);
			this.boxBrowseForCode.Margin = new global::System.Windows.Forms.Padding(2);
			this.boxBrowseForCode.Name = "boxBrowseForCode";
			this.boxBrowseForCode.Size = new global::System.Drawing.Size(464, 162);
			this.boxBrowseForCode.TabIndex = 50;
			this.boxBrowseForCode.Click += new global::System.EventHandler(this.btnBrowseAC_Click);
			this.txtActivationCode.AcceptsReturn = true;
			this.txtActivationCode.AcceptsTab = true;
			this.txtActivationCode.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.txtActivationCode.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.Append;
			this.txtActivationCode.BackColor = global::System.Drawing.Color.White;
			this.txtActivationCode.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.txtActivationCode.Font = new global::System.Drawing.Font("Consolas", 11.25f, global::System.Drawing.FontStyle.Bold);
			this.txtActivationCode.ForeColor = global::System.Drawing.Color.MediumSeaGreen;
			this.txtActivationCode.Location = new global::System.Drawing.Point(14, 40);
			this.txtActivationCode.Margin = new global::System.Windows.Forms.Padding(2);
			this.txtActivationCode.MaxLength = 65536;
			this.txtActivationCode.Multiline = true;
			this.txtActivationCode.Name = "txtActivationCode";
			this.txtActivationCode.Size = new global::System.Drawing.Size(484, 321);
			this.txtActivationCode.TabIndex = 46;
			this.txtActivationCode.Visible = false;
			this.tmrMessageTimer.Interval = 1000;
			this.tmrMessageTimer.Tick += new global::System.EventHandler(this.tmrMessageTimer_Tick);
			base.AcceptButton = this.btnActivate;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(931, 548);
			base.Controls.Add(this.splitContainer1);
			base.Controls.Add(this.bdrMidLeft);
			base.Controls.Add(this.bdrMidRight);
			base.Controls.Add(this.pblFooter);
			base.Controls.Add(this.pnlHeader);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "InformationBoxEx";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bunifu Framework: Activation Successful";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.OnLoad);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).EndInit();
			this.pblFooter.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.pnlBrowseForCode.ResumeLayout(false);
			this.pnlBrowseForCode.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbBrowseForCode).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000084 RID: 132
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.Panel pnlHeader;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Panel bdrHeader;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.PictureBox pbIcon;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.PictureBox pbClose;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label lblWindowTitle;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Button btnActivate;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Panel pblFooter;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Panel brdFooterSeparator;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.ToolTip toolTip;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Label bdrTop;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.Label bdrRight;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Label bdrBottomRight;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Label bdrMidRight;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.Label bdrLeft;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Label bdrBottomLeft;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Label bdrMidLeft;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Label bdrBottom;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.SplitContainer splitContainer1;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Panel bdrMidSeparator;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.TextBox txtActivationCode;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.TextBox txtRequestCode;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.Label lblDescription;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Label lblTitle;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Label lblRequestCode;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Label lblActivationCode;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.Button btnCopyRequestCode;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Button btnPasteActivationCode;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Label lblMessageInfo;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.Timer tmrMessageTimer;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.Button btnSaveRQ;

		// Token: 0x040000A4 RID: 164
		private global::Bunifu.Licensing.Views.Controls.Box boxBrowseForCode;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Panel pnlBrowseForCode;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.PictureBox pbBrowseForCode;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Label lblTitleBrowseForCode;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.Label lblTextBrowseForCode;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Label lblActivationCodeTitle;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Label lblActivationCodeFile;
	}
}
