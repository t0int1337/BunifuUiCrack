using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bunifu.Licensing.Views.Controls
{
	// Token: 0x02000023 RID: 35
	[ToolboxItem(false)]
	[DebuggerStepThrough]
	[DefaultEvent("Click")]
	[DefaultProperty("LineColor")]
	[Description("Provides a standard, gradient-filled Bunifu Tab Lines.")]
	internal class Box : UserControl
	{
		// Token: 0x0600018B RID: 395 RVA: 0x000158A4 File Offset: 0x00013AA4
		public Box()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.ProvideDefaults();
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600018C RID: 396 RVA: 0x0001592C File Offset: 0x00013B2C
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00015944 File Offset: 0x00013B44
		[DefaultValue(true)]
		[Category("Bunifu Properties")]
		[Description("Sets the box line color.")]
		public Color LineColor
		{
			get
			{
				return this._lineColor;
			}
			set
			{
				this._lineColor = value;
				base.Invalidate();
				EventHandler lineColorChanged = this.LineColorChanged;
				if (lineColorChanged != null)
				{
					lineColorChanged(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600018E RID: 398 RVA: 0x0001596D File Offset: 0x00013B6D
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00015975 File Offset: 0x00013B75
		[Category("Bunifu Properties")]
		[Description("Sets the box line style.")]
		public Box.LineStyles LineStyle
		{
			get
			{
				return this._lineStyle;
			}
			set
			{
				this._lineStyle = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00015986 File Offset: 0x00013B86
		// (set) Token: 0x06000191 RID: 401 RVA: 0x0001598E File Offset: 0x00013B8E
		[Browsable(true)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00015998 File Offset: 0x00013B98
		private void ProvideDefaults()
		{
			try
			{
				this.LineColor = Color.DodgerBlue;
				this.BackColor = Color.Transparent;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000193 RID: 403 RVA: 0x000159D8 File Offset: 0x00013BD8
		// (remove) Token: 0x06000194 RID: 404 RVA: 0x00015A10 File Offset: 0x00013C10
		[Category("Bunifu Events")]
		[Description("Occurs whenever the 'LineColor' property has been changed.")]
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler LineColorChanged = null;

		// Token: 0x06000195 RID: 405 RVA: 0x00015A48 File Offset: 0x00013C48
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			try
			{
				using (Pen pen = new Pen(this.LineColor, 1f))
				{
					bool flag = this._lineStyle == Box.LineStyles.Solid;
					if (flag)
					{
						e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
						pen.DashStyle = DashStyle.Solid;
					}
					else
					{
						bool flag2 = this._lineStyle == Box.LineStyles.Dashed;
						if (flag2)
						{
							e.Graphics.SmoothingMode = SmoothingMode.Default;
							pen.DashStyle = DashStyle.Dash;
						}
						else
						{
							bool flag3 = this._lineStyle == Box.LineStyles.Dotted;
							if (flag3)
							{
								e.Graphics.SmoothingMode = SmoothingMode.Default;
								pen.DashStyle = DashStyle.Dot;
							}
						}
					}
					e.Graphics.DrawRectangle(pen, 0, 0, base.Width - 1, base.Height - 1);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00015B34 File Offset: 0x00013D34
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00015B6C File Offset: 0x00013D6C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = SystemColors.Control;
			this.DoubleBuffered = true;
			base.Name = "Box";
			base.Size = new Size(75, 30);
			base.ResumeLayout(false);
		}

		// Token: 0x0400011F RID: 287
		private Box.LineStyles _lineStyle = Box.LineStyles.Solid;

		// Token: 0x04000120 RID: 288
		private Color _lineColor = Color.FromArgb(23, 122, 235);

		// Token: 0x04000122 RID: 290
		private IContainer components = null;

		// Token: 0x02000048 RID: 72
		public enum LineStyles
		{
			// Token: 0x040001BD RID: 445
			Solid,
			// Token: 0x040001BE RID: 446
			Dashed,
			// Token: 0x040001BF RID: 447
			Dotted
		}
	}
}
