#if NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
#if NET5_0_OR_GREATER || NET6_0_OR_GREATER
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
#else
using System.Net;
using System.Net.Http;
#endif
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Licensing.Helpers;
using Bunifu.Licensing.Models;
using Bunifu.Licensing.Options;
using Bunifu.Licensing.Properties;
using Bunifu.Licensing.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace Bunifu.Licensing
{
	// Token: 0x02000003 RID: 3
	[DebuggerStepThrough]
	public sealed class LicenseValidator
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000275C File Offset: 0x0000095C
		public static bool DesignMode2
		{
			get
			{
				return Application.ExecutablePath.IndexOf("DesignToolsServer.exe", StringComparison.OrdinalIgnoreCase) > -1;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000278C File Offset: 0x0000098C
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00002793 File Offset: 0x00000993
		internal static string ResponseError { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000279C File Offset: 0x0000099C
		private static bool DesignMode
		{
			get
			{
				return LicenseManager.UsageMode == LicenseUsageMode.Designtime || Debugger.IsAttached;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000027CC File Offset: 0x000009CC
		internal static bool LicenseExpired
		{
			get
			{
				return LicenseValidator.RetrievedLicense.License.Status == StatusOptions.Expired;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000027FC File Offset: 0x000009FC
		private static string LicenseFolder
		{
			get
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
				defaultInterpolatedStringHandler.AppendLiteral("\\");
				defaultInterpolatedStringHandler.AppendFormatted(Resources.CPA);
				defaultInterpolatedStringHandler.AppendLiteral("\\");
				defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(LicenseValidator.Product);
				return folderPath + defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002860 File Offset: 0x00000A60
		private static string LicenseFile
		{
			get
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
				defaultInterpolatedStringHandler.AppendFormatted(LicenseValidator.LicenseFolder);
				defaultInterpolatedStringHandler.AppendLiteral("\\");
				defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(LicenseValidator.Product);
				defaultInterpolatedStringHandler.AppendLiteral(".lic");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000028B4 File Offset: 0x00000AB4
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000028FF File Offset: 0x00000AFF
		internal static Record RetrievedLicense
		{
			get
			{
				bool flag = LicenseValidator._retrievedLicense != null && LicenseValidator._retrievedLicense.IsValid;
				Record record;
				if (flag)
				{
					bool flag2 = LicenseValidator.IsProductLicenseAvailable(LicenseValidator._retrievedLicense, LicenseValidator.Product);
					if (flag2)
					{
						record = LicenseValidator._retrievedLicense;
					}
					else
					{
						record = null;
					}
				}
				else
				{
					record = null;
				}
				return record;
			}
			set
			{
				LicenseValidator._retrievedLicense = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002907 File Offset: 0x00000B07
		// (set) Token: 0x06000012 RID: 18 RVA: 0x0000290E File Offset: 0x00000B0E
		internal static ProductTypes Product { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002916 File Offset: 0x00000B16
		// (set) Token: 0x06000014 RID: 20 RVA: 0x0000291D File Offset: 0x00000B1D
		internal static Type LicensedControlType { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002925 File Offset: 0x00000B25
		// (set) Token: 0x06000016 RID: 22 RVA: 0x0000292C File Offset: 0x00000B2C
		internal static object LicensedControlInstance { get; set; }

		// Token: 0x06000017 RID: 23 RVA: 0x00002934 File Offset: 0x00000B34
		public static License Validate(ProductTypes product, Type control = null)
		{
			control = typeof(Button);
			LicenseValidator.Product = product;
			LicenseValidator._activator.FromCli = false;
			return LicenseValidator.GetProductLicense(product, new LicenseContext(), control);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002974 File Offset: 0x00000B74
		public static License Validate(ProductTypes product, Type control, object instance)
		{
			LicenseValidator.Product = product;
			return LicenseManager.Validate(control, instance);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002998 File Offset: 0x00000B98
		public static License Activate(ProductTypes product, bool fromCli = false)
		{
			LicenseValidator.Product = product;
			LicenseValidator._activator.FromCli = fromCli;
			LicenseValidator._activator.ShowDialog();
			bool licenseCreated = LicenseActivator.LicenseCreated;
			License license;
			if (licenseCreated)
			{
				license = LicenseValidator.RetrievedLicense;
			}
			else
			{
				license = null;
			}
			return license;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000029DC File Offset: 0x00000BDC
		internal static Record Validate(string email, string licenseKey)
		{
			Record record2;
			try
			{
				LicenseValidator.ResponseError = string.Empty;
				Logger.Add("Activation request initiated.");
				v2Request v2Request = new v2Request
				{
					DeviceID = LicenseValidator.GetHardwareID(),
					DeviceName = Environment.MachineName,
					OS = Hardware.GetOSName(),
					Email = email,
					LicenseKey = licenseKey
				};
				//LicenseValidator._apiClient.DefaultRequestHeaders.Accept.Clear();
				//LicenseValidator._apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); net462 issues..
				LicenseValidator._apiClient.BaseAddress = new Uri(Resources.BUL);
				Logger.Add("Request successfully created.");
				StringContent stringContent = new StringContent(JsonConvert.SerializeObject(v2Request), Encoding.UTF8, "application/json");
				Logger.Add("Request now being sent...");
				HttpResponseMessage result = LicenseValidator._apiClient.PostAsync("", stringContent).GetAwaiter().GetResult();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Response received: ");
				defaultInterpolatedStringHandler.AppendFormatted<HttpStatusCode>(result.StatusCode);
				Logger.Add(defaultInterpolatedStringHandler.ToStringAndClear());
				bool flag = result.StatusCode == HttpStatusCode.Created;
				if (flag)
				{
					Logger.Add("License verified (200).");
					Logger.Add("Preparing to parse response object...");
					JObject jobject = JObject.Parse(result.Content.ToString());
					Record record = new Record();
					try
					{
						record.IsValid = true;
						record.ID = (int)jobject["id"];
						record.UUID = (string)jobject["uuid"];
						record.CreatedAt = new DateTime?(LicenseValidator.IsNullDateTime(jobject["created_at"]));
						record.RemovedAt = new DateTime?(LicenseValidator.IsNullDateTime(jobject["removed_at"]));
						Logger.Add("Header object fields parsed.");
						record.Device.ID = (int)jobject["device_id"];
						record.Device.Name = (string)jobject["device"]["name"];
						record.Device.HardwareID = (string)jobject["device"]["hw_id"];
						record.Device.OS = (string)jobject["device"]["os"];
						record.Device.Blocked = (bool)jobject["device"]["blocked"];
						record.Device.LastSeen = LicenseValidator.IsNullDateTime(jobject["device"]["last_seen"]);
						Logger.Add("Device object fields parsed.");
						record.Client.ID = LicenseValidator.IsNullInt(jobject["client"]["id"]);
						record.Client.TeamID = LicenseValidator.IsNullInt(jobject["client"]["team_id"]);
						record.Client.WPUserID = LicenseValidator.IsNullInt(jobject["client"]["wp_user_id"]);
						record.Client.IsTeamAdmin = (bool)jobject["client"]["is_team_admin"];
						record.Client.Name = (string)jobject["client"]["name"];
						record.Client.Email = (string)jobject["client"]["email"];
						record.Client.Blocked = (bool)jobject["client"]["blocked"];
						record.Client.CreatedAt = LicenseValidator.IsNullDateTime(jobject["client"]["created_at"]);
						Logger.Add("Client object fields parsed.");
						record._licenseKey = licenseKey;
						record.License.ID = (int)jobject["license"]["id"];
						record.License.UUID = (string)jobject["license"]["uuid"];
						record.License.BundleID = new int?(LicenseValidator.IsNullInt(jobject["license"]["bundle_id"]));
						record.License.TeamID = new int?(LicenseValidator.IsNullInt(jobject["license"]["team_id"]));
						record.License.UserID = new int?(LicenseValidator.IsNullInt(jobject["license"]["user_id"]));
						record.License.PurchaseID = LicenseValidator.IsNullInt(jobject["license"]["purchase_ref_id"]);
						record.License.Plan = (string)jobject["license"]["name"];
						record.License.Product = LicenseValidator.Product;
						record.License.TotalDays = (int)jobject["license"]["duration"];
						record.License.MaxDevices = (int)jobject["license"]["no_of_devices"];
						record.License.RemainingDevices = (int)jobject["license"]["devices_remaining"];
						record.License.Activations = (int)jobject["license"]["activations"];
						record.License.CreatedAt = LicenseValidator.IsNullDateTime(jobject["license"]["created_at"]);
						record.License.LicenseKeyID = new int?((int)jobject["license_key_id"]);
						Logger.Add("License object fields parsed.");
						string text = jobject["license"]["type"].ToString().ToLower();
						string text2 = jobject["license"]["status"].ToString().ToLower();
						JArray jarray = JsonConvert.DeserializeObject<JArray>(jobject["license"]["products"].ToString());
						Logger.Add("Special license object fields parsed.");
						foreach (JToken jtoken in jarray)
						{
							bool flag2 = jtoken.Type != JTokenType.Object;
							if (flag2)
							{
								record.License.ProductsLicensed.Add(new Product
								{
									ID = (int)jtoken["id"],
									Name = LicenseValidator.GetProduct((int)jtoken["id"]),
									UUID = (string)jtoken["uuid"]
								});
							}
						}
						Logger.Add("Licensed products successfully added.");
						record.License.Type = LicenseValidator.GetTypeEnum(text);
						record.License.Status = LicenseValidator.GetStatusEnum(text2);
						bool flag3 = record.License.TotalDays > 14 && record.License.TotalDays <= 365;
						if (flag3)
						{
							record.License.Type = LicenseTypes.Premium;
						}
						else
						{
							bool flag4 = record.License.TotalDays >= 1000000;
							if (flag4)
							{
								record.License.Type = LicenseTypes.Enterprise;
							}
						}
						Logger.Add("Special license enum fields casted.");
						Logger.Add("Activation succeeded.");
					}
					catch (Exception ex)
					{
						Logger.Add("Exception raised while parsing response: " + ex.Message + ".");
						LicenseValidator.ResponseError = ex.Message;
						LicenseValidator.RetrievedLicense = new Record
						{
							IsValid = false
						};
						return LicenseValidator.RetrievedLicense;
					}
					bool flag5 = LicenseValidator.IsProductLicenseAvailable(record, LicenseValidator.Product);
					if (flag5)
					{
						LicenseValidator.RetrievedLicense = record;
						record2 = record;
					}
					else
					{
						string text3 = string.Join(", ", LicenseValidator.GetProductsLicensed(record, LicenseValidator.Product, true));
						LicenseValidator.ResponseError = "[404] Product License Mismatch. Your license caters for " + text3 + ".";
						Logger.Add(LicenseValidator.ResponseError);
						LicenseValidator.RetrievedLicense = new Record
						{
							IsValid = false
						};
						record2 = LicenseValidator.RetrievedLicense;
					}
				}
				else
				{
					bool flag6 = result.StatusCode == HttpStatusCode.Forbidden;
					if (flag6)
					{
						JObject jobject2 = JObject.Parse(result.Content.ToString());
						LicenseValidator.ResponseError = "[403] " + (string)jobject2["message"];
						bool flag7 = LicenseValidator.ResponseError.ToLower().Contains("key is blocked");
						if (flag7)
						{
							Logger.Add("License blocked; revocation executed.");
							LicenseValidator.ResponseError = "[403] Your license has been blocked.\n\nIf this was unintentional, please visit our support site: https://bunifuframework.com/support.";
						}
						Logger.Add(LicenseValidator.ResponseError);
						LicenseValidator.RetrievedLicense = new Record
						{
							IsValid = false
						};
						record2 = LicenseValidator._retrievedLicense;
					}
					else
					{
						bool flag8 = !Network.IsAvailable();
						if (flag8)
						{
							LicenseValidator.ResponseError = Strings.Exceptions.NetworkUnavailable;
							Logger.Add("Network unavailable.");
						}
						else
						{
							bool flag9 = result.StatusCode.ToString() == "0";
							if (flag9)
							{
								LicenseValidator.ResponseError = "[101] TLS-1.2 request did not succeed.";
							}
							else
							{
								defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
								defaultInterpolatedStringHandler.AppendLiteral("[");
								defaultInterpolatedStringHandler.AppendFormatted<HttpStatusCode>(result.StatusCode);
								defaultInterpolatedStringHandler.AppendLiteral("] ");
								defaultInterpolatedStringHandler.AppendFormatted<HttpContent>(result.Content);
								LicenseValidator.ResponseError = defaultInterpolatedStringHandler.ToStringAndClear();
							}
							Logger.Add(LicenseValidator.ResponseError);
						}
						LicenseValidator.RetrievedLicense = new Record
						{
							IsValid = false
						};
						record2 = LicenseValidator._retrievedLicense;
					}
				}
			}
			catch (Exception ex2)
			{
				Logger.Add("[Exception] " + ex2.Message + "; " + ex2.StackTrace);
				LicenseValidator.ResponseError = ex2.Message;
				LicenseValidator.RetrievedLicense = new Record
				{
					IsValid = false
				};
				record2 = LicenseValidator._retrievedLicense;
			}
			return record2;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000034F4 File Offset: 0x000016F4
		internal static Record Validate(string email, string licenseKey, ProductTypes product)
		{
			LicenseValidator.Product = product;
			return LicenseValidator.Validate(email, licenseKey);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003514 File Offset: 0x00001714
		internal static ActivationResults Activate(string email, string licenseKey)
		{
			ActivationResults activationResults;
			try
			{
				Record record = LicenseValidator.Validate(email, licenseKey);
				bool flag = record == null;
				if (flag)
				{
					Logger.Add("License not found for " + email + ".");
					activationResults = ActivationResults.ProductLicenseMismatch;
				}
				else
				{
					bool isValid = record.IsValid;
					if (isValid)
					{
						LicenseValidator.CreateLicense(record);
						Logger.Add("License created.");
						activationResults = ActivationResults.Success;
					}
					else
					{
						bool flag2 = LicenseValidator.ResponseError.Contains("[101]");
						if (flag2)
						{
							Logger.Add("TLS 1.2 not supported.");
							activationResults = ActivationResults.TLS12Issue;
						}
						else
						{
							bool flag3 = LicenseValidator.ResponseError.Contains("[403]");
							if (flag3)
							{
								Logger.Add("License activation forbidden.");
								activationResults = ActivationResults.Forbidden;
							}
							else
							{
								Logger.Add("License activation failed.");
								activationResults = ActivationResults.Failed;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				bool flag4 = !Network.IsAvailable();
				if (flag4)
				{
					Logger.Add("[Exception] Network unavailable.");
					LicenseValidator.ResponseError = Strings.Exceptions.NetworkUnavailable;
				}
				else
				{
					Logger.Add("[Exception] " + ex.Message + ".");
					LicenseValidator.ResponseError = ex.Message;
				}
				activationResults = ActivationResults.ExceptionRaised;
			}
			return activationResults;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003640 File Offset: 0x00001840
		internal static ActivationResults Activate(string email, string licenseKey, ProductTypes product)
		{
			LicenseValidator.Product = product;
			return LicenseValidator.Activate(email, licenseKey);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003660 File Offset: 0x00001860
		internal static bool CreateLicense(Record license)
		{
			Registry.Licensing.SaveLicense(license);
			return true;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000367C File Offset: 0x0000187C
		internal static Record ReadLicense(bool forceRead = false)
		{
			Record record;
			try
			{
				if (forceRead)
				{
					LicenseValidator.RetrievedLicense = Registry.Licensing.GetLicense(LicenseValidator.Product);
					record = LicenseValidator.RetrievedLicense;
				}
				else
				{
					bool flag = LicenseValidator._retrievedLicense != null;
					if (flag)
					{
						record = LicenseValidator.RetrievedLicense;
					}
					else
					{
						LicenseValidator.RetrievedLicense = Registry.Licensing.GetLicense(LicenseValidator.Product);
						record = LicenseValidator.RetrievedLicense;
					}
				}
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

		// Token: 0x06000020 RID: 32 RVA: 0x000036FC File Offset: 0x000018FC
		internal static bool DeleteLicense(bool deleteLicenseInfoFile)
		{
			bool flag;
			try
			{
				flag = Registry.Licensing.DeleteLicense(LicenseValidator.Product, deleteLicenseInfoFile);
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003730 File Offset: 0x00001930
		internal static bool LicenseExists()
		{
			bool flag = false;
			string hardwareID = LicenseValidator.GetHardwareID();
			Record license = Registry.Licensing.GetLicense(LicenseValidator.Product);
			bool flag2 = license.Device.HardwareID == hardwareID;
			if (flag2)
			{
				LicenseValidator.RetrievedLicense = license;
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003778 File Offset: 0x00001978
		private static int GetProductID()
		{
			int num = 0;
			bool flag = LicenseValidator.LicenseExists();
			if (flag)
			{
				bool flag2 = LicenseValidator.RetrievedLicense.LicenseKey.StartsWith("FREE");
				if (flag2)
				{
					num = 0;
				}
				else
				{
					bool flag3 = LicenseValidator.RetrievedLicense.License.TotalDays >= 10000;
					if (flag3)
					{
						num = 112860;
					}
					else
					{
						bool flag4 = LicenseValidator.RetrievedLicense.ID.ToString().StartsWith("26");
						if (flag4)
						{
							num = LicenseValidator.RetrievedLicense.ID;
						}
						else
						{
							bool flag5 = LicenseValidator.RetrievedLicense.License.Product == ProductTypes.UIWinForms;
							if (flag5)
							{
								num = 25428;
							}
							else
							{
								bool flag6 = LicenseValidator.RetrievedLicense.License.Product == ProductTypes.DatavizBasicWinForms;
								if (flag6)
								{
									num = 25429;
								}
								else
								{
									bool flag7 = LicenseValidator.RetrievedLicense.License.Product == ProductTypes.DatavizAdvancedWinForms;
									if (flag7)
									{
										num = 25431;
									}
									else
									{
										bool flag8 = LicenseValidator.RetrievedLicense.License.Product == ProductTypes.Charts;
										if (flag8)
										{
											num = 262207;
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				bool flag9 = LicenseValidator.Product == ProductTypes.UIWinForms;
				if (flag9)
				{
					num = 25428;
				}
				else
				{
					bool flag10 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
					if (flag10)
					{
						num = 25429;
					}
					else
					{
						bool flag11 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
						if (flag11)
						{
							num = 25431;
						}
						else
						{
							bool flag12 = LicenseValidator.Product == ProductTypes.Charts;
							if (flag12)
							{
								num = 262207;
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000038FC File Offset: 0x00001AFC
		internal static string GetRenewalLink(string licenseKey = "")
		{
			int productID = LicenseValidator.GetProductID();
			bool flag = LicenseValidator.LicenseExists();
			string text;
			if (flag)
			{
				licenseKey = LicenseValidator.RetrievedLicense.LicenseKey;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(67, 2);
				defaultInterpolatedStringHandler.AppendLiteral("https://bunifuframework.com/checkout/?edd_license_key=");
				defaultInterpolatedStringHandler.AppendFormatted(licenseKey);
				defaultInterpolatedStringHandler.AppendLiteral("&download_id=");
				defaultInterpolatedStringHandler.AppendFormatted<int>(productID);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				bool flag2 = string.IsNullOrWhiteSpace(licenseKey);
				if (flag2)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(72, 1);
					defaultInterpolatedStringHandler.AppendLiteral("https://bunifuframework.com/checkout?edd_action=add_to_cart&download_id=");
					defaultInterpolatedStringHandler.AppendFormatted<int>(productID);
					text = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(67, 2);
					defaultInterpolatedStringHandler.AppendLiteral("https://bunifuframework.com/checkout/?edd_license_key=");
					defaultInterpolatedStringHandler.AppendFormatted(licenseKey);
					defaultInterpolatedStringHandler.AppendLiteral("&download_id=");
					defaultInterpolatedStringHandler.AppendFormatted<int>(productID);
					text = defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			return text;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000039E0 File Offset: 0x00001BE0
		internal static string GetHardwareID()
		{
			return Hardware.GetUniqueID();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000039F8 File Offset: 0x00001BF8
		internal static bool IsLicenseValid(Record license)
		{
			bool flag3;
			try
			{
				bool flag = license != null;
				if (flag)
				{
					bool flag2 = license.Device.HardwareID == LicenseValidator.GetHardwareID();
					if (flag2)
					{
						flag3 = true;
					}
					else
					{
						flag3 = false;
					}
				}
				else
				{
					flag3 = false;
				}
			}
			catch (Exception)
			{
				flag3 = false;
			}
			return flag3;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003A50 File Offset: 0x00001C50
		internal static bool IsDateBackdated()
		{
			bool flag = LicenseValidator._retrievedLicense != null && LicenseValidator._retrievedLicense.IsValid;
			bool flag3;
			if (flag)
			{
				int num = LicenseValidator._retrievedLicense.License.CreatedAt.Date.CompareTo(DateTime.Now.Date);
				bool flag2 = num == 1;
				flag3 = flag2;
			}
			else
			{
				int num2 = InternetTime.GetDateTime().Date.CompareTo(DateTime.Now.Date);
				bool flag4 = num2 == 1;
				flag3 = flag4;
			}
			return flag3;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003AF8 File Offset: 0x00001CF8
		internal static void InnerValidate(ProductTypes product, Type control, object instance)
		{
			bool designMode = LicenseValidator.DesignMode;
			if (designMode)
			{
				ValidationResults validationResults = LicenseValidator.Validate(product);
				LicenseValidator.LicensedControlType = control;
				LicenseValidator.LicensedControlInstance = instance;
				LicenseValidator.ProvideResponse(validationResults, product, control, instance);
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003B30 File Offset: 0x00001D30
		internal static void ThrowRuntimeLicenseException()
		{
			LicenseValidator._activator.Hide();
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "This product does not have a registered Bunifu UI license to run.");
			}
			bool flag2 = LicenseValidator.Product == ProductTypes.Charts;
			if (flag2)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "This product does not have a registered Bunifu Charts license to run.");
			}
			bool flag3 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
			if (flag3)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "This product does not have a registered Bunifu Dataviz license to run.");
			}
			bool flag4 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
			if (flag4)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "This product does not have a registered Bunifu Dataviz license to run.");
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003BD4 File Offset: 0x00001DD4
		internal static void ThrowLicenseNonExistentException()
		{
			LicenseValidator._activator.Hide();
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have an active Bunifu UI WinForms license.");
			}
			bool flag2 = LicenseValidator.Product == ProductTypes.Charts;
			if (flag2)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have an active Bunifu Charts license.");
			}
			bool flag3 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
			if (flag3)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have an active Bunifu Dataviz Basic license.");
			}
			bool flag4 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
			if (flag4)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have an active Bunifu Dataviz Advanced license.");
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003C78 File Offset: 0x00001E78
		internal static void ThrowLicenseInvalidException()
		{
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have a valid Bunifu UI WinForms license.");
			}
			bool flag2 = LicenseValidator.Product == ProductTypes.Charts;
			if (flag2)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have a valid Bunifu Charts license.");
			}
			bool flag3 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
			if (flag3)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have a valid Bunifu Dataviz Basic license.");
			}
			bool flag4 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
			if (flag4)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure you have a valid Bunifu Dataviz Advanced license.");
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003D10 File Offset: 0x00001F10
		internal static void ThrowLicenseExpiredException()
		{
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu UI WinForms license has expired.");
			}
			bool flag2 = LicenseValidator.Product == ProductTypes.Charts;
			if (flag2)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu Charts license has expired.");
			}
			bool flag3 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
			if (flag3)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu Dataviz Basic license has expired.");
			}
			bool flag4 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
			if (flag4)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu Dataviz Advanced license has expired.");
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003DA8 File Offset: 0x00001FA8
		internal static void ThrowLicenseBlockedException()
		{
			LicenseValidator._activator.Hide();
			bool flag = LicenseValidator.Product == ProductTypes.UIWinForms;
			if (flag)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu UI license has been blocked.");
			}
			bool flag2 = LicenseValidator.Product == ProductTypes.Charts;
			if (flag2)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu Charts license has been blocked.");
			}
			bool flag3 = LicenseValidator.Product == ProductTypes.DatavizBasicWinForms;
			if (flag3)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu Dataviz Basic license has been blocked.");
			}
			bool flag4 = LicenseValidator.Product == ProductTypes.DatavizAdvancedWinForms;
			if (flag4)
			{
				throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Your Bunifu Dataviz Advanced license has been blocked.");
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003E49 File Offset: 0x00002049
		internal static void ThrowSystemBackdatedException()
		{
			throw new LicenseException(LicenseValidator.LicensedControlType, LicenseValidator.LicensedControlInstance, "Please ensure your System Date/Time is correct.");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003E60 File Offset: 0x00002060
		private static void ProvideResponse(ValidationResults result, ProductTypes product, Type control, object instance)
		{
			bool flag = result == ValidationResults.LicenseBlocked;
			if (flag)
			{
				bool flag2 = product == ProductTypes.UIWinForms;
				if (flag2)
				{
					throw new LicenseException(control, instance, "Your Bunifu UI license has been blocked.");
				}
				bool flag3 = product == ProductTypes.DatavizBasicWinForms;
				if (flag3)
				{
					throw new LicenseException(control, instance, "Your Bunifu Dataviz Basic license has been blocked.");
				}
				bool flag4 = product == ProductTypes.DatavizAdvancedWinForms;
				if (flag4)
				{
					throw new LicenseException(control, instance, "Your Bunifu Dataviz Advanced license has been blocked.");
				}
				bool flag5 = product == ProductTypes.Charts;
				if (flag5)
				{
					throw new LicenseException(control, instance, "Your Bunifu Charts license has been blocked.");
				}
			}
			else
			{
				bool flag6 = result == ValidationResults.LicenseExpired;
				if (flag6)
				{
					bool flag7 = product == ProductTypes.UIWinForms;
					if (flag7)
					{
						throw new LicenseException(control, instance, "Your Bunifu UI WinForms license has expired.");
					}
					bool flag8 = product == ProductTypes.DatavizBasicWinForms;
					if (flag8)
					{
						throw new LicenseException(control, instance, "Your Bunifu Dataviz Basic license has expired.");
					}
					bool flag9 = product == ProductTypes.DatavizAdvancedWinForms;
					if (flag9)
					{
						throw new LicenseException(control, instance, "Your Bunifu Dataviz Advanced license has expired.");
					}
					bool flag10 = product == ProductTypes.Charts;
					if (flag10)
					{
						throw new LicenseException(control, instance, "Your Bunifu Charts license has expired.");
					}
				}
				else
				{
					bool flag11 = result == ValidationResults.LicenseNonExistent;
					if (flag11)
					{
						LicenseValidator._activator.ShowDialog();
						bool flag12 = !LicenseActivator.LicenseCreated;
						if (flag12)
						{
							bool flag13 = product == ProductTypes.UIWinForms;
							if (flag13)
							{
								throw new LicenseException(control, instance, "Please ensure you have an active Bunifu UI WinForms license.");
							}
							bool flag14 = product == ProductTypes.DatavizBasicWinForms;
							if (flag14)
							{
								throw new LicenseException(control, instance, "Please ensure you have an active Bunifu Dataviz Basic license.");
							}
							bool flag15 = product == ProductTypes.DatavizAdvancedWinForms;
							if (flag15)
							{
								throw new LicenseException(control, instance, "Please ensure you have an active Bunifu Dataviz Advanced license.");
							}
							bool flag16 = product == ProductTypes.Charts;
							if (flag16)
							{
								throw new LicenseException(control, instance, "Please ensure you have an active Bunifu Charts license.");
							}
						}
					}
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003FC4 File Offset: 0x000021C4
		private static ValidationResults Validate(ProductTypes product)
		{
			LicenseValidator.Product = product;
			bool flag = LicenseValidator.LicenseExists();
			ValidationResults validationResults;
			if (flag)
			{
				bool licenseExpired = LicenseValidator.LicenseExpired;
				if (licenseExpired)
				{
					validationResults = ValidationResults.LicenseExpired;
				}
				else
				{
					validationResults = ValidationResults.LicenseActive;
				}
			}
			else
			{
				validationResults = ValidationResults.LicenseNonExistent;
			}
			return validationResults;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003FFC File Offset: 0x000021FC
		internal static string ListProductsLicensed(Record license, ProductTypes primaryProduct, bool excludePrimaryProduct = true)
		{
			string text;
			try
			{
				List<string> list = new List<string>();
				foreach (Product product in license.License.ProductsLicensed)
				{
					if (excludePrimaryProduct)
					{
						bool flag = product.Name != primaryProduct;
						if (flag)
						{
							list.Add(LicenseValidator.CastProductEnum(product.Name));
						}
					}
					else
					{
						list.Add(LicenseValidator.CastProductEnum(product.Name));
					}
				}
				text = string.Join(", ", list);
			}
			catch (Exception)
			{
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000040C4 File Offset: 0x000022C4
		internal static List<string> GetProductsLicensed(Record license, ProductTypes primaryProduct, bool excludePrimaryProduct = true)
		{
			List<string> list2;
			try
			{
				List<string> list = new List<string>();
				foreach (Product product in license.License.ProductsLicensed)
				{
					if (excludePrimaryProduct)
					{
						bool flag = product.Name != primaryProduct;
						if (flag)
						{
							list.Add(LicenseValidator.CastProductEnum(product.Name));
						}
					}
					else
					{
						list.Add(LicenseValidator.CastProductEnum(product.Name));
					}
				}
				list2 = list;
			}
			catch (Exception)
			{
				list2 = new List<string>();
			}
			return list2;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004180 File Offset: 0x00002380
		internal static bool IsProductLicenseAvailable(Record license, ProductTypes product)
		{
			bool flag = false;
			try
			{
				foreach (Product product2 in license.License.ProductsLicensed)
				{
					bool flag2 = product2.Name == product;
					if (flag2)
					{
						flag = true;
					}
				}
			}
			catch (Exception)
			{
			}
			return flag;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004204 File Offset: 0x00002404
		internal static int IsNullInt(JToken value)
		{
			bool flag = value.Type != JTokenType.Null;
			int num;
			if (flag)
			{
				num = Convert.ToInt32(value);
			}
			else
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004234 File Offset: 0x00002434
		internal static DateTime IsNullDateTime(JToken value)
		{
			bool flag = value.Type != JTokenType.Null;
			DateTime dateTime;
			if (flag)
			{
				dateTime = Convert.ToDateTime(value);
			}
			else
			{
				dateTime = DateTime.MinValue;
			}
			return dateTime;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004268 File Offset: 0x00002468
		internal static ProductTypes GetProduct(int productID)
		{
			bool flag = productID == 1;
			ProductTypes productTypes;
			if (flag)
			{
				productTypes = ProductTypes.UIWinForms;
			}
			else
			{
				bool flag2 = productID == 2;
				if (flag2)
				{
					productTypes = ProductTypes.Charts;
				}
				else
				{
					bool flag3 = productID == 3;
					if (flag3)
					{
						productTypes = ProductTypes.DatavizBasicWinForms;
					}
					else
					{
						bool flag4 = productID == 4;
						if (flag4)
						{
							productTypes = ProductTypes.DatavizAdvancedWinForms;
						}
						else
						{
							productTypes = ProductTypes.UIWinForms;
						}
					}
				}
			}
			return productTypes;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000042B0 File Offset: 0x000024B0
		internal static string GetProductName(ProductTypes product)
		{
			bool flag = product == ProductTypes.UIWinForms;
			string text;
			if (flag)
			{
				text = "Bunifu UI WinForms";
			}
			else
			{
				bool flag2 = product == ProductTypes.DatavizBasicWinForms;
				if (flag2)
				{
					text = "Bunifu Dataviz Basic";
				}
				else
				{
					bool flag3 = product == ProductTypes.DatavizAdvancedWinForms;
					if (flag3)
					{
						text = "Bunifu Dataviz Advanced";
					}
					else
					{
						bool flag4 = product == ProductTypes.Charts;
						if (flag4)
						{
							text = "Bunifu Charts";
						}
						else
						{
							text = product.ToString();
						}
					}
				}
			}
			return text;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004314 File Offset: 0x00002514
		internal static LicenseTypes GetTypeEnum(string type)
		{
			type = type.ToLower();
			bool flag = type == "trial";
			LicenseTypes licenseTypes;
			if (flag)
			{
				licenseTypes = LicenseTypes.Trial;
			}
			else
			{
				bool flag2 = type == "premium";
				if (flag2)
				{
					licenseTypes = LicenseTypes.Premium;
				}
				else
				{
					bool flag3 = type == "enterprise";
					if (flag3)
					{
						licenseTypes = LicenseTypes.Enterprise;
					}
					else
					{
						licenseTypes = LicenseTypes.Trial;
					}
				}
			}
			return licenseTypes;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004368 File Offset: 0x00002568
		internal static StatusOptions GetStatusEnum(string status)
		{
			status = status.ToLower();
			bool flag = status == "active";
			StatusOptions statusOptions;
			if (flag)
			{
				statusOptions = StatusOptions.Active;
			}
			else
			{
				bool flag2 = status == "expired";
				if (flag2)
				{
					statusOptions = StatusOptions.Expired;
				}
				else
				{
					statusOptions = StatusOptions.Active;
				}
			}
			return statusOptions;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000043AC File Offset: 0x000025AC
		internal static ProductTypes GetProductEnum(string product)
		{
			product = product.ToLower();
			bool flag = product == "bunifu ui winforms" || product == "bunifu ui";
			ProductTypes productTypes;
			if (flag)
			{
				productTypes = ProductTypes.UIWinForms;
			}
			else
			{
				bool flag2 = product == "bunifu dataviz basic";
				if (flag2)
				{
					productTypes = ProductTypes.DatavizBasicWinForms;
				}
				else
				{
					bool flag3 = product == "bunifu dataviz advanced";
					if (flag3)
					{
						productTypes = ProductTypes.DatavizAdvancedWinForms;
					}
					else
					{
						bool flag4 = product == "bunifu charts";
						if (flag4)
						{
							productTypes = ProductTypes.Charts;
						}
						else
						{
							productTypes = ProductTypes.UIWinForms;
						}
					}
				}
			}
			return productTypes;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004428 File Offset: 0x00002628
		internal static string CastProductEnum(ProductTypes product)
		{
			bool flag = product == ProductTypes.UIWinForms;
			string text;
			if (flag)
			{
				text = "Bunifu UI";
			}
			else
			{
				bool flag2 = product == ProductTypes.DatavizBasicWinForms;
				if (flag2)
				{
					text = "Bunifu Dataviz Basic";
				}
				else
				{
					bool flag3 = product == ProductTypes.DatavizAdvancedWinForms;
					if (flag3)
					{
						text = "Bunifu Dataviz Advanced";
					}
					else
					{
						bool flag4 = product == ProductTypes.Charts;
						if (flag4)
						{
							text = "Bunifu Charts";
						}
						else
						{
							text = "Bunifu UI";
						}
					}
				}
			}
			return text;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004484 File Offset: 0x00002684
		private static LicenseUsageMode GetContext()
		{
			bool designMode = LicenseValidator.DesignMode2;
			LicenseUsageMode licenseUsageMode;
			if (designMode)
			{
				licenseUsageMode = LicenseUsageMode.Designtime;
			}
			else
			{
				licenseUsageMode = LicenseUsageMode.Runtime;
			}
			return licenseUsageMode;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000044AC File Offset: 0x000026AC
		private static License InvokeActivation(ProductTypes product, LicenseContext context, Type type, LicenseValidator.LicenseStatus status, bool reshow = false, bool f1ad718eb = true)
		{
			bool flag = false;
			LicenseValidator._f1ad718eb = f1ad718eb;
			bool flag2 = product == ProductTypes.UIWinForms;
			if (flag2)
			{
				flag = LicenseValidator._activator.UIWinFormsWasCancelled;
			}
			else
			{
				bool flag3 = product == ProductTypes.DatavizBasicWinForms;
				if (flag3)
				{
					flag = LicenseValidator._activator.DatavizBasicWasCancelled;
				}
				else
				{
					bool flag4 = product == ProductTypes.DatavizAdvancedWinForms;
					if (flag4)
					{
						flag = LicenseValidator._activator.DatavizAdvancedWasCancelled;
					}
					else
					{
						bool flag5 = product == ProductTypes.Charts;
						if (flag5)
						{
							flag = LicenseValidator._activator.ChartsWasCancelled;
						}
					}
				}
			}
			bool flag6 = !flag || reshow;
			License license;
			if (flag6)
			{
				LicenseValidator._activator.ShowDialog();
				bool flag7 = !LicenseActivator.LicenseCreated;
				if (flag7)
				{
					bool flag8 = !reshow;
					if (flag8)
					{
						bool flag9 = status == LicenseValidator.LicenseStatus.NonExistent;
						if (flag9)
						{
							LicenseValidator.ThrowLicenseNonExistentException();
						}
						else
						{
							bool flag10 = status == LicenseValidator.LicenseStatus.Expired;
							if (flag10)
							{
								LicenseValidator.ThrowLicenseExpiredException();
							}
							else
							{
								bool flag11 = status == LicenseValidator.LicenseStatus.Invalid;
								if (flag11)
								{
									LicenseValidator.ThrowLicenseInvalidException();
								}
							}
						}
					}
					license = null;
				}
				else
				{
					LicenseValidator.ReadLicense(true);
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
					defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<LicenseTypes>(LicenseValidator.RetrievedLicense.License.Type);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted(type.Name);
					context.SetSavedLicenseKey(type, defaultInterpolatedStringHandler.ToStringAndClear());
					license = LicenseValidator.RetrievedLicense;
				}
			}
			else
			{
				bool flag12 = !reshow;
				if (flag12)
				{
					bool flag13 = status == LicenseValidator.LicenseStatus.NonExistent;
					if (flag13)
					{
						LicenseValidator.ThrowLicenseNonExistentException();
					}
					else
					{
						bool flag14 = status == LicenseValidator.LicenseStatus.Expired;
						if (flag14)
						{
							LicenseValidator.ThrowLicenseExpiredException();
						}
						else
						{
							bool flag15 = status == LicenseValidator.LicenseStatus.Invalid;
							if (flag15)
							{
								LicenseValidator.ThrowLicenseInvalidException();
							}
						}
					}
				}
				license = null;
			}
			return license;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004648 File Offset: 0x00002848
		private static License GetProductLicense(ProductTypes product, LicenseContext context, Type type)
		{
			LicenseUsageMode context2 = LicenseValidator.GetContext();
			bool flag = context2 == LicenseUsageMode.Designtime;
			License license;
			if (flag)
			{
				LicenseValidator.Product = product;
				LicenseValidator.ReadLicense(false);
				bool flag2 = LicenseValidator.RetrievedLicense != null;
				if (flag2)
				{
					bool flag3 = LicenseValidator.IsDateBackdated();
					if (flag3)
					{
						LicenseValidator.ThrowSystemBackdatedException();
						license = null;
					}
					else
					{
						bool flag4 = LicenseValidator.RetrievedLicense.License.Status == StatusOptions.Expired;
						if (flag4)
						{
							bool flag5 = !LicenseValidator._freeTrialExpiredShown;
							if (flag5)
							{
								LicenseValidator._freeTrialExpiredShown = true;
								int totalDays = LicenseValidator.RetrievedLicense.License.TotalDays;
								string licenseKey = LicenseValidator.RetrievedLicense._licenseKey;
								LicenseValidator.DeleteLicense(false);
								bool flag6 = LicenseValidator.RetrievedLicense.License.Type == LicenseTypes.Trial;
								if (flag6)
								{
									DialogResult dialogResult = LicenseValidator._freeTrialEnded.ShowDialog(totalDays);
									bool flag7 = dialogResult == DialogResult.Cancel;
									if (flag7)
									{
										license = LicenseValidator.InvokeActivation(product, context, type, LicenseValidator.LicenseStatus.Expired, false, true);
									}
									else
									{
										LicenseValidator.ThrowLicenseExpiredException();
										license = null;
									}
								}
								else
								{
									bool flag8 = InformationBoxHelper.Show("It appears your license has expired.\n\nWould you like to renew now?", "License Expired", "", InformationBox.InformationBoxIcons.Alert, "Renew", "Cancel");
									try
									{
										bool flag9 = flag8;
										if (flag9)
										{
											Process.Start(LicenseValidator.GetRenewalLink(licenseKey));
										}
									}
									catch (Exception)
									{
									}
									license = LicenseValidator.InvokeActivation(product, context, type, LicenseValidator.LicenseStatus.Expired, false, true);
								}
							}
							else
							{
								LicenseValidator.ThrowLicenseExpiredException();
								license = null;
							}
						}
						else
						{
							bool flag10 = LicenseValidator.IsLicenseValid(LicenseValidator.RetrievedLicense);
							if (flag10)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
								defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted<LicenseTypes>(LicenseValidator.RetrievedLicense.License.Type);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(LicenseValidator.RetrievedLicense.LicenseKey);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(type.Name);
								context.SetSavedLicenseKey(type, defaultInterpolatedStringHandler.ToStringAndClear());
								license = LicenseValidator.RetrievedLicense;
							}
							else
							{
								LicenseValidator.DeleteLicense(false);
								license = LicenseValidator.InvokeActivation(product, context, type, LicenseValidator.LicenseStatus.Invalid, false, true);
							}
						}
					}
				}
				else
				{
					bool flag11 = LicenseValidator.LicenseExists();
					if (flag11)
					{
						bool flag12 = LicenseValidator.IsDateBackdated();
						if (flag12)
						{
							LicenseValidator.ThrowSystemBackdatedException();
							license = null;
						}
						else
						{
							bool flag13 = LicenseValidator.IsLicenseValid(LicenseValidator.RetrievedLicense);
							if (flag13)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
								defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted<LicenseTypes>(LicenseValidator.RetrievedLicense.License.Type);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(LicenseValidator.RetrievedLicense.LicenseKey);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(type.Name);
								context.SetSavedLicenseKey(type, defaultInterpolatedStringHandler.ToStringAndClear());
								license = LicenseValidator.RetrievedLicense;
							}
							else
							{
								LicenseValidator.DeleteLicense(false);
								license = LicenseValidator.InvokeActivation(product, context, type, LicenseValidator.LicenseStatus.Invalid, false, true);
							}
						}
					}
					else
					{
						bool flag14 = context2 == LicenseUsageMode.Designtime;
						if (flag14)
						{
							LicenseValidator.DeleteLicense(false);
							license = LicenseValidator.InvokeActivation(product, context, type, LicenseValidator.LicenseStatus.NonExistent, false, true);
						}
						else
						{
							LicenseValidator.ThrowLicenseNonExistentException();
							license = null;
						}
					}
				}
			}
			else
			{
				license = null;
			}
			return license;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000498C File Offset: 0x00002B8C
		private static bool DevelopmentMode()
		{
			bool flag;
			try
			{
				flag = LicenseValidator.DesignMode2;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x04000007 RID: 7
		private static Record _retrievedLicense;

		// Token: 0x04000008 RID: 8
		private static string _url = Resources.BUL;

		// Token: 0x04000009 RID: 9
		private static LicenseActivator _activator = new LicenseActivator();

#if NET5_0_OR_GREATER || NET6_0_OR_GREATER
		private static HttpClient _apiClient = new HttpClient();
#else
		private static HttpClient _apiClient = new HttpClient();
		// HttpClient compatible implementation for .NET Framework
		private static WebClient _webClient = new WebClient();
#endif

		// Token: 0x0400000A RID: 10
		internal static bool _f1ad718eb = true;

		// Token: 0x0400000B RID: 11
		private static bool _trialBoxShown = false;

		// Token: 0x0400000C RID: 12
		private static bool _freeTrialExpiredShown = false;

		// Token: 0x0400000D RID: 13
		private static FreeTrialEnded _freeTrialEnded = new FreeTrialEnded();

		// Token: 0x0400000E RID: 14
		internal static TrialBox _trialBox = new TrialBox();

		// Token: 0x02000040 RID: 64
		private enum LicenseStatus
		{
			// Token: 0x0400019F RID: 415
			NonExistent,
			// Token: 0x040001A0 RID: 416
			Expired,
			// Token: 0x040001A1 RID: 417
			Invalid
		}
	}
}
