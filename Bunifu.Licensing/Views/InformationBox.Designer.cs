namespace Bunifu.Licensing.Views
{
	// Token: 0x02000006 RID: 6
	//global::System.Diagnostics.DebuggerStepThrough]
	internal partial class InformationBox : global::System.Windows.Forms.Form
	{
		// Token: 0x0600009E RID: 158 RVA: 0x000098B8 File Offset: 0x00007AB8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000098F0 File Offset: 0x00007AF0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Bunifu.Licensing.Views.InformationBox));
			this.pblFooter = new global::System.Windows.Forms.Panel();
			this.bdrBottom = new global::System.Windows.Forms.Label();
			this.bdrBottomLeft = new global::System.Windows.Forms.Label();
			this.bdrBottomRight = new global::System.Windows.Forms.Label();
			this.lnkMoreInfo = new global::System.Windows.Forms.LinkLabel();
			this.brdFooterSeparator = new global::System.Windows.Forms.Panel();
			this.btnOkay = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.pnlHeader = new global::System.Windows.Forms.Panel();
			this.bdrLeft = new global::System.Windows.Forms.Label();
			this.bdrRight = new global::System.Windows.Forms.Label();
			this.bdrTop = new global::System.Windows.Forms.Label();
			this.bdrHeader = new global::System.Windows.Forms.Panel();
			this.pbClose = new global::System.Windows.Forms.PictureBox();
			this.lblWindowTitle = new global::System.Windows.Forms.Label();
			this.pnlBody = new global::System.Windows.Forms.Panel();
			this.bdrMidLeft = new global::System.Windows.Forms.Label();
			this.bdrMidRight = new global::System.Windows.Forms.Label();
			this.lblMessage = new global::System.Windows.Forms.Label();
			this.pbIcon = new global::System.Windows.Forms.PictureBox();
			this.toolTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.pblFooter.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).BeginInit();
			this.pnlBody.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).BeginInit();
			base.SuspendLayout();
			this.pblFooter.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pblFooter.Controls.Add(this.bdrBottom);
			this.pblFooter.Controls.Add(this.bdrBottomLeft);
			this.pblFooter.Controls.Add(this.bdrBottomRight);
			this.pblFooter.Controls.Add(this.lnkMoreInfo);
			this.pblFooter.Controls.Add(this.brdFooterSeparator);
			this.pblFooter.Controls.Add(this.btnOkay);
			this.pblFooter.Controls.Add(this.btnCancel);
			this.pblFooter.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.pblFooter.Location = new global::System.Drawing.Point(0, 152);
			this.pblFooter.Name = "pblFooter";
			this.pblFooter.Size = new global::System.Drawing.Size(506, 47);
			this.pblFooter.TabIndex = 14;
			this.bdrBottom.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottom.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrBottom.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrBottom.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottom.Location = new global::System.Drawing.Point(1, 46);
			this.bdrBottom.Name = "bdrBottom";
			this.bdrBottom.Size = new global::System.Drawing.Size(504, 1);
			this.bdrBottom.TabIndex = 44;
			this.bdrBottomLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottomLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrBottomLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrBottomLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottomLeft.Location = new global::System.Drawing.Point(0, 1);
			this.bdrBottomLeft.Name = "bdrBottomLeft";
			this.bdrBottomLeft.Size = new global::System.Drawing.Size(1, 46);
			this.bdrBottomLeft.TabIndex = 43;
			this.bdrBottomRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrBottomRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrBottomRight.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrBottomRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrBottomRight.Location = new global::System.Drawing.Point(505, 1);
			this.bdrBottomRight.Name = "bdrBottomRight";
			this.bdrBottomRight.Size = new global::System.Drawing.Size(1, 46);
			this.bdrBottomRight.TabIndex = 42;
			this.lnkMoreInfo.AutoSize = true;
			this.lnkMoreInfo.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.lnkMoreInfo.LinkBehavior = global::System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkMoreInfo.LinkColor = global::System.Drawing.Color.DodgerBlue;
			this.lnkMoreInfo.Location = new global::System.Drawing.Point(12, 13);
			this.lnkMoreInfo.Name = "lnkMoreInfo";
			this.lnkMoreInfo.Size = new global::System.Drawing.Size(126, 20);
			this.lnkMoreInfo.TabIndex = 20;
			this.lnkMoreInfo.TabStop = true;
			this.lnkMoreInfo.Text = "More Information";
			this.toolTip.SetToolTip(this.lnkMoreInfo, "View more information on this error...");
			this.lnkMoreInfo.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkMoreInfo_LinkClicked);
			this.brdFooterSeparator.BackColor = global::System.Drawing.Color.Gainsboro;
			this.brdFooterSeparator.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.brdFooterSeparator.Location = new global::System.Drawing.Point(0, 0);
			this.brdFooterSeparator.Name = "brdFooterSeparator";
			this.brdFooterSeparator.Size = new global::System.Drawing.Size(506, 1);
			this.brdFooterSeparator.TabIndex = 19;
			this.btnOkay.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnOkay.AutoEllipsis = true;
			this.btnOkay.BackColor = global::System.Drawing.Color.DodgerBlue;
			this.btnOkay.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnOkay.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnOkay.FlatAppearance.BorderColor = global::System.Drawing.Color.DodgerBlue;
			this.btnOkay.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnOkay.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.btnOkay.ForeColor = global::System.Drawing.Color.White;
			this.btnOkay.Location = new global::System.Drawing.Point(398, 8);
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new global::System.Drawing.Size(99, 31);
			this.btnOkay.TabIndex = 2;
			this.btnOkay.Text = "Okay";
			this.btnOkay.UseVisualStyleBackColor = false;
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.AutoEllipsis = true;
			this.btnCancel.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.btnCancel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatAppearance.BorderColor = global::System.Drawing.Color.LightGray;
			this.btnCancel.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.btnCancel.ForeColor = global::System.Drawing.Color.DimGray;
			this.btnCancel.Location = new global::System.Drawing.Point(293, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(99, 31);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.InformationBox_KeyDown);
			this.pnlHeader.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.pnlHeader.Controls.Add(this.bdrLeft);
			this.pnlHeader.Controls.Add(this.bdrRight);
			this.pnlHeader.Controls.Add(this.bdrTop);
			this.pnlHeader.Controls.Add(this.bdrHeader);
			this.pnlHeader.Controls.Add(this.pbClose);
			this.pnlHeader.Controls.Add(this.lblWindowTitle);
			this.pnlHeader.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new global::System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new global::System.Drawing.Size(506, 38);
			this.pnlHeader.TabIndex = 13;
			this.pnlHeader.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.pnlHeader.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.pnlHeader.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.bdrLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrLeft.Location = new global::System.Drawing.Point(0, 1);
			this.bdrLeft.Name = "bdrLeft";
			this.bdrLeft.Size = new global::System.Drawing.Size(1, 36);
			this.bdrLeft.TabIndex = 43;
			this.bdrRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrRight.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrRight.Location = new global::System.Drawing.Point(505, 1);
			this.bdrRight.Name = "bdrRight";
			this.bdrRight.Size = new global::System.Drawing.Size(1, 36);
			this.bdrRight.TabIndex = 42;
			this.bdrTop.BackColor = global::System.Drawing.Color.Silver;
			this.bdrTop.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.bdrTop.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrTop.ForeColor = global::System.Drawing.Color.Black;
			this.bdrTop.Location = new global::System.Drawing.Point(0, 0);
			this.bdrTop.Name = "bdrTop";
			this.bdrTop.Size = new global::System.Drawing.Size(506, 1);
			this.bdrTop.TabIndex = 40;
			this.bdrHeader.BackColor = global::System.Drawing.Color.Gainsboro;
			this.bdrHeader.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.bdrHeader.Location = new global::System.Drawing.Point(0, 37);
			this.bdrHeader.Name = "bdrHeader";
			this.bdrHeader.Size = new global::System.Drawing.Size(506, 1);
			this.bdrHeader.TabIndex = 12;
			this.pbClose.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.pbClose.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClose.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbClose.Image");
			this.pbClose.Location = new global::System.Drawing.Point(472, 10);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new global::System.Drawing.Size(25, 17);
			this.pbClose.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbClose.TabIndex = 4;
			this.pbClose.TabStop = false;
			this.toolTip.SetToolTip(this.pbClose, "Close");
			this.pbClose.Click += new global::System.EventHandler(this.PbClose_Click);
			this.lblWindowTitle.AutoSize = true;
			this.lblWindowTitle.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.lblWindowTitle.ForeColor = global::System.Drawing.Color.FromArgb(111, 114, 119);
			this.lblWindowTitle.Location = new global::System.Drawing.Point(12, 9);
			this.lblWindowTitle.Name = "lblWindowTitle";
			this.lblWindowTitle.Size = new global::System.Drawing.Size(45, 20);
			this.lblWindowTitle.TabIndex = 0;
			this.lblWindowTitle.Text = "{title}";
			this.lblWindowTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.lblWindowTitle.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.lblWindowTitle.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.pnlBody.BackColor = global::System.Drawing.Color.White;
			this.pnlBody.Controls.Add(this.bdrMidLeft);
			this.pnlBody.Controls.Add(this.bdrMidRight);
			this.pnlBody.Controls.Add(this.lblMessage);
			this.pnlBody.Controls.Add(this.pbIcon);
			this.pnlBody.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new global::System.Drawing.Point(0, 38);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Size = new global::System.Drawing.Size(506, 114);
			this.pnlBody.TabIndex = 15;
			this.pnlBody.DoubleClick += new global::System.EventHandler(this.lblMessage_DoubleClick);
			this.bdrMidLeft.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidLeft.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.bdrMidLeft.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrMidLeft.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidLeft.Location = new global::System.Drawing.Point(0, 0);
			this.bdrMidLeft.Name = "bdrMidLeft";
			this.bdrMidLeft.Size = new global::System.Drawing.Size(1, 114);
			this.bdrMidLeft.TabIndex = 43;
			this.bdrMidRight.BackColor = global::System.Drawing.Color.Silver;
			this.bdrMidRight.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bdrMidRight.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.bdrMidRight.ForeColor = global::System.Drawing.Color.Black;
			this.bdrMidRight.Location = new global::System.Drawing.Point(505, 0);
			this.bdrMidRight.Name = "bdrMidRight";
			this.bdrMidRight.Size = new global::System.Drawing.Size(1, 114);
			this.bdrMidRight.TabIndex = 42;
			this.lblMessage.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.lblMessage.AutoEllipsis = true;
			this.lblMessage.AutoSize = true;
			this.lblMessage.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.lblMessage.ForeColor = global::System.Drawing.Color.Black;
			this.lblMessage.Location = new global::System.Drawing.Point(81, 47);
			this.lblMessage.MaximumSize = new global::System.Drawing.Size(400, 75);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new global::System.Drawing.Size(77, 20);
			this.lblMessage.TabIndex = 14;
			this.lblMessage.Text = "{message}";
			this.lblMessage.DoubleClick += new global::System.EventHandler(this.lblMessage_DoubleClick);
			this.pbIcon.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pbIcon.Image");
			this.pbIcon.Location = new global::System.Drawing.Point(14, 33);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new global::System.Drawing.Size(61, 48);
			this.pbIcon.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbIcon.TabIndex = 15;
			this.pbIcon.TabStop = false;
			base.AcceptButton = this.btnOkay;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new global::System.Drawing.Size(506, 199);
			base.Controls.Add(this.pnlBody);
			base.Controls.Add(this.pblFooter);
			base.Controls.Add(this.pnlHeader);
			this.DoubleBuffered = true;
			this.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.Name = "InformationBox";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bunifu Framework: Information";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.InformationBox_Load);
			base.Shown += new global::System.EventHandler(this.InformationBox_Shown);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.InformationBox_KeyDown);
			this.pblFooter.ResumeLayout(false);
			this.pblFooter.PerformLayout();
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClose).EndInit();
			this.pnlBody.ResumeLayout(false);
			this.pnlBody.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbIcon).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000067 RID: 103
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.Panel pblFooter;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Panel brdFooterSeparator;

		// Token: 0x0400006A RID: 106
		private global::System.Windows.Forms.Panel pnlHeader;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.Panel bdrHeader;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.PictureBox pbClose;

		// Token: 0x0400006D RID: 109
		internal global::System.Windows.Forms.Label lblWindowTitle;

		// Token: 0x0400006E RID: 110
		internal global::System.Windows.Forms.Label lblMessage;

		// Token: 0x0400006F RID: 111
		internal global::System.Windows.Forms.PictureBox pbIcon;

		// Token: 0x04000070 RID: 112
		internal global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000071 RID: 113
		internal global::System.Windows.Forms.Button btnOkay;

		// Token: 0x04000072 RID: 114
		internal global::System.Windows.Forms.LinkLabel lnkMoreInfo;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.Label bdrTop;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Label bdrBottomRight;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Label bdrRight;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.Label bdrMidRight;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Label bdrBottomLeft;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.Label bdrLeft;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Label bdrMidLeft;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Label bdrBottom;

		// Token: 0x0400007B RID: 123
		public global::System.Windows.Forms.ToolTip toolTip;

		// Token: 0x0400007C RID: 124
		public global::System.Windows.Forms.Panel pnlBody;
	}
}
