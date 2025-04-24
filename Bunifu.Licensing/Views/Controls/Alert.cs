using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Bunifu.Licensing.Properties;

namespace Bunifu.Licensing.Views.Controls
{
	// Token: 0x02000022 RID: 34
	[ToolboxItem(false)]
	[DebuggerStepThrough]
	[DefaultEvent("Click")]
	[DefaultProperty("Hidden")]
	[Description("Provides a call-to-action alert message view.")]
	internal class Alert : UserControl
	{
		// Token: 0x0600017A RID: 378 RVA: 0x00014E1D File Offset: 0x0001301D
		public Alert()
		{
			this.InitializeComponent();
			this.ImproveTextRendering();
			this.ResizeSurface();
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00014E58 File Offset: 0x00013058
		// (set) Token: 0x0600017C RID: 380 RVA: 0x00014E60 File Offset: 0x00013060
		[Category("Appearance")]
		[Description("Sets a value indicating whether the alert components will be displayed.")]
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
					this.pbIcon.Hide();
					this.lblMessage.Hide();
					this.boxContainer.Hide();
					this.lstProducts.Hide();
					this.btnActivate.Hide();
					base.Hide();
				}
				else
				{
					this.pbIcon.Show();
					this.lblMessage.Show();
					this.boxContainer.Show();
					this.lstProducts.Show();
					this.btnActivate.Show();
					base.Show();
				}
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00014F08 File Offset: 0x00013108
		[Browsable(true)]
		[Category("Appearance")]
		[ParenthesizePropertyName(true)]
		[Description("Sets the list of product items.")]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public CheckedListBox.ObjectCollection Items
		{
			get
			{
				this.ResizeSurface();
				return this.lstProducts.Items;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00014F2C File Offset: 0x0001312C
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public CheckedListBox.CheckedItemCollection CheckedItems
		{
			get
			{
				return this.lstProducts.CheckedItems;
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00014F49 File Offset: 0x00013149
		private void ImproveTextRendering()
		{
			this.lblMessage.UseCompatibleTextRendering = false;
			this.lstProducts.UseCompatibleTextRendering = false;
			this.btnActivate.UseCompatibleTextRendering = false;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00014F74 File Offset: 0x00013174
		public void ResizeSurface()
		{
			this.lstProducts.Top = this.lblMessage.Bottom + 10;
			this.lstProducts.Height = 28 * this.lstProducts.Items.Count;
			base.Height = this.lblMessage.Height + this.lblMessage.Top * 2 + 22 * this.lstProducts.Items.Count + this.btnActivate.Height + 15;
			this.btnActivate.Left = base.Width - this.btnActivate.Width - 4;
			this.btnCancel.Left = this.btnActivate.Left - this.btnCancel.Width;
			this.btnActivate.Top = base.Height - this.btnActivate.Height - 4;
			this.btnCancel.Top = this.btnActivate.Top;
			this.boxContainer.Height = base.Height;
			this.boxContainer.Width = base.Width;
			base.Invalidate();
			this.Refresh();
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000181 RID: 385 RVA: 0x000150AC File Offset: 0x000132AC
		// (remove) Token: 0x06000182 RID: 386 RVA: 0x000150E4 File Offset: 0x000132E4
		[Category("Bunifu Events")]
		[Description("Occurs whenever the 'Activate' button has been clicked.")]
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler ActivateClicked = null;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000183 RID: 387 RVA: 0x0001511C File Offset: 0x0001331C
		// (remove) Token: 0x06000184 RID: 388 RVA: 0x00015154 File Offset: 0x00013354
		[Category("Bunifu Events")]
		[Description("Occurs whenever the 'Cancel' button has been clicked.")]
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler CancelClicked = null;

		// Token: 0x06000185 RID: 389 RVA: 0x00015189 File Offset: 0x00013389
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.ResizeSurface();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0001519B File Offset: 0x0001339B
		private void OnClickActivate(object sender, EventArgs e)
		{
			EventHandler activateClicked = this.ActivateClicked;
			if (activateClicked != null)
			{
				activateClicked(this, e);
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000151B2 File Offset: 0x000133B2
		private void OnClickCancel(object sender, EventArgs e)
		{
			EventHandler cancelClicked = this.CancelClicked;
			if (cancelClicked != null)
			{
				cancelClicked(this, e);
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000151C9 File Offset: 0x000133C9
		private void OnClickLink(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://bunifuframework.com/free-download");
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000151D8 File Offset: 0x000133D8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00015210 File Offset: 0x00013410
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Alert));
			this.lblMessage = new Label();
			this.pbIcon = new PictureBox();
			this.btnActivate = new Button();
			this.lstProducts = new CheckedListBox();
			this.btnCancel = new Button();
			this.toolTip = new ToolTip(this.components);
			this.boxContainer = new Box();
			((ISupportInitialize)this.pbIcon).BeginInit();
			base.SuspendLayout();
			this.lblMessage.AutoEllipsis = true;
			this.lblMessage.AutoSize = true;
			this.lblMessage.BackColor = Color.Transparent;
			this.lblMessage.Cursor = Cursors.Arrow;
			this.lblMessage.Font = new Font("Segoe UI", 9f);
			this.lblMessage.ForeColor = Color.Black;
			this.lblMessage.Location = new Point(30, 7);
			this.lblMessage.MaximumSize = new Size(340, 0);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new Size(317, 30);
			this.lblMessage.TabIndex = 53;
			this.lblMessage.Text = "Your license also allows activating the following additional products: (Check and click 'Activate')";
			this.pbIcon.Image = Resources.yellow_warning;
			this.pbIcon.Location = new Point(7, 7);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new Size(19, 18);
			this.pbIcon.SizeMode = PictureBoxSizeMode.Zoom;
			this.pbIcon.TabIndex = 59;
			this.pbIcon.TabStop = false;
			this.btnActivate.Anchor = AnchorStyles.Right;
			this.btnActivate.BackColor = Color.FromArgb(255, 202, 40);
			this.btnActivate.Cursor = Cursors.Hand;
			this.btnActivate.FlatAppearance.BorderColor = Color.FromArgb(255, 202, 40);
			this.btnActivate.FlatStyle = FlatStyle.Flat;
			this.btnActivate.Font = new Font("Segoe UI", 9f);
			this.btnActivate.ForeColor = Color.Black;
			this.btnActivate.Location = new Point(294, 88);
			this.btnActivate.Name = "btnActivate";
			this.btnActivate.Size = new Size(96, 29);
			this.btnActivate.TabIndex = 60;
			this.btnActivate.Text = "Activate";
			this.toolTip.SetToolTip(this.btnActivate, "Activate products");
			this.btnActivate.UseVisualStyleBackColor = false;
			this.btnActivate.Click += this.OnClickActivate;
			this.lstProducts.BackColor = Color.FromArgb(255, 251, 230);
			this.lstProducts.BorderStyle = BorderStyle.None;
			this.lstProducts.CheckOnClick = true;
			this.lstProducts.Cursor = Cursors.Default;
			this.lstProducts.Font = new Font("Segoe UI", 9f);
			this.lstProducts.ForeColor = Color.Black;
			this.lstProducts.FormattingEnabled = true;
			this.lstProducts.Location = new Point(31, 56);
			this.lstProducts.Name = "lstProducts";
			this.lstProducts.Size = new Size(263, 18);
			this.lstProducts.TabIndex = 61;
			this.btnCancel.Anchor = AnchorStyles.Right;
			this.btnCancel.BackColor = Color.Transparent;
			this.btnCancel.Cursor = Cursors.Hand;
			this.btnCancel.FlatAppearance.BorderColor = Color.FromArgb(255, 202, 40);
			this.btnCancel.FlatStyle = FlatStyle.Flat;
			this.btnCancel.Font = new Font("Segoe UI", 9f);
			this.btnCancel.ForeColor = Color.FromArgb(170, 134, 26);
			this.btnCancel.Image = (Image)componentResourceManager.GetObject("btnCancel.Image");
			this.btnCancel.Location = new Point(260, 88);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(34, 29);
			this.btnCancel.TabIndex = 62;
			this.toolTip.SetToolTip(this.btnCancel, "Hide message");
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += this.OnClickCancel;
			this.boxContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.boxContainer.BackColor = Color.FromArgb(255, 251, 230);
			this.boxContainer.ForeColor = Color.Black;
			this.boxContainer.LineColor = Color.FromArgb(255, 229, 143);
			this.boxContainer.LineStyle = Box.LineStyles.Solid;
			this.boxContainer.Location = new Point(0, 0);
			this.boxContainer.Name = "boxContainer";
			this.boxContainer.Size = new Size(393, 120);
			this.boxContainer.TabIndex = 58;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.FromArgb(255, 251, 230);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.lstProducts);
			base.Controls.Add(this.btnActivate);
			base.Controls.Add(this.pbIcon);
			base.Controls.Add(this.lblMessage);
			base.Controls.Add(this.boxContainer);
			base.Name = "Alert";
			base.Size = new Size(393, 120);
			((ISupportInitialize)this.pbIcon).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000114 RID: 276
		private bool _hidden = false;

		// Token: 0x04000117 RID: 279
		private IContainer components = null;

		// Token: 0x04000118 RID: 280
		private Box boxContainer;

		// Token: 0x04000119 RID: 281
		private PictureBox pbIcon;

		// Token: 0x0400011A RID: 282
		private Button btnActivate;

		// Token: 0x0400011B RID: 283
		public CheckedListBox lstProducts;

		// Token: 0x0400011C RID: 284
		public Label lblMessage;

		// Token: 0x0400011D RID: 285
		private Button btnCancel;

		// Token: 0x0400011E RID: 286
		private ToolTip toolTip;
	}
}
