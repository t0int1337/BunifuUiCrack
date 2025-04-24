#if NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Models;
using Bunifu.Licensing.Options;
using Bunifu.Licensing.Properties;
using Bunifu.Licensing.Views.Controls;
using Bunifu.Licensing.Views.Transitions;

namespace Bunifu.Licensing.Views
{
	// Token: 0x02000009 RID: 9
	[DebuggerStepThrough]
	internal partial class LicenseActivator : Form
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x0000E082 File Offset: 0x0000C282
		public LicenseActivator()
		{
			this.InitializeComponent();
			this.ImproveTextRendering();
			LicenseActivator._instance = this;
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000E0B8 File Offset: 0x0000C2B8
		public static LicenseActivator Instance
		{
			get
			{
				bool flag = LicenseActivator._instance == null;
				if (flag)
				{
					LicenseActivator._instance = new LicenseActivator();
				}
				return LicenseActivator._instance;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0000E0E5 File Offset: 0x0000C2E5
		// (set) Token: 0x060000CB RID: 203 RVA: 0x0000E0ED File Offset: 0x0000C2ED
		public bool FromCli { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000CC RID: 204 RVA: 0x0000E0F6 File Offset: 0x0000C2F6
		// (set) Token: 0x060000CD RID: 205 RVA: 0x0000E0FD File Offset: 0x0000C2FD
		internal static bool LicenseCreated { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000CE RID: 206 RVA: 0x0000E105 File Offset: 0x0000C305
		// (set) Token: 0x060000CF RID: 207 RVA: 0x0000E10D File Offset: 0x0000C30D
		internal int Retries { get; set; } = 1;

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x0000E116 File Offset: 0x0000C316
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x0000E11E File Offset: 0x0000C31E
		internal int RetryCount { get; set; } = 2;

		// Token: 0x060000D2 RID: 210 RVA: 0x0000E128 File Offset: 0x0000C328
		public new void Show()
		{
			base.Opacity = 0.0;
			base.Show();
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(220));
			transition.add(this, "Opacity", 1.0);
			transition.run();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000E180 File Offset: 0x0000C380
		public new DialogResult ShowDialog()
		{
			try
			{
				this.Show();
				base.Opacity = 0.0;
				base.StartPosition = FormStartPosition.Manual;
				base.Hide();
				Transition.run(this, "Opacity", 1.0, new TransitionType_EaseInEaseOut(220));
			}
			catch (Exception)
			{
			}
			return base.ShowDialog();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000E1FC File Offset: 0x0000C3FC
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

		// Token: 0x060000D5 RID: 213 RVA: 0x0000E250 File Offset: 0x0000C450
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

		// Token: 0x060000D6 RID: 214 RVA: 0x0000E2A4 File Offset: 0x0000C4A4
		public void ActivateLicense()
		{
			this.btnActivate.Text = "Activating...";
			this.btnActivate.Enabled = false;
			this.btnCancel.Enabled = false;
			this.Cursor = Cursors.WaitCursor;
			bool flag = this.EntriesAreValid();
			if (flag)
			{
				bool flag2 = this.NetworkIsAvailable();
				if (flag2)
				{
					bool flag3 = this.IsDateCorrect();
					if (flag3)
					{
						ActivationResults activationResults = LicenseValidator.Activate(this.txtEmail.Text, this.txtLicenseKey.Text);
						bool flag4 = activationResults == ActivationResults.Success;
						if (flag4)
						{
							Record retrievedLicense = LicenseValidator.RetrievedLicense;
							bool isValid = retrievedLicense.IsValid;
							if (isValid)
							{
								bool flag5 = retrievedLicense.License.Status == StatusOptions.Expired;
								if (flag5)
								{
									LicenseActivator.LicenseCreated = false;
									bool flag6 = InformationBoxHelper.Show("It appears your license has expired.\n\nWould you like to renew now?", "License Expired", "", InformationBox.InformationBoxIcons.Alert, "Yes", "No");
									bool flag7 = flag6;
									if (flag7)
									{
										Process.Start(LicenseValidator.GetRenewalLink(""));
									}
									else
									{
										this.txtEmail.Focus();
									}
								}
								else
								{
									bool flag8 = retrievedLicense.License.Type == LicenseTypes.Trial;
									if (flag8)
									{
										bool flag9 = Registry.Licensing.xMDed();
										if (flag9)
										{
											LicenseActivator.LicenseCreated = false;
											bool flag10 = InformationBoxHelper.Show("It appears you previously used another trial license.\nPlease consider purchasing a premium license.", "Trial Limits Ended", "https://bunifuframework.com/pricing", InformationBox.InformationBoxIcons.Alert, "Purchase", "Cancel");
											bool flag11 = flag10;
											if (flag11)
											{
												Process.Start("https://bunifuframework.com/pricing");
											}
										}
										else
										{
											LicenseValidator.CreateLicense(retrievedLicense);
											Registry.Licensing.sMDed();
											LicenseActivator.LicenseCreated = true;
											this.ShowActivationSuccessDialog(LicenseValidator.RetrievedLicense);
											this.Hide();
										}
									}
									else
									{
										LicenseValidator.CreateLicense(retrievedLicense);
										LicenseActivator.LicenseCreated = true;
										this.ShowActivationSuccessDialog(LicenseValidator.RetrievedLicense);
										this.Hide();
									}
								}
							}
							else
							{
								LicenseActivator.LicenseCreated = false;
								bool flag12 = InformationBoxHelper.Show("Something happened when validating your license.\nPlease submit the error report for support.\n", "Retry Activation", LicenseValidator.ResponseError, InformationBox.InformationBoxIcons.Warning, "Show Error", "");
								bool flag13 = flag12;
								if (flag13)
								{
									Clipboard.SetText(LicenseValidator.ResponseError);
									MessageBox.Show("Below is the error message (copied to clipboard):\n\n" + LicenseValidator.ResponseError);
								}
							}
						}
						else
						{
							bool flag14 = activationResults == ActivationResults.Failed;
							if (flag14)
							{
								LicenseActivator.LicenseCreated = false;
								InformationBoxHelper.Show("The license details you entered are incorrect.\nPlease confirm then try again.", "Incorrect License Details", "", InformationBox.InformationBoxIcons.Warning, "Okay", "");
							}
							else
							{
								bool flag15 = activationResults == ActivationResults.ProductLicenseMismatch;
								if (flag15)
								{
									LicenseActivator.LicenseCreated = false;
									bool flag16 = InformationBoxHelper.Show("Sorry, this license is valid for a different product.\n\nPlease install the product you purchased for or alternatively purchase a license for this product.", "Product License Mismatch", LicenseValidator.ResponseError, InformationBox.InformationBoxIcons.Warning, "Okay", "Purchase");
									bool flag17 = !flag16;
									if (flag17)
									{
										Clipboard.SetText(LicenseValidator.ResponseError);
										Process.Start(Strings.Application.PricingURL);
									}
								}
								else
								{
									bool flag18 = activationResults == ActivationResults.ExceptionRaised;
									if (flag18)
									{
										LicenseActivator.LicenseCreated = false;
										bool flag19 = InformationBoxHelper.Show("Something happened when validating your license.\nPlease submit the error report for assistance.\n", "Retry Activation", LicenseValidator.ResponseError, InformationBox.InformationBoxIcons.Warning, "Show Error", "");
										bool flag20 = flag19;
										if (flag20)
										{
											Clipboard.SetText(LicenseValidator.ResponseError);
											MessageBox.Show("Below is the error message (copied to clipboard):\n\n" + LicenseValidator.ResponseError);
										}
									}
									else
									{
										bool flag21 = activationResults == ActivationResults.Forbidden;
										if (flag21)
										{
											LicenseActivator.LicenseCreated = false;
											InformationBoxHelper.Show(LicenseValidator.ResponseError, "Activation Failed", "", InformationBox.InformationBoxIcons.Warning, "Okay", "");
										}
										else
										{
											bool flag22 = activationResults == ActivationResults.TLS12Issue;
											if (flag22)
											{
												LicenseActivator.LicenseCreated = false;
												bool flag23 = InformationBoxHelper.Show("The product activation request did not succeed.\nPlease submit the error report for assistance.\n", "Activation Failed", LicenseValidator.ResponseError, InformationBox.InformationBoxIcons.Warning, "Show Error", "");
												bool flag24 = flag23;
												if (flag24)
												{
													Clipboard.SetText(LicenseValidator.ResponseError);
													MessageBox.Show("Below is the error message (copied to clipboard):\n\n" + LicenseValidator.ResponseError);
												}
											}
											else
											{
												LicenseActivator.LicenseCreated = false;
												InformationBoxHelper.Show(LicenseValidator.ResponseError, "Activation Failed", LicenseValidator.ResponseError, InformationBox.InformationBoxIcons.Warning, "Okay", "");
											}
										}
									}
								}
							}
						}
					}
					else
					{
						LicenseActivator.LicenseCreated = false;
						InformationBoxHelper.Show("Your current system's date/time is incorrect.\n\nEnsure that your system is configured with \nthe correct date/time before continuing.", "Incorrect System Date/Time", "", InformationBox.InformationBoxIcons.Alert, "Okay", "");
					}
				}
			}
			this.txtEmail.Focus();
			this.Cursor = Cursors.Default;
			this.btnActivate.Text = "Activate";
			this.btnActivate.Enabled = true;
			this.btnCancel.Enabled = true;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000E6FC File Offset: 0x0000C8FC
		private void ViewOA(bool enabled = true)
		{
			if (enabled)
			{
				bool flag = LicenseActivator.IsEmailValid(this.txtEmail.Text) && !string.IsNullOrWhiteSpace(this.txtLicenseKey.Text);
				if (flag)
				{
					new InformationBoxEx
					{
						Email = this.txtEmail.Text,
						LicenseKey = this.txtLicenseKey.Text
					}.ShowDialog();
				}
			}
			else
			{
				this.ActivateLicense();
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000E77B File Offset: 0x0000C97B
		private void ClearEntries()
		{
			this.txtEmail.Clear();
			this.txtLicenseKey.Clear();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000E798 File Offset: 0x0000C998
		private void OpenLicenseFile()
		{
			try
			{
				bool flag = !this.FromCli;
				if (flag)
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Multiselect = false;
					openFileDialog.RestoreDirectory = true;
					openFileDialog.Title = "Choose a valid license file...";
					openFileDialog.Filter = "License Files |*.lic;*.licx|Text Files |*.txt|All Files |*.*";
					bool flag2 = openFileDialog.ShowDialog() == DialogResult.OK;
					if (flag2)
					{
						string[] array = File.ReadAllLines(openFileDialog.FileName);
						this.txtEmail.Text = array[0];
						this.txtLicenseKey.Text = array[1];
					}
				}
				else
				{
#if NET5_0_OR_NETFRAMEWORK
					new Thread(new ThreadStart(() =>
					{
						base.Invoke(new MethodInvoker(() =>
						{
							OpenFileDialog openFileDialog2 = new OpenFileDialog();
							openFileDialog2.Multiselect = false;
							openFileDialog2.RestoreDirectory = true;
							openFileDialog2.Title = "Choose a valid license file...";
							openFileDialog2.Filter = "License Files |*.lic;*.licx|Text Files |*.txt|All Files |*.*";
							bool flag3 = openFileDialog2.ShowDialog() == DialogResult.OK;
							if (flag3)
							{
								string[] array2 = File.ReadAllLines(openFileDialog2.FileName);
								this.txtEmail.Text = array2[0];
								this.txtLicenseKey.Text = array2[1];
							}
						}));
					})).Start();
#else
					new Thread(new ThreadStart(delegate
					{
						base.Invoke(new MethodInvoker(delegate
						{
							OpenFileDialog openFileDialog2 = new OpenFileDialog();
							openFileDialog2.Multiselect = false;
							openFileDialog2.RestoreDirectory = true;
							openFileDialog2.Title = "Choose a valid license file...";
							openFileDialog2.Filter = "License Files |*.lic;*.licx|Text Files |*.txt|All Files |*.*";
							bool flag3 = openFileDialog2.ShowDialog() == DialogResult.OK;
							if (flag3)
							{
								string[] array2 = File.ReadAllLines(openFileDialog2.FileName);
								this.txtEmail.Text = array2[0];
								this.txtLicenseKey.Text = array2[1];
							}
						}));
					})).Start();
#endif
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000E850 File Offset: 0x0000CA50
		private void SaveLicenseDetails()
		{
			try
			{
				bool flag = !this.FromCli;
				if (flag)
				{
					bool flag2 = !string.IsNullOrWhiteSpace(this.txtEmail.Text) && !string.IsNullOrWhiteSpace(this.txtLicenseKey.Text);
					if (flag2)
					{
						SaveFileDialog saveFileDialog = new SaveFileDialog();
						saveFileDialog.RestoreDirectory = true;
						saveFileDialog.Title = "Save your license details...";
						saveFileDialog.Filter = "License Files |*.lic;*.licx|Text Files |*.txt|All Files |*.*";
						bool flag3 = saveFileDialog.ShowDialog() == DialogResult.OK;
						if (flag3)
						{
							string[] array = new string[]
							{
								this.txtEmail.Text,
								this.txtLicenseKey.Text
							};
							File.WriteAllLines(saveFileDialog.FileName, array);
							MessageBox.Show("Your license details have been saved to:\n" + saveFileDialog.FileName + "\n\nYou can now use the file to activate your license in future.", "License Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
				}
				else
				{
#if NET5_0_OR_NETFRAMEWORK
					new Thread(new ThreadStart(() =>
					{
						base.Invoke(new MethodInvoker(() =>
						{
							bool flag4 = !string.IsNullOrWhiteSpace(this.txtEmail.Text) && !string.IsNullOrWhiteSpace(this.txtLicenseKey.Text);
							if (flag4)
							{
								SaveFileDialog saveFileDialog2 = new SaveFileDialog();
								saveFileDialog2.RestoreDirectory = true;
								saveFileDialog2.Title = "Save your license details...";
								saveFileDialog2.Filter = "License Files |*.lic;*.licx|Text Files |*.txt|All Files |*.*";
								bool flag5 = saveFileDialog2.ShowDialog() == DialogResult.OK;
								if (flag5)
								{
									string[] array2 = new string[]
									{
										this.txtEmail.Text,
										this.txtLicenseKey.Text
									};
									File.WriteAllLines(saveFileDialog2.FileName, array2);
									MessageBox.Show("Your license details have been saved to:\n" + saveFileDialog2.FileName + "\n\nYou can now use the file to activate your license in future.", "License Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
						}));
					})).Start();
#else
					new Thread(new ThreadStart(delegate
					{
						base.Invoke(new MethodInvoker(delegate
						{
							bool flag4 = !string.IsNullOrWhiteSpace(this.txtEmail.Text) && !string.IsNullOrWhiteSpace(this.txtLicenseKey.Text);
							if (flag4)
							{
								SaveFileDialog saveFileDialog2 = new SaveFileDialog();
								saveFileDialog2.RestoreDirectory = true;
								saveFileDialog2.Title = "Save your license details...";
								saveFileDialog2.Filter = "License Files |*.lic;*.licx|Text Files |*.txt|All Files |*.*";
								bool flag5 = saveFileDialog2.ShowDialog() == DialogResult.OK;
								if (flag5)
								{
									string[] array2 = new string[]
									{
										this.txtEmail.Text,
										this.txtLicenseKey.Text
									};
									File.WriteAllLines(saveFileDialog2.FileName, array2);
									MessageBox.Show("Your license details have been saved to:\n" + saveFileDialog2.FileName + "\n\nYou can now use the file to activate your license in future.", "License Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
						}));
					})).Start();
#endif
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000E964 File Offset: 0x0000CB64
		private void ShowLicenseKeyContextMenu()
		{
			this.cmsLicenseKeyMenu.Show(this.txtLicenseKey, new Point(0, this.txtLicenseKey.Height));
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000E98C File Offset: 0x0000CB8C
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

		// Token: 0x060000DD RID: 221 RVA: 0x0000EDF4 File Offset: 0x0000CFF4
		private void GetLicenseKeyViaClipboard()
		{
			try
			{
				bool flag = Clipboard.ContainsText();
				if (flag)
				{
					this.txtLicenseKey.Text = Clipboard.GetText();
					this.txtLicenseKey.SelectAll();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000EE44 File Offset: 0x0000D044
		private void ShowVisualMovementCues()
		{
			base.Opacity = 0.8;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000EE57 File Offset: 0x0000D057
		private void HideVisualMovementCues()
		{
			base.Opacity = 1.0;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000EE6C File Offset: 0x0000D06C
		private void SetCancelledProduct()
		{
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				this.UIWinFormsWasCancelled = true;
			}
			else
			{
				bool flag2 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
				if (flag2)
				{
					this.DatavizBasicWasCancelled = true;
				}
				else
				{
					bool flag3 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
					if (flag3)
					{
						this.DatavizAdvancedWasCancelled = true;
					}
					else
					{
						bool flag4 = LicenseValidator.Product == ProductTypes.Charts;
						if (flag4)
						{
							this.ChartsWasCancelled = true;
						}
					}
				}
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000EECC File Offset: 0x0000D0CC
		private void ImproveTextRendering()
		{
			this.btnCancel.UseCompatibleTextRendering = false;
			this.btnActivate.UseCompatibleTextRendering = false;
			this.chkTrial.UseCompatibleTextRendering = false;
			this.lblTitle.UseCompatibleTextRendering = false;
			this.lblEmail.UseCompatibleTextRendering = false;
			this.lblLicenseKey.UseCompatibleTextRendering = false;
			this.lblWindowTitle.UseCompatibleTextRendering = false;
			this.lblDescription.UseCompatibleTextRendering = false;
			this.lnkHome.UseCompatibleTextRendering = false;
			this.lnkRenew.UseCompatibleTextRendering = false;
			this.lnkSupport.UseCompatibleTextRendering = false;
			this.lblLinksSeparator1.UseCompatibleTextRendering = false;
			this.lblLinksSeparator2.UseCompatibleTextRendering = false;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000EF84 File Offset: 0x0000D184
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

		// Token: 0x060000E3 RID: 227 RVA: 0x0000F068 File Offset: 0x0000D268
		private bool EntriesAreValid()
		{
			bool flag = LicenseActivator.IsEmailValid(this.txtEmail.Text) && !string.IsNullOrWhiteSpace(this.txtLicenseKey.Text);
			bool flag2;
			if (flag)
			{
				bool focused = this.txtEmail.Focused;
				if (focused)
				{
					this.boxEmail.LineColor = Color.DodgerBlue;
				}
				else
				{
					this.boxEmail.LineColor = Color.LightGray;
				}
				bool focused2 = this.txtLicenseKey.Focused;
				if (focused2)
				{
					this.boxLicenseKey.LineColor = Color.DodgerBlue;
				}
				else
				{
					this.boxLicenseKey.LineColor = Color.LightGray;
				}
				flag2 = true;
			}
			else
			{
				bool flag3 = string.IsNullOrWhiteSpace(this.txtLicenseKey.Text);
				if (flag3)
				{
					this.txtLicenseKey.Focus();
					this.boxLicenseKey.LineColor = Color.Tomato;
					this.txtLicenseKey.Width = 416;
				}
				bool flag4 = string.IsNullOrWhiteSpace(this.txtEmail.Text);
				if (flag4)
				{
					this.txtEmail.Focus();
					this.boxEmail.LineColor = Color.Tomato;
				}
				bool focused3 = this.txtEmail.Focused;
				if (focused3)
				{
					this.boxLicenseKey.LineColor = Color.LightGray;
				}
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000F1B4 File Offset: 0x0000D3B4
		private bool NetworkIsAvailable()
		{
			bool flag = !Network.IsAvailable();
			bool flag2;
			if (flag)
			{
				MessageBox.Show("It seems you lost your Internet connection.\nPlease try reconnecting first.", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				flag2 = false;
			}
			else
			{
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		private bool IsDateCorrect()
		{
			DateTime dateTime = InternetTime.GetDateTime();
			return DateTime.Now.Date == dateTime.Date;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000F228 File Offset: 0x0000D428
		private static bool IsEmailValid(string email)
		{
			bool flag2;
			try
			{
				bool flag = !string.IsNullOrWhiteSpace(email);
				if (flag)
				{
					email = email.Trim();
					MailAddress mailAddress = new MailAddress(email);
					flag2 = mailAddress.Address == email;
				}
				else
				{
					flag2 = false;
				}
			}
			catch
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000F280 File Offset: 0x0000D480
		public static Bitmap ChangeImageColor(Bitmap image, Color color)
		{
			Bitmap bitmap = new Bitmap(image.Width, image.Height);
			for (int i = 0; i < image.Width; i++)
			{
				for (int j = 0; j < image.Height; j++)
				{
					Color pixel = image.GetPixel(i, j);
					bool flag = pixel.A > 150;
					if (flag)
					{
						bitmap.SetPixel(i, j, color);
					}
					else
					{
						bitmap.SetPixel(i, j, pixel);
					}
				}
			}
			return bitmap;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000F315 File Offset: 0x0000D515
		private void btnActivate_MouseLeave(object sender, EventArgs e)
		{
			this.btnActivate.Text = "Activate";
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000F32C File Offset: 0x0000D52C
		private void BtnActivate_Click(object sender, EventArgs e)
		{
			bool flag = Control.ModifierKeys == (Keys.Shift | Keys.Control);
			if (flag)
			{
				this.ViewOA(true);
			}
			else
			{
				this.ActivateLicense();
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000F360 File Offset: 0x0000D560
		private void OnLoad(object sender, EventArgs e)
		{
			this.ApplyShadows();
			this.cmsLicenseKeyMenu.Items[0].Click += delegate
			{
				this.GetLicenseKeyViaClipboard();
			};
			bool fromCli = this.FromCli;
			if (fromCli)
			{
				this.lblWindowTitle.Text = "Bunifu Licensing CLI";
				this.pbIcon.Size = new Size(21, 22);
				this.lblWindowTitle.Top = this.pbIcon.Top + (this.pbIcon.Height - this.lblWindowTitle.Height) / 2;
				this.lblWindowTitle.Left = this.pbIcon.Right;
			}
			else
			{
				this.lblWindowTitle.Text = "Bunifu Framework";
				this.pbIcon.Size = new Size(21, 22);
				this.lblWindowTitle.Top = this.pbIcon.Top + (this.pbIcon.Height - this.lblWindowTitle.Height) / 2;
				this.lblWindowTitle.Left = this.pbIcon.Right;
			}
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				this.lblTitle.Text = "Activate Bunifu UI";
			}
			else
			{
				bool flag2 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
				if (flag2)
				{
					this.lblTitle.Text = "Activate Bunifu Dataviz Basic";
				}
				else
				{
					bool flag3 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
					if (flag3)
					{
						this.lblTitle.Text = "Activate Bunifu Dataviz Advanced";
					}
					else
					{
						bool flag4 = LicenseValidator.Product == ProductTypes.Charts;
						if (flag4)
						{
							this.lblTitle.Text = "Activate Bunifu Charts";
						}
					}
				}
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000F508 File Offset: 0x0000D708
		private void OnShow(object sender, EventArgs e)
		{
			this.ClearEntries();
			this.txtEmail.Focus();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000F51E File Offset: 0x0000D71E
		private void OnClose(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000F52C File Offset: 0x0000D72C
		private void OnTrialChecked(object sender, EventArgs e)
		{
			this.lblEmail.Text = this.lblEmail.Text.Replace("free trial", "purchase");
			this.txtLicenseKey.Clear();
			Transition transition = new Transition(new TransitionType_EaseInEaseOut(220));
			transition.TransitionCompletedEvent += delegate
			{
				this.lblLicenseKey.Show();
				this.txtLicenseKey.Show();
				this.boxLicenseKey.Show();
			};
			transition.add(this, "Height", base.Height + 36);
			transition.run();
			this.txtEmail.Focus();
			this.boxEmail.LineColor = Color.DodgerBlue;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
		private void OnEntriesKeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.Return;
			if (flag)
			{
				bool flag2 = LicenseActivator.IsEmailValid(this.txtEmail.Text);
				if (flag2)
				{
					bool flag3 = string.IsNullOrWhiteSpace(this.txtLicenseKey.Text);
					if (flag3)
					{
						this.txtLicenseKey.Focus();
					}
					else
					{
						bool flag4 = e.Modifiers == (Keys.Shift | Keys.Control);
						if (flag4)
						{
							this.ViewOA(true);
						}
						else
						{
							this.ActivateLicense();
						}
					}
				}
				else
				{
					this.txtEmail.Focus();
				}
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
			bool flag5 = e.KeyCode == Keys.Escape;
			if (flag5)
			{
				this.btnCancel.PerformClick();
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
			bool flag6 = e.Modifiers == Keys.Control && e.KeyCode == Keys.T;
			if (flag6)
			{
				bool visible = this.chkTrial.Visible;
				if (visible)
				{
					bool @checked = this.chkTrial.Checked;
					if (@checked)
					{
						this.chkTrial.Checked = false;
					}
					else
					{
						this.chkTrial.Checked = true;
					}
				}
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
			bool flag7 = e.Modifiers == Keys.Control && e.KeyCode == Keys.O;
			if (flag7)
			{
				this.OpenLicenseFile();
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
			bool flag8 = e.Modifiers == Keys.Control && e.KeyCode == Keys.S;
			if (flag8)
			{
				this.SaveLicenseDetails();
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000F77C File Offset: 0x0000D97C
		private void OnClickCancel(object sender, EventArgs e)
		{
			this.SetCancelledProduct();
			this.Hide();
			bool f1ad718eb = LicenseProviders._f1ad718eb;
			if (f1ad718eb)
			{
				LicenseValidator.ThrowLicenseNonExistentException();
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000F7A8 File Offset: 0x0000D9A8
		private void OnClickClose(object sender, EventArgs e)
		{
			this.SetCancelledProduct();
			this.Hide();
			bool f1ad718eb = LicenseProviders._f1ad718eb;
			if (f1ad718eb)
			{
				LicenseValidator.ThrowLicenseNonExistentException();
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000F7D3 File Offset: 0x0000D9D3
		private void OnEnterEmailInput(object sender, EventArgs e)
		{
			this.boxEmail.LineColor = Color.DodgerBlue;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000F7E8 File Offset: 0x0000D9E8
		private void OnLeaveEmailInput(object sender, EventArgs e)
		{
			bool flag = !LicenseActivator.IsEmailValid(this.txtEmail.Text);
			if (flag)
			{
				bool flag2 = !this.chkTrial.Focused;
				if (flag2)
				{
					this.boxEmail.LineColor = Color.Tomato;
				}
			}
			else
			{
				this.boxEmail.LineColor = Color.LightGray;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000F849 File Offset: 0x0000DA49
		private void OnEnterLicenseKeyInput(object sender, EventArgs e)
		{
			this.boxLicenseKey.LineColor = Color.DodgerBlue;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000F85D File Offset: 0x0000DA5D
		private void OnLeaveLicenseKeyInput(object sender, EventArgs e)
		{
			this.boxLicenseKey.LineColor = Color.LightGray;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000F871 File Offset: 0x0000DA71
		private void OnClickEmailIcon(object sender, EventArgs e)
		{
			this.txtEmail.Focus();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000F880 File Offset: 0x0000DA80
		private void OnClickLicenseKeyIcon(object sender, EventArgs e)
		{
			this.txtLicenseKey.Focus();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000F88F File Offset: 0x0000DA8F
		private void OnClickHomeLink(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://bunifuframework.com");
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000F89D File Offset: 0x0000DA9D
		private void OnClickSupportLink(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://bunifuframework.com/support");
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000F8AB File Offset: 0x0000DAAB
		private void OnClickRenewLink(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(LicenseValidator.GetRenewalLink(""));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000F8BE File Offset: 0x0000DABE
		private void OnClickEmailBox(object sender, EventArgs e)
		{
			this.txtEmail.Focus();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000F8CD File Offset: 0x0000DACD
		private void OnClickLicenseKeyBox(object sender, EventArgs e)
		{
			this.txtLicenseKey.Focus();
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000F8DC File Offset: 0x0000DADC
		private void OnEmailBoxColorChanged(object sender, EventArgs e)
		{
			Color color = this.boxEmail.LineColor;
			bool flag = color == Color.LightGray;
			if (flag)
			{
				color = Color.Silver;
			}
			this.pbEmail.Image = LicenseActivator.ChangeImageColor((Bitmap)this.pbEmail.Image, color);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000F930 File Offset: 0x0000DB30
		private void OnLicenseKeyBoxColorChanged(object sender, EventArgs e)
		{
			Color color = this.boxLicenseKey.LineColor;
			bool flag = color == Color.LightGray;
			if (flag)
			{
				color = Color.Silver;
			}
			this.pbLicenseKey.Image = LicenseActivator.ChangeImageColor((Bitmap)this.pbLicenseKey.Image, color);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000F981 File Offset: 0x0000DB81
		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			this._drag = false;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000F998 File Offset: 0x0000DB98
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

		// Token: 0x06000100 RID: 256 RVA: 0x0000FA14 File Offset: 0x0000DC14
		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			this._drag = true;
			this.Cursor = Cursors.Default;
			this._mousex = Cursor.Position.X - base.Left;
			this._mousey = Cursor.Position.Y - base.Top;
		}

		// Token: 0x040000AB RID: 171
		private bool _drag;

		// Token: 0x040000AC RID: 172
		private int _mousey;

		// Token: 0x040000AD RID: 173
		private int _mousex;

		// Token: 0x040000AE RID: 174
		internal bool UIWinFormsWasCancelled;

		// Token: 0x040000AF RID: 175
		internal bool DatavizBasicWasCancelled;

		// Token: 0x040000B0 RID: 176
		internal bool DatavizAdvancedWasCancelled;

		// Token: 0x040000B1 RID: 177
		internal bool ChartsWasCancelled;

		// Token: 0x040000B2 RID: 178
		private static LicenseActivator _instance;
	}
}
