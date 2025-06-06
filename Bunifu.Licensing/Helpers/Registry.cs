#if NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Bunifu.Licensing.Models;
using Bunifu.Licensing.Options;
using Bunifu.Licensing.Properties;
using Bunifu.Licensing.Views;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunifu.Licensing.Helpers
{
	// Token: 0x02000038 RID: 56
	[DebuggerStepThrough]
	internal sealed class Registry
	{
		// Token: 0x04000188 RID: 392
		private static int _UIUpgradeCalls = 0;

		// Token: 0x04000189 RID: 393
		private static int _DBUpgradeCalls = 0;

		// Token: 0x0400018A RID: 394
		private static int _DAUpgradeCalls = 0;

		// Token: 0x0400018B RID: 395
		private static string RegistryPath = "Software\\";

		// Token: 0x0400018C RID: 396
		public static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Bunifu Technologies\\";

		// Token: 0x0200004B RID: 75
		public static class Base
		{
			// Token: 0x06000289 RID: 649 RVA: 0x00018184 File Offset: 0x00016384
			public static void SaveValue(string company, string product, string key, object value)
			{
				try
				{
					string text = Registry.RegistryPath;
					bool flag = !string.IsNullOrEmpty(company);
					if (flag)
					{
						text = text + company + "\\";
					}
					text += product;
					RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(text);
					registryKey.SetValue(key, value.ToString());
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x0600028A RID: 650 RVA: 0x000181F0 File Offset: 0x000163F0
			public static string GetValue(string company, string product, string key)
			{
				string text2;
				try
				{
					string text = Registry.RegistryPath;
					bool flag = !string.IsNullOrEmpty(company);
					if (flag)
					{
						text = text + company + "\\";
					}
					text += product;
					RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(text);
					bool flag2 = registryKey != null;
					if (flag2)
					{
						text2 = registryKey.GetValue(key).ToString();
					}
					else
					{
						text2 = "";
					}
				}
				catch (Exception)
				{
					text2 = "";
				}
				return text2;
			}

			// Token: 0x0600028B RID: 651 RVA: 0x00018274 File Offset: 0x00016474
			public static bool DeleteValue(string company, string product, string key)
			{
				bool flag3;
				try
				{
					string text = Registry.RegistryPath;
					bool flag = !string.IsNullOrEmpty(company);
					if (flag)
					{
						text = text + company + "\\";
					}
					text += product;
					using (RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(text, true))
					{
						bool flag2 = registryKey != null;
						if (flag2)
						{
							registryKey.DeleteValue(key);
						}
					}
					flag3 = true;
				}
				catch (Exception)
				{
					flag3 = false;
				}
				return flag3;
			}
		}

		// Token: 0x0200004C RID: 76
		public static class Options
		{
			// Token: 0x0600028C RID: 652 RVA: 0x00018308 File Offset: 0x00016508
			public static bool SaveLastNotificationTime(ProductTypes product, DateTime notificationTime)
			{
				bool flag;
				try
				{
					Registry.Base.SaveValue(Resources.CPA, product.ToString(), "LNT", Registry.Options.Base64Encode(notificationTime.ToString()));
					flag = true;
				}
				catch (Exception)
				{
					flag = false;
				}
				return flag;
			}

			// Token: 0x0600028D RID: 653 RVA: 0x0001835C File Offset: 0x0001655C
			public static DateTime GetLastNotificationTime(ProductTypes product)
			{
				DateTime dateTime;
				try
				{
					string text = Registry.Base.GetValue(Resources.CPA, product.ToString(), "LNT");
					text = Registry.Options.Base64Decode(text);
					dateTime = Convert.ToDateTime(text);
				}
				catch (Exception)
				{
					dateTime = DateTime.Now.AddDays(-1.0);
				}
				return dateTime;
			}

			// Token: 0x0600028E RID: 654 RVA: 0x000183C4 File Offset: 0x000165C4
			private static string Base64Encode(string plainText)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(plainText);
				return Convert.ToBase64String(bytes);
			}

			// Token: 0x0600028F RID: 655 RVA: 0x000183E8 File Offset: 0x000165E8
			private static string Base64Decode(string base64EncodedData)
			{
				byte[] array = Convert.FromBase64String(base64EncodedData);
				return Encoding.UTF8.GetString(array);
			}
		}

		// Token: 0x0200004D RID: 77
		public static class Licensing
		{
			// Token: 0x06000290 RID: 656 RVA: 0x0001840C File Offset: 0x0001660C
			public static Record GetLicense(ProductTypes product)
			{
				Record record2;
				try
				{
					Logger.Add("Validating any installed licenses...");
					string text = Registry.Base.GetValue(Resources.CPA, product.ToString(), "CLI");
					text = Cryptography.Decrypt(text);
					Logger.Add("Valid product license found.");
					Logger.Add("License validated successfully.");
					bool flag = false;
					bool flag2 = false;
					Record record = new Record();
					string text2 = string.Empty;
					bool flag3 = flag;
					if (flag3)
					{
						Logger.Add("Checking license version...");
						try
						{
							JObject jobject = JObject.Parse(text);
							bool flag4 = jobject["HardwareID"] != null;
							if (flag4)
							{
								text2 = jobject["HardwareID"].ToString();
							}
							bool flag5 = text2 != null || !string.IsNullOrEmpty(text2);
							if (flag5)
							{
								Logger.Add("License verified as v1. Requesting for upgrade...");
								bool flag6 = product == ProductTypes.UIWinForms && Registry._UIUpgradeCalls == 0;
								if (flag6)
								{
									flag2 = true;
								}
								else
								{
									bool flag7 = product == ProductTypes.DatavizBasicWinForms && Registry._DBUpgradeCalls == 0;
									if (flag7)
									{
										flag2 = true;
									}
									else
									{
										bool flag8 = product == ProductTypes.DatavizAdvancedWinForms && Registry._DAUpgradeCalls == 0;
										if (flag8)
										{
											flag2 = true;
										}
									}
								}
								bool flag9 = flag2;
								if (flag9)
								{
									bool flag10 = LicenseValidator.GetHardwareID() == text2;
									if (flag10)
									{
										v1License v1License = JsonConvert.DeserializeObject<v1License>(text);
										v1License._licenseKey = JObject.Parse(text).SelectToken("LicenseKey").ToString();
										bool flag11 = InformationBoxHelper.Show("We recently updated our client licensing and are about to upgrade your old license to the newly updated license format in this device.", "New Licensing Upgrade", "", InformationBox.InformationBoxIcons.Information, "Upgrade", "");
										Logger.Add("Upgrade started...");
										bool flag12 = product == ProductTypes.UIWinForms;
										if (flag12)
										{
											Registry._UIUpgradeCalls++;
										}
										else
										{
											bool flag13 = product == ProductTypes.DatavizBasicWinForms;
											if (flag13)
											{
												Registry._DBUpgradeCalls++;
											}
											else
											{
												bool flag14 = product == ProductTypes.DatavizAdvancedWinForms;
												if (flag14)
												{
													Registry._DAUpgradeCalls++;
												}
											}
										}
										bool flag15 = flag11;
										if (flag15)
										{
											Logger.Add("License v2 activation upgrade starting...");
											ActivationResults activationResults = LicenseValidator.Activate(v1License.Email, v1License._licenseKey);
											bool flag16 = activationResults == ActivationResults.Success;
											if (flag16)
											{
												Logger.Add("License successfully upgraded to v2.");
												record = LicenseValidator.RetrievedLicense;
												try
												{
													DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
													defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
													defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
													defaultInterpolatedStringHandler.AppendLiteral("\\License Information.txt");
													string text3 = defaultInterpolatedStringHandler.ToStringAndClear();
													defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
													defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
													defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(record.License.Product);
													defaultInterpolatedStringHandler.AppendLiteral("\\License.lic");
													string text4 = defaultInterpolatedStringHandler.ToStringAndClear();
													Registry.Licensing.CreateDirectoryIfNoneExists(product.ToString());
													Registry.Licensing.UpdateLicenseFile(text3, text4, record);
													InformationBoxHelper.Show("Your license has been successfully upgraded.Happy coding!", "License Upgrade Successful", "", InformationBox.InformationBoxIcons.Information, "Okay", "");
												}
												catch (Exception)
												{
												}
											}
											else
											{
												Logger.Add("License upgraded failed.");
												record = new Record
												{
													IsValid = false
												};
												bool flag17 = InformationBoxHelper.Show(LicenseValidator.ResponseError, "Upgrade Failed", "", InformationBox.InformationBoxIcons.Warning, "Okay", "");
											}
										}
									}
								}
							}
							else
							{
								Logger.Add("License verified as v2.");
								Logger.Add("License validation passed.");
							}
						}
						catch (Exception ex)
						{
							Logger.Add("Exception L1: " + ex.Message);
						}
					}
					try
					{
						record = JsonConvert.DeserializeObject<Record>(text);
						record._licenseKey = JObject.Parse(text).SelectToken("LicenseKey").ToString();
						try
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
							defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
							defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
							defaultInterpolatedStringHandler.AppendLiteral("\\License Information.txt");
							string text5 = defaultInterpolatedStringHandler.ToStringAndClear();
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
							defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
							defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(record.License.Product);
							defaultInterpolatedStringHandler.AppendLiteral("\\License.lic");
							string text6 = defaultInterpolatedStringHandler.ToStringAndClear();
							Registry.Licensing.CreateDirectoryIfNoneExists(product.ToString());
							Registry.Licensing.UpdateLicenseFile(text5, text6, record);
						}
						catch (Exception ex2)
						{
							Logger.Add("Exception L2: " + ex2.Message);
						}
					}
					catch (Exception ex3)
					{
						Logger.Add("Exception L3: " + ex3.Message);
						Registry.Licensing.DeleteLicense(product, false);
						record = new Record
						{
							IsValid = false
						};
					}
					record2 = record;
				}
				catch (Exception ex4)
				{
					Logger.Add("Exception L4: " + ex4.Message);
					Registry.Licensing.DeleteLicense(product, false);
					record2 = Registry.Licensing.GetBackupLicense(product);
				}
				return record2;
			}

			// Token: 0x06000291 RID: 657 RVA: 0x0001892C File Offset: 0x00016B2C
			public static void SaveLicense(Record license)
			{
				try
				{
					bool isValid = license.IsValid;
					if (isValid)
					{
						Registry.Base.SaveValue(Resources.CPA, license.License.Product.ToString(), "CLI", Cryptography.Encrypt(JsonConvert.SerializeObject(license)));
						try
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
							defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
							defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(license.License.Product);
							defaultInterpolatedStringHandler.AppendLiteral("\\License Information.txt");
							string text = defaultInterpolatedStringHandler.ToStringAndClear();
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
							defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
							defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(license.License.Product);
							defaultInterpolatedStringHandler.AppendLiteral("\\License.lic");
							string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
							Registry.Licensing.CreateDirectoryIfNoneExists(license.License.Product.ToString());
							Registry.Licensing.UpdateLicenseFile(text, text2, license);
						}
						catch (Exception)
						{
						}
					}
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x06000292 RID: 658 RVA: 0x00018A54 File Offset: 0x00016C54
			public static bool DeleteLicense(ProductTypes product, bool deleteLicenseInfoFile)
			{
				if (deleteLicenseInfoFile)
				{
					Registry.Licensing.DeleteDirectoryIfExists(product.ToString());
				}
				return Registry.Base.DeleteValue(Resources.CPA, product.ToString(), "CLI");
			}

			// Token: 0x06000293 RID: 659 RVA: 0x00018A9C File Offset: 0x00016C9C
			public static void CreateDirectoryIfNoneExists(string product)
			{
				try
				{
					string text = Registry.FolderPath + product + "\\";
					bool flag = !Directory.Exists(text);
					if (flag)
					{
						Directory.CreateDirectory(text);
					}
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x06000294 RID: 660 RVA: 0x00018AE8 File Offset: 0x00016CE8
			private static void DeleteDirectoryIfExists(string product)
			{
				try
				{
					string text = Registry.FolderPath + product + "\\";
					bool flag = Directory.Exists(text);
					if (flag)
					{
						Directory.Delete(text, true);
					}
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x06000295 RID: 661 RVA: 0x00018B34 File Offset: 0x00016D34
			private static void UpdateLicenseFile(string licenseFile, string backupLicense, Record license)
			{
				try
				{
					string text = license.License.TotalDays.ToString();
					string text2 = license.License.RemainingDays.ToString();
					string text3 = license.License.ExpiryDate.ToString("dddd, MMMM dd, yyyy");
					bool flag = license.License.Type == LicenseTypes.Enterprise;
					if (flag)
					{
						text = "Unlimited";
						text2 = "Unlimited";
						text3 = "Perpetual";
					}
					File.WriteAllText(backupLicense, Cryptography.Encrypt(JsonConvert.SerializeObject(license)));
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(84, 7);
					defaultInterpolatedStringHandler.AppendLiteral("Product: ");
					defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(license.License.Product);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					defaultInterpolatedStringHandler.AppendLiteral("Email: ");
					defaultInterpolatedStringHandler.AppendFormatted(license.Client.Email);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					defaultInterpolatedStringHandler.AppendLiteral("Status: ");
					defaultInterpolatedStringHandler.AppendFormatted<StatusOptions>(license.License.Status);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					defaultInterpolatedStringHandler.AppendLiteral("Activations: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(license.License.MaxDevices);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					defaultInterpolatedStringHandler.AppendLiteral("Total Days: ");
					defaultInterpolatedStringHandler.AppendFormatted(text);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					defaultInterpolatedStringHandler.AppendLiteral("Remaining Days: ");
					defaultInterpolatedStringHandler.AppendFormatted(text2);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					defaultInterpolatedStringHandler.AppendLiteral("Expiry Date: ");
					defaultInterpolatedStringHandler.AppendFormatted(text3);
					File.WriteAllText(licenseFile, defaultInterpolatedStringHandler.ToStringAndClear());
				}
				catch (Exception)
				{
				}
			}

			// Token: 0x06000296 RID: 662 RVA: 0x00018D0C File Offset: 0x00016F0C
			private static Record GetBackupLicense(ProductTypes product)
			{
				Record record2;
				try
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
					defaultInterpolatedStringHandler.AppendFormatted(Registry.FolderPath);
					defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
					defaultInterpolatedStringHandler.AppendLiteral("\\License.lic");
					string text = defaultInterpolatedStringHandler.ToStringAndClear();
					bool flag = File.Exists(text);
					if (flag)
					{
						string text2 = Cryptography.Decrypt(File.ReadAllText(text));
						Record record = JsonConvert.DeserializeObject<Record>(text2);
						record._licenseKey = JObject.Parse(text2).SelectToken("LicenseKey").ToString();
						Registry.Base.SaveValue(Resources.CPA, record.License.Product.ToString(), "CLI", Cryptography.Encrypt(JsonConvert.SerializeObject(record)));
						record2 = record;
					}
					else
					{
						record2 = new Record
						{
							IsValid = false
						};
					}
				}
				catch (Exception)
				{
					record2 = new Record
					{
						IsValid = false
					};
				}
				return record2;
			}

			// Token: 0x06000297 RID: 663 RVA: 0x00018E00 File Offset: 0x00017000
			public static bool sMDed()
			{
				bool flag2;
				try
				{
					string text = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Resources.XLD + "\\";
					string text2 = text + Resources.XLF;
					bool flag = !Directory.Exists(text);
					if (flag)
					{
						Directory.CreateDirectory(text);
					}
					File.WriteAllText(text2, Cryptography.Encrypt(Resources.XLV));
					flag2 = true;
				}
				catch (Exception)
				{
					flag2 = false;
				}
				return flag2;
			}

			// Token: 0x06000298 RID: 664 RVA: 0x00018E78 File Offset: 0x00017078
			public static bool xMDed()
			{
				bool flag4;
				try
				{
					string text = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Resources.XLD + "\\";
					string text2 = text + Resources.XLF;
					bool flag = !Directory.Exists(text);
					if (flag)
					{
						Directory.CreateDirectory(text);
					}
					bool flag2 = File.Exists(text2);
					if (flag2)
					{
						string text3 = Cryptography.Decrypt(File.ReadAllText(text2));
						bool flag3 = text3 == Resources.XLV;
						if (flag3)
						{
							flag4 = true;
						}
						else
						{
							flag4 = false;
						}
					}
					else
					{
						flag4 = false;
					}
				}
				catch (Exception)
				{
					flag4 = false;
				}
				return flag4;
			}
		}
	}
}
