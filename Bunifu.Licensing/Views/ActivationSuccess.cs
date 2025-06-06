using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Properties;
using Bunifu.Licensing.Views.Controls;
using Bunifu.Licensing.Views.Transitions;

namespace Bunifu.Licensing.Views
{
	// Token: 0x02000004 RID: 4
	[DebuggerStepThrough]
	internal partial class ActivationSuccess : Form
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00004A0D File Offset: 0x00002C0D
		public ActivationSuccess()
		{
			this.InitializeComponent();
			this.ImproveTextRendering();
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00004A2C File Offset: 0x00002C2C
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00004A34 File Offset: 0x00002C34
		public string ProductShortForm { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00004A3D File Offset: 0x00002C3D
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00004A4A File Offset: 0x00002C4A
		public string Product
		{
			get
			{
				return this.lblProductName.Text;
			}
			set
			{
				this.lblProductName.Text = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00004A59 File Offset: 0x00002C59
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00004A66 File Offset: 0x00002C66
		public string Plan
		{
			get
			{
				return this.lblPlanName.Text;
			}
			set
			{
				this.lblPlanName.Text = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00004A75 File Offset: 0x00002C75
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00004A82 File Offset: 0x00002C82
		public string LicenseType
		{
			get
			{
				return this.lblLicenseType.Text;
			}
			set
			{
				this.lblLicenseType.Text = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00004A91 File Offset: 0x00002C91
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00004A9E File Offset: 0x00002C9E
		public string PurchaseEmail
		{
			get
			{
				return this.lblPurchaseEmail.Text;
			}
			set
			{
				this.lblPurchaseEmail.Text = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00004AAD File Offset: 0x00002CAD
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00004ABA File Offset: 0x00002CBA
		public string LicenseKey
		{
			get
			{
				return this.lblLicenseKey.Text;
			}
			set
			{
				this.lblLicenseKey.Text = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00004AC9 File Offset: 0x00002CC9
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00004AD6 File Offset: 0x00002CD6
		public string NoOfActivations
		{
			get
			{
				return this.lblActivations.Text;
			}
			set
			{
				this.lblActivations.Text = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00004AE5 File Offset: 0x00002CE5
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00004AF2 File Offset: 0x00002CF2
		public string RemainingActivations
		{
			get
			{
				return this.lblRemainingDevices.Text;
			}
			set
			{
				this.lblRemainingDevices.Text = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00004B01 File Offset: 0x00002D01
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00004B0E File Offset: 0x00002D0E
		public string ExpiryDate
		{
			get
			{
				return this.lblExpiryDate.Text;
			}
			set
			{
				this.lblExpiryDate.Text = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00004B1D File Offset: 0x00002D1D
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00004B2C File Offset: 0x00002D2C
		public string RemainingDays
		{
			get
			{
				return this.lblRemainingDays.Text;
			}
			set
			{
				this.lblRemainingDays.Text = value;
				try
				{
					bool flag = !(value == "Unlimited");
					if (flag)
					{
						bool flag2 = Convert.ToInt32(value) <= 10;
						if (flag2)
						{
							this.lblRemainingDays.ForeColor = Color.Tomato;
						}
						else
						{
							this.lblRemainingDays.ForeColor = Color.Black;
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004BAC File Offset: 0x00002DAC
		public new void Show()
		{
			base.Opacity = 1.0;
			base.Show();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004BC8 File Offset: 0x00002DC8
		public new DialogResult ShowDialog()
		{
			try
			{
				base.Opacity = 1.0;
			}
			catch (Exception)
			{
			}
			return base.ShowDialog();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004C0C File Offset: 0x00002E0C
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

		// Token: 0x06000058 RID: 88 RVA: 0x00004C60 File Offset: 0x00002E60
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

		// Token: 0x06000059 RID: 89 RVA: 0x00004CB3 File Offset: 0x00002EB3
		private void ShowVisualMovementCues()
		{
			base.Opacity = 0.8;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004CC6 File Offset: 0x00002EC6
		private void HideVisualMovementCues()
		{
			base.Opacity = 1.0;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004CDC File Offset: 0x00002EDC
		public bool ExploreFile(string filePath)
		{
			bool flag = !File.Exists(filePath);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				filePath = Path.GetFullPath(filePath);
				Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004D20 File Offset: 0x00002F20
		public bool ExploreFolder(string folderPath)
		{
			bool flag;
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = folderPath,
					UseShellExecute = true,
					Verb = "open"
				});
				flag = true;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004D74 File Offset: 0x00002F74
		private void ImproveTextRendering()
		{
			this.btnClose.UseCompatibleTextRendering = false;
			this.lblTitle.UseCompatibleTextRendering = false;
			this.lblWindowTitle.UseCompatibleTextRendering = false;
			this.lblDescription.UseCompatibleTextRendering = false;
			this.lblActivations.UseCompatibleTextRendering = false;
			this.lblActivationsTitle.UseCompatibleTextRendering = false;
			this.lblBullet1.UseCompatibleTextRendering = false;
			this.lblBullet2.UseCompatibleTextRendering = false;
			this.lblLicenseKey.UseCompatibleTextRendering = false;
			this.lblWindowTitle.UseCompatibleTextRendering = false;
			this.lblExpiryDate.UseCompatibleTextRendering = false;
			this.lblExpiryDateTitle.UseCompatibleTextRendering = false;
			this.lblLicenseKeyTitle.UseCompatibleTextRendering = false;
			this.lblLicenseType.UseCompatibleTextRendering = false;
			this.lblLicenseTypeTitle.UseCompatibleTextRendering = false;
			this.lblProductName.UseCompatibleTextRendering = false;
			this.lblProductTitle.UseCompatibleTextRendering = false;
			this.lblPlanTitle.UseCompatibleTextRendering = false;
			this.lblPlanName.UseCompatibleTextRendering = false;
			this.lblPurchaseEmail.UseCompatibleTextRendering = false;
			this.lblPurchaseEmailTitle.UseCompatibleTextRendering = false;
			this.lblRemainingDays.UseCompatibleTextRendering = false;
			this.lblRemainingDevices.UseCompatibleTextRendering = false;
			this.lblRemainingDevicesTitle.UseCompatibleTextRendering = false;
			this.lblRemainingDaysTitle.UseCompatibleTextRendering = false;
			this.lnkViewLicenseFile.UseCompatibleTextRendering = false;
			this.lnkSupport.UseCompatibleTextRendering = false;
			this.lnkRenew.UseCompatibleTextRendering = false;
			this.lnkHome.UseCompatibleTextRendering = false;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004EFC File Offset: 0x000030FC
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

		// Token: 0x0600005F RID: 95 RVA: 0x00004FE0 File Offset: 0x000031E0
		private void ActivationSuccess_Load(object sender, EventArgs e)
		{
			this.ApplyShadows();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004FEC File Offset: 0x000031EC
		private void ActivationSuccess_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape;
			if (flag)
			{
				this.Close();
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000501E File Offset: 0x0000321E
		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005028 File Offset: 0x00003228
		private void PbClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005032 File Offset: 0x00003232
		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005048 File Offset: 0x00003248
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

		// Token: 0x06000065 RID: 101 RVA: 0x000050C4 File Offset: 0x000032C4
		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			this._drag = true;
			this.Cursor = Cursors.Default;
			this._mousex = Cursor.Position.X - base.Left;
			this._mousey = Cursor.Position.Y - base.Top;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00005119 File Offset: 0x00003319
		private void LnkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://bunifuframework.com");
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005127 File Offset: 0x00003327
		private void LnkSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://bunifuframework.com/support");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00005135 File Offset: 0x00003335
		private void LnkRenew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(LicenseValidator.GetRenewalLink(""));
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005148 File Offset: 0x00003348
		private void LnkViewLicenseFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.ExploreFile(Registry.FolderPath + this.ProductShortForm + "\\License Information.txt");
		}

		// Token: 0x04000014 RID: 20
		private bool _drag;

		// Token: 0x04000015 RID: 21
		private int _mousey;

		// Token: 0x04000016 RID: 22
		private int _mousex;
	}
}
