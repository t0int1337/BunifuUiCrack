#if NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Models;
using Bunifu.Licensing.Options;
using Bunifu.Licensing.Views.Controls;
using Bunifu.Licensing.Views.Transitions;
using Newtonsoft.Json;

namespace Bunifu.Licensing.Views
{
	// Token: 0x02000008 RID: 8
	[DebuggerStepThrough]
	internal partial class InformationBoxEx : Form
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x0000AC65 File Offset: 0x00008E65
		public InformationBoxEx()
		{
			this.InitializeComponent();
			this.ImproveTextRendering();
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000AC92 File Offset: 0x00008E92
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x0000AC9A File Offset: 0x00008E9A
		public string Email { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x0000ACA3 File Offset: 0x00008EA3
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x0000ACAB File Offset: 0x00008EAB
		public string LicenseKey { get; set; }

		// Token: 0x060000A8 RID: 168 RVA: 0x0000ACB4 File Offset: 0x00008EB4
		public new void Show()
		{
			base.Opacity = 0.0;
			base.Show();
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(220));
			transition.add(this, "Opacity", 1.0);
			transition.run();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000AD0C File Offset: 0x00008F0C
		public new DialogResult ShowDialog()
		{
			try
			{
				this.Show();
				base.Opacity = 0.0;
				base.StartPosition = FormStartPosition.CenterScreen;
				base.Hide();
				Transition.run(this, "Opacity", 1.0, new TransitionType_EaseInEaseOut(220));
			}
			catch (Exception)
			{
			}
			return base.ShowDialog();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000AD88 File Offset: 0x00008F88
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

		// Token: 0x060000AB RID: 171 RVA: 0x0000ADDB File Offset: 0x00008FDB
		private void ShowVisualMovementCues()
		{
			base.Opacity = 0.8;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000ADEE File Offset: 0x00008FEE
		private void HideVisualMovementCues()
		{
			base.Opacity = 1.0;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000AE04 File Offset: 0x00009004
		private string EncodeLicense()
		{
			v2Request v2Request = new v2Request
			{
				DeviceID = LicenseValidator.GetHardwareID(),
				DeviceName = Environment.MachineName,
				OS = Hardware.GetOSName(),
				Email = this.Email,
				LicenseKey = this.LicenseKey
			};
			string text = JsonConvert.SerializeObject(v2Request);
			return Cryptography.Base64Encode(Cryptography.Encrypt(text));
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000AE6C File Offset: 0x0000906C
		private Record DecodeLicense(string licenseActivationCode)
		{
			Record record;
			try
			{
				string text = Cryptography.Base64Decode(licenseActivationCode);
				string text2 = Cryptography.Decrypt2(text);
				string text3 = Cryptography.Decrypt(text2);
				record = JsonConvert.DeserializeObject<Record>(text3);
			}
			catch (Exception)
			{
				record = new Record
				{
					IsValid = false
				};
			}
			return record;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000AEBC File Offset: 0x000090BC
		private void ShowActivationSuccessDialog(Record license)
		{
			try
			{
				bool visible = LicenseProviders._trialBox.Visible;
				if (visible)
				{
					LicenseProviders._trialBox.Hide();
				}
			}
			catch (Exception)
			{
			}
			ActivationSuccess successDialog = new ActivationSuccess();
			string text = license.License.Product.ToString();
			bool flag = license.License.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				text = "Bunifu UI WinForms";
			}
			else
			{
				bool flag2 = license.License.Product == ProductTypes.DatavizBasicWinForms;
				if (flag2)
				{
					text = "Bunifu Dataviz Basic";
				}
				else
				{
					bool flag3 = license.License.Product == ProductTypes.DatavizAdvancedWinForms;
					if (flag3)
					{
						text = "Bunifu Dataviz Advanced";
					}
					else
					{
						bool flag4 = license.License.Product == ProductTypes.Charts;
						if (flag4)
						{
							text = "Bunifu Charts";
						}
					}
				}
			}
			string text2 = license.License.RemainingDays.ToString();
			string text3 = license.License.ExpiryDate.ToString("dddd, MMMM dd, yyyy");
			try
			{
				bool flag5 = license.License.Type == LicenseTypes.Enterprise;
				if (flag5)
				{
					text3 = "Perpetual";
					text2 = "Unlimited";
				}
			}
			catch (Exception)
			{
			}
			successDialog.Product = text;
			successDialog.Plan = license.License.Plan;
			successDialog.ProductShortForm = license.License.Product.ToString();
			successDialog.LicenseType = license.License.Type.ToString();
			successDialog.PurchaseEmail = license.Client.Email;
			successDialog.LicenseKey = license.LicenseKey;
			ActivationSuccess successDialog3 = successDialog;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(license.License.MaxDevices);
			defaultInterpolatedStringHandler.AppendLiteral(" (total)");
			successDialog3.NoOfActivations = defaultInterpolatedStringHandler.ToStringAndClear();
			ActivationSuccess successDialog2 = successDialog;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(license.License.RemainingDevices);
			defaultInterpolatedStringHandler.AppendLiteral(" (activations)");
			successDialog2.RemainingActivations = defaultInterpolatedStringHandler.ToStringAndClear();
			successDialog.ExpiryDate = text3;
			successDialog.RemainingDays = text2;
			List<string> productsLicensed = LicenseValidator.GetProductsLicensed(license, license.License.Product, true);
			int autoHeight = successDialog.ctaAlert.Top + successDialog.ctaAlert.Height + successDialog.lnkViewLicenseFile.Height + successDialog.pnlFooter.Height + 80;
			int standardHeight = successDialog.lblRemainingDaysTitle.Bottom + successDialog.lnkViewLicenseFile.Height + 75;
			bool flag6 = license.License.ProductsLicensed.Count <= 1;
			if (flag6)
			{
				successDialog.ctaAlert.Hidden = true;
				successDialog.Height = standardHeight;
			}
			else
			{
				foreach (string text4 in productsLicensed)
				{
					successDialog.ctaAlert.Items.Add(text4);
				}
				successDialog.ctaAlert.Hidden = false;
				successDialog.Height = autoHeight;
				successDialog.ctaAlert.ActivateClicked += delegate(object sender, EventArgs args)
				{
					bool flag7 = successDialog.ctaAlert.CheckedItems.Count >= 1;
					if (flag7)
					{
						int num = (Screen.FromControl(this).WorkingArea.Height - standardHeight) / 2;
						this.Cursor = Cursors.WaitCursor;
						foreach (object obj in successDialog.ctaAlert.CheckedItems)
						{
							license.License.Product = LicenseValidator.GetProductEnum(obj.ToString());
							Registry.Licensing.SaveLicense(license);
						}
						this.Cursor = Cursors.Default;
						InformationBoxHelper.Show("The products have now been successfully activated. Activation will not be necessary once any one of the products has been installed in your project(s).", "Products Activated Successfully", "", InformationBox.InformationBoxIcons.Information, "Okay", "");
						successDialog.ctaAlert.Hidden = true;
						Transition.run(successDialog, "Height", standardHeight, new TransitionType_EaseInEaseOut(150));
						Transition.run(successDialog, "Top", num, new TransitionType_EaseInEaseOut(150));
					}
					else
					{
						InformationBoxHelper.Show("Please select atleast one product then try again.", "Select Product(s)", "", InformationBox.InformationBoxIcons.Warning, "Okay", "");
					}
				};
				successDialog.ctaAlert.CancelClicked += delegate(object sender, EventArgs args)
				{
					standardHeight = autoHeight - (successDialog.ctaAlert.Height + 10);
					int num2 = (Screen.FromControl(this).WorkingArea.Height - standardHeight) / 2;
					successDialog.ctaAlert.Hidden = true;
					Transition.run(successDialog, "Height", standardHeight, new TransitionType_EaseInEaseOut(150));
					Transition.run(successDialog, "Top", num2, new TransitionType_EaseInEaseOut(150));
				};
			}
			successDialog.ShowDialog();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000B324 File Offset: 0x00009524
		private void ImproveTextRendering()
		{
			this.lblTitle.UseCompatibleTextRendering = false;
			this.lblWindowTitle.UseCompatibleTextRendering = false;
			this.lblDescription.UseCompatibleTextRendering = false;
			this.btnActivate.UseCompatibleTextRendering = false;
			this.btnCancel.UseCompatibleTextRendering = false;
			this.btnCopyRequestCode.UseCompatibleTextRendering = false;
			this.btnPasteActivationCode.UseCompatibleTextRendering = false;
			this.btnSaveRQ.UseCompatibleTextRendering = false;
			this.lblRequestCode.UseCompatibleTextRendering = false;
			this.lblActivationCode.UseCompatibleTextRendering = false;
			this.lblMessageInfo.UseCompatibleTextRendering = false;
			this.lblTitleBrowseForCode.UseCompatibleTextRendering = false;
			this.lblTextBrowseForCode.UseCompatibleTextRendering = false;
			this.lblActivationCodeTitle.UseCompatibleTextRendering = false;
			this.lblActivationCodeFile.UseCompatibleTextRendering = false;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000B3F5 File Offset: 0x000095F5
		private void ShowActivityStatus()
		{
			this.btnActivate.Text = "Activating...";
			this.btnActivate.Enabled = false;
			this.btnCancel.Enabled = false;
			this.Cursor = Cursors.WaitCursor;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000B42F File Offset: 0x0000962F
		private void HideActivityStatus()
		{
			this.Cursor = Cursors.Default;
			this.btnActivate.Text = "Activate";
			this.btnActivate.Enabled = true;
			this.btnCancel.Enabled = true;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000B46C File Offset: 0x0000966C
		public void Notify(string message, InformationBoxEx.MessageTypes type = InformationBoxEx.MessageTypes.Information)
		{
			this._seconds = 0;
			Color color = Color.MediumSeaGreen;
			bool flag = type == InformationBoxEx.MessageTypes.Information;
			if (flag)
			{
				color = Color.MediumSeaGreen;
			}
			else
			{
				bool flag2 = type == InformationBoxEx.MessageTypes.Error;
				if (flag2)
				{
					color = Color.Tomato;
				}
			}
			this.lblMessageInfo.Text = message;
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(170));
			transition.add(this.lblMessageInfo, "ForeColor", color);
			transition.TransitionCompletedEvent += delegate
			{
				this.tmrMessageTimer.Enabled = true;
				this.tmrMessageTimer.Start();
			};
			transition.run();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B4F4 File Offset: 0x000096F4
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

		// Token: 0x060000B5 RID: 181 RVA: 0x0000B538 File Offset: 0x00009738
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

		// Token: 0x060000B6 RID: 182 RVA: 0x0000B58C File Offset: 0x0000978C
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

		// Token: 0x060000B7 RID: 183 RVA: 0x0000B670 File Offset: 0x00009870
		private void OnLoad(object sender, EventArgs e)
		{
			this.ApplyShadows();
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				this.lblTitle.Text = "Activate Bunifu UI (Offline)";
			}
			else
			{
				bool flag2 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
				if (flag2)
				{
					this.lblTitle.Text = "Activate Bunifu Dataviz Basic (Offline)";
				}
				else
				{
					bool flag3 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
					if (flag3)
					{
						this.lblTitle.Text = "Activate Bunifu Dataviz Advanced (Offline)";
					}
				}
			}
			this.txtRequestCode.Text = this.EncodeLicense();
			try
			{
				Clipboard.SetText(this.txtRequestCode.Text);
				this.Notify("Your Request Code has been copied to the clipboard!", InformationBoxEx.MessageTypes.Information);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000B72C File Offset: 0x0000992C
		private void btnActivate_Click(object sender, EventArgs e)
		{
			this.ShowActivityStatus();
			Record record = this.DecodeLicense(this.txtActivationCode.Text);
			record._licenseKey = this.LicenseKey;
			bool isValid = record.IsValid;
			if (isValid)
			{
				LicenseValidator.CreateLicense(record);
				LicenseActivator.LicenseCreated = true;
				this.HideActivityStatus();
				this.ShowActivationSuccessDialog(record);
				this.Hide();
				LicenseProviders._activator.Hide();
			}
			else
			{
				this.HideActivityStatus();
				InformationBoxHelper.Show("The Activation Code provided is invalid.\nPlease request for a valid code.", "Invalid Activation Code", "ERR001: Invalid Activation Code.", InformationBox.InformationBoxIcons.Warning, "Okay", "");
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000B7C5 File Offset: 0x000099C5
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000B7D0 File Offset: 0x000099D0
		private void btnSaveRQ_Click(object sender, EventArgs e)
		{
			this.txtRequestCode.Text = this.EncodeLicense();
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Choose a location to save the Request Code...";
			saveFileDialog.Filter = "Request Codes (*.brc)|*.brc|Text Files (*.txt)|*.txt|All files (*.*)|*.*";
			saveFileDialog.SupportMultiDottedExtensions = true;
#if NET5_0_OR_GREATER
			string[] array = this.Email.Split('@', StringSplitOptions.None);
#else
			string[] array = this.Email.Split(new char[] { '@' });
#endif
			saveFileDialog.FileName = array[0];
			bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				File.WriteAllText(saveFileDialog.FileName, this.txtRequestCode.Text);
				InformationBoxHelper.Show("You can now send the saved Request Code file to Bunifu for activation.", "Request Code Saved", "", InformationBox.InformationBoxIcons.Information, "Okay", "");
				this.Notify("Only one more step remaining to activate your license...", InformationBoxEx.MessageTypes.Information);
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000B884 File Offset: 0x00009A84
		private void btnCopyRQ_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(this.txtRequestCode.Text);
				this.Notify("Your Request Code has been copied to the clipboard!", InformationBoxEx.MessageTypes.Information);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000B8CC File Offset: 0x00009ACC
		private void btnPasteAC_Click(object sender, EventArgs e)
		{
			try
			{
				string text = Clipboard.GetText();
				bool flag = this.txtRequestCode.Text == text || string.IsNullOrWhiteSpace(text);
				if (flag)
				{
					this.Notify("Please use a valid Activation Code.", InformationBoxEx.MessageTypes.Error);
				}
				else
				{
					this.txtActivationCode.Text = text;
					this.Notify("Activation Code pasted!", InformationBoxEx.MessageTypes.Information);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000B948 File Offset: 0x00009B48
		private void btnBrowseAC_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;
			openFileDialog.Title = "Browse for Bunifu Activation Code...";
			openFileDialog.Filter = "Activation Codes (*.bac)|*.bac|Text Files (*.txt)|*.txt|All files (*.*)|*.*";
			bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.lblActivationCodeTitle.Show();
				this.lblActivationCodeFile.Show();
				this.txtActivationCode.Text = File.ReadAllText(openFileDialog.FileName);
				this.lblActivationCodeFile.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
			}
			else
			{
				this.lblActivationCodeFile.Text = "(none)";
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000B9E6 File Offset: 0x00009BE6
		private void pbClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000B9F0 File Offset: 0x00009BF0
		private void tmrMessageTimer_Tick(object sender, EventArgs e)
		{
			this._seconds++;
			bool flag = this._seconds == this._maxSeconds;
			if (flag)
			{
				this.tmrMessageTimer.Stop();
				this.tmrMessageTimer.Enabled = false;
				Transition.run(this.lblMessageInfo, "ForeColor", Color.WhiteSmoke, new TransitionType_EaseInEaseOut(170));
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000BA60 File Offset: 0x00009C60
		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape;
			if (flag)
			{
				base.Close();
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000BA92 File Offset: 0x00009C92
		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000BAA8 File Offset: 0x00009CA8
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

		// Token: 0x060000C3 RID: 195 RVA: 0x0000BB24 File Offset: 0x00009D24
		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			this._drag = true;
			this.Cursor = Cursors.Default;
			this._mousex = Cursor.Position.X - base.Left;
			this._mousey = Cursor.Position.Y - base.Top;
		}

		// Token: 0x0400007D RID: 125
		private bool _drag;

		// Token: 0x0400007E RID: 126
		private int _mousey;

		// Token: 0x0400007F RID: 127
		private int _mousex;

		// Token: 0x04000080 RID: 128
		private int _seconds = 0;

		// Token: 0x04000081 RID: 129
		private int _maxSeconds = 4;

		// Token: 0x02000042 RID: 66
		public enum MessageTypes
		{
			// Token: 0x040001A8 RID: 424
			Information,
			// Token: 0x040001A9 RID: 425
			Error
		}
	}
}
