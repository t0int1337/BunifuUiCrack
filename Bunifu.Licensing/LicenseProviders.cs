#if NET5_0_OR_NETFRAMEWORK
using System.Runtime.CompilerServices;
#endif
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Bunifu.Licensing.Models;
using Bunifu.Licensing.Options;
using Bunifu.Licensing.Views;

namespace Bunifu.Licensing
{
	// Token: 0x02000002 RID: 2
	[DebuggerStepThrough]
	public sealed class LicenseProviders
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static LicenseUsageMode GetContext(LicenseContext context)
		{
#if SKIP_LICENSE_CHECK
			// When SKIP_LICENSE_CHECK is defined, always return Designtime to avoid runtime checks
			return LicenseUsageMode.Designtime;
#else
			LicenseUsageMode licenseUsageMode = LicenseUsageMode.Designtime;
			bool flag = Application.ExecutablePath.IndexOf("DesignToolsServer.exe", StringComparison.OrdinalIgnoreCase) > -1;
			if (flag)
			{
				licenseUsageMode = LicenseUsageMode.Designtime;
			}
			return licenseUsageMode;
#endif
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002080 File Offset: 0x00000280
		private static License InvokeActivation(ProductTypes product, LicenseContext context, Type type, LicenseProviders.LicenseStatus status, bool reshow = false, bool f1ad718eb = true)
		{
#if SKIP_LICENSE_CHECK
			// When SKIP_LICENSE_CHECK is defined, return a valid license without any checks
			var license = LicenseBypass.CreateFakeLicense(product);
			LicenseValidator.RetrievedLicense = license as Record;
			return license;
#else
			bool flag = false;
			LicenseProviders._f1ad718eb = f1ad718eb;
			bool flag2 = product == ProductTypes.UIWinForms;
			if (flag2)
			{
				flag = LicenseProviders._activator.UIWinFormsWasCancelled;
			}
			else
			{
				bool flag3 = product == ProductTypes.DatavizBasicWinForms;
				if (flag3)
				{
					flag = LicenseProviders._activator.DatavizBasicWasCancelled;
				}
				else
				{
					bool flag4 = product == ProductTypes.DatavizAdvancedWinForms;
					if (flag4)
					{
						flag = LicenseProviders._activator.DatavizAdvancedWasCancelled;
					}
					else
					{
						bool flag5 = product == ProductTypes.Charts;
						if (flag5)
						{
							flag = LicenseProviders._activator.ChartsWasCancelled;
						}
					}
				}
			}
			bool flag6 = !flag || reshow;
			License license;
			if (flag6)
			{
				LicenseProviders._activator.ShowDialog();
				bool flag7 = !LicenseActivator.LicenseCreated;
				if (flag7)
				{
					bool flag8 = !reshow;
					if (flag8)
					{
						bool flag9 = status == LicenseProviders.LicenseStatus.NonExistent;
						if (flag9)
						{
							LicenseValidator.ThrowLicenseNonExistentException();
						}
						else
						{
							bool flag10 = status == LicenseProviders.LicenseStatus.Expired;
							if (flag10)
							{
								LicenseValidator.ThrowLicenseExpiredException();
							}
							else
							{
								bool flag11 = status == LicenseProviders.LicenseStatus.Invalid;
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
					bool flag13 = status == LicenseProviders.LicenseStatus.NonExistent;
					if (flag13)
					{
						LicenseValidator.ThrowLicenseNonExistentException();
					}
					else
					{
						bool flag14 = status == LicenseProviders.LicenseStatus.Expired;
						if (flag14)
						{
							LicenseValidator.ThrowLicenseExpiredException();
						}
						else
						{
							bool flag15 = status == LicenseProviders.LicenseStatus.Invalid;
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
#endif
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000221C File Offset: 0x0000041C
		private static License GetProductLicense(ProductTypes product, LicenseContext context, Type type)
		{
#if SKIP_LICENSE_CHECK
			// When SKIP_LICENSE_CHECK is defined, return a valid license without any checks
			var license = LicenseBypass.CreateFakeLicense(product);
			LicenseValidator.RetrievedLicense = license as Record;
			return license;
#else
			LicenseUsageMode context2 = LicenseProviders.GetContext(context);
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
							bool flag5 = !LicenseProviders._freeTrialExpiredShown;
							if (flag5)
							{
								LicenseProviders._freeTrialExpiredShown = true;
								int totalDays = LicenseValidator.RetrievedLicense.License.TotalDays;
								string licenseKey = LicenseValidator.RetrievedLicense._licenseKey;
								LicenseValidator.DeleteLicense(false);
								bool flag6 = LicenseValidator.RetrievedLicense.License.Type == LicenseTypes.Trial;
								if (flag6)
								{
									DialogResult dialogResult = LicenseProviders._freeTrialEnded.ShowDialog(totalDays);
									bool flag7 = dialogResult == DialogResult.Cancel;
									if (flag7)
									{
										license = LicenseProviders.InvokeActivation(product, context, type, LicenseProviders.LicenseStatus.Expired, false, true);
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
									license = LicenseProviders.InvokeActivation(product, context, type, LicenseProviders.LicenseStatus.Expired, false, true);
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
								LicenseContext context3 = context;
								Type type2 = type;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
								defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted<LicenseTypes>(LicenseValidator.RetrievedLicense.License.Type);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(LicenseValidator.RetrievedLicense.LicenseKey);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(type.Name);
								context3.SetSavedLicenseKey(type2, defaultInterpolatedStringHandler.ToStringAndClear());
								license = LicenseValidator.RetrievedLicense;
							}
							else
							{
								LicenseValidator.DeleteLicense(false);
								license = LicenseProviders.InvokeActivation(product, context, type, LicenseProviders.LicenseStatus.Invalid, false, true);
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
								LicenseContext context4 = context;
								Type type3 = type;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 4);
								defaultInterpolatedStringHandler.AppendFormatted<ProductTypes>(product);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted<LicenseTypes>(LicenseValidator.RetrievedLicense.License.Type);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(LicenseValidator.RetrievedLicense.LicenseKey);
								defaultInterpolatedStringHandler.AppendLiteral(",");
								defaultInterpolatedStringHandler.AppendFormatted(type.Name);
								context4.SetSavedLicenseKey(type3, defaultInterpolatedStringHandler.ToStringAndClear());
								license = LicenseValidator.RetrievedLicense;
							}
							else
							{
								LicenseValidator.DeleteLicense(false);
								license = LicenseProviders.InvokeActivation(product, context, type, LicenseProviders.LicenseStatus.Invalid, false, true);
							}
						}
					}
					else
					{
						bool flag14 = context2 == LicenseUsageMode.Designtime;
						if (flag14)
						{
							LicenseValidator.DeleteLicense(false);
							license = LicenseProviders.InvokeActivation(product, context, type, LicenseProviders.LicenseStatus.NonExistent, false, true);
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
				string savedLicenseKey = context.GetSavedLicenseKey(type, null);
				bool flag15 = savedLicenseKey != null;
				if (flag15)
				{
					string[] array = savedLicenseKey.Split(new char[] { ',' });
					bool flag16 = LicenseValidator.GetTypeEnum(array[1]) == LicenseTypes.Trial && !LicenseProviders._trialBoxShown;
					if (flag16)
					{
						bool flag17 = LicenseProviders.DevelopmentMode();
						if (flag17)
						{
							LicenseProviders._trialBox.ShowApplyNewLicenseButton = true;
							LicenseProviders._trialBox.OnClickActivatePremium = delegate
							{
								LicenseProviders.InvokeActivation(product, context, type, LicenseProviders.LicenseStatus.Expired, true, false);
							};
						}
						else
						{
							LicenseProviders._trialBox.ShowApplyNewLicenseButton = false;
						}
						LicenseProviders._trialBox.ShowDialog();
						LicenseProviders._trialBoxShown = true;
					}
					license = new Record();
				}
				else
				{
					bool flag18 = type.Name == "BunifuDataGridView";
					if (flag18)
					{
						license = new Record();
					}
					else
					{
						LicenseValidator.ThrowRuntimeLicenseException();
						license = null;
					}
				}
			}
			return license;
#endif
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000026E4 File Offset: 0x000008E4
		private static bool DevelopmentMode()
		{
			bool flag;
			try
			{
				flag = Debugger.IsAttached;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x04000001 RID: 1
		internal static bool _f1ad718eb = true;

		// Token: 0x04000002 RID: 2
		private static bool _trialBoxShown = false;

		// Token: 0x04000003 RID: 3
		private static bool _freeTrialExpiredShown = false;

		// Token: 0x04000004 RID: 4
		private static FreeTrialEnded _freeTrialEnded = new FreeTrialEnded();

		// Token: 0x04000005 RID: 5
		internal static TrialBox _trialBox = new TrialBox();

		// Token: 0x04000006 RID: 6
		internal static LicenseActivator _activator = new LicenseActivator();

		// Token: 0x0200003A RID: 58
		private enum LicenseStatus
		{
			// Token: 0x04000198 RID: 408
			NonExistent,
			// Token: 0x04000199 RID: 409
			Expired,
			// Token: 0x0400019A RID: 410
			Invalid
		}

		// Token: 0x0200003B RID: 59
		[DebuggerStepThrough]
		public class UIWinFormsLicenseProvider : LicenseProvider
		{
			// Token: 0x06000271 RID: 625 RVA: 0x00017B4C File Offset: 0x00015D4C
			public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
			{
#if SKIP_LICENSE_CHECK
				// When SKIP_LICENSE_CHECK is defined, return a valid license without any checks
				var license = LicenseBypass.CreateFakeLicense(ProductTypes.UIWinForms);
				LicenseValidator.RetrievedLicense = license as Record;
				return license;
#else
				return LicenseProviders.GetProductLicense(ProductTypes.UIWinForms, context, type);
#endif
			}
		}

		// Token: 0x0200003C RID: 60
		[DebuggerStepThrough]
		public class DatavizBasicLicenseProvider : LicenseProvider
		{
			// Token: 0x06000273 RID: 627 RVA: 0x00017B70 File Offset: 0x00015D70
			public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
			{
#if SKIP_LICENSE_CHECK
				// When SKIP_LICENSE_CHECK is defined, return a valid license without any checks
				var license = LicenseBypass.CreateFakeLicense(ProductTypes.DatavizBasicWinForms);
				LicenseValidator.RetrievedLicense = license as Record;
				return license;
#else
				return LicenseProviders.GetProductLicense(ProductTypes.DatavizBasicWinForms, context, type);
#endif
			}
		}

		// Token: 0x0200003D RID: 61
		[DebuggerStepThrough]
		public class DatavizAdvancedLicenseProvider : LicenseProvider
		{
			// Token: 0x06000275 RID: 629 RVA: 0x00017B94 File Offset: 0x00015D94
			public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
			{
#if SKIP_LICENSE_CHECK
				// When SKIP_LICENSE_CHECK is defined, return a valid license without any checks
				var license = LicenseBypass.CreateFakeLicense(ProductTypes.DatavizAdvancedWinForms);
				LicenseValidator.RetrievedLicense = license as Record;
				return license;
#else
				return LicenseProviders.GetProductLicense(ProductTypes.DatavizAdvancedWinForms, context, type);
#endif
			}
		}

		// Token: 0x0200003E RID: 62
		[DebuggerStepThrough]
		public class ChartsLicenseProvider : LicenseProvider
		{
			// Token: 0x06000277 RID: 631 RVA: 0x00017BB8 File Offset: 0x00015DB8
			public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
			{
#if SKIP_LICENSE_CHECK
				// When SKIP_LICENSE_CHECK is defined, return a valid license without any checks
				var license = LicenseBypass.CreateFakeLicense(ProductTypes.Charts);
				LicenseValidator.RetrievedLicense = license as Record;
				return license;
#else
				return LicenseProviders.GetProductLicense(ProductTypes.Charts, context, type);
#endif
			}
		}
	}
}
