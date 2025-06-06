using System;
using System.Diagnostics;

namespace Bunifu.Licensing.Options
{
	// Token: 0x0200002B RID: 43
	[DebuggerStepThrough]
	internal sealed class Strings
	{
		// Token: 0x02000049 RID: 73
		internal sealed class Application
		{
			// Token: 0x040001C0 RID: 448
			internal static string PricingURL = "https://bunifuframework.com/pricing";
		}

		// Token: 0x0200004A RID: 74
		internal sealed class Exceptions
		{
			// Token: 0x040001C1 RID: 449
			internal static string NetworkUnavailable = "You have no Internet connection at the moment.\nPlease try reconnecting first.";

			// Token: 0x040001C2 RID: 450
			internal static string ServerUnreachable = "There was an issue trying to reach the server.\nPlease try again.";

			// Token: 0x040001C3 RID: 451
			internal static string LicenseBlocked = "[403] Your license has been blocked.";

			// Token: 0x040001C4 RID: 452
			internal static string BuildTimeError = "There was an issue validating your license.\nIf this dialog has been run when building your project, please close it and reopen any Form with Bunifu controls for activation to occur successfully.";

			// Token: 0x040001C5 RID: 453
			internal static string JSONObjectParseFailed = "There was an issue validating your license.\n\nIf this issue persists, please try:\n  • Running Visual Studio as an Administrator.\n  • Checking your Internet's Firewall congifuration.";

			// Token: 0x040001C6 RID: 454
			internal static string LicenseNotFound = "The license you've entered appears unavailable.\nPlease use a valid license and try again.";

			// Token: 0x040001C7 RID: 455
			internal static string ProductLicenseMismatch = "The license you've entered refers to another product.\nPlease change the details and try again.";

			// Token: 0x040001C8 RID: 456
			internal const string UIRuntimeLicenseInvalid = "This product does not have a registered Bunifu UI license to run.";

			// Token: 0x040001C9 RID: 457
			internal const string ChartsRuntimeLicenseInvalid = "This product does not have a registered Bunifu Charts license to run.";

			// Token: 0x040001CA RID: 458
			internal const string DatavizBasicRuntimeLicenseInvalid = "This product does not have a registered Bunifu Dataviz license to run.";

			// Token: 0x040001CB RID: 459
			internal const string DatavizAdvancedRuntimeLicenseInvalid = "This product does not have a registered Bunifu Dataviz license to run.";

			// Token: 0x040001CC RID: 460
			internal const string UILicenseInvalid = "Please ensure you have a valid Bunifu UI WinForms license.";

			// Token: 0x040001CD RID: 461
			internal const string DatavizBasicLicenseInvalid = "Please ensure you have a valid Bunifu Dataviz Basic license.";

			// Token: 0x040001CE RID: 462
			internal const string DatavizAdvancedLicenseInvalid = "Please ensure you have a valid Bunifu Dataviz Advanced license.";

			// Token: 0x040001CF RID: 463
			internal const string ChartsLicenseInvalid = "Please ensure you have a valid Bunifu Charts license.";

			// Token: 0x040001D0 RID: 464
			internal const string UILicenseInactive = "Please ensure you have an active Bunifu UI WinForms license.";

			// Token: 0x040001D1 RID: 465
			internal const string DatavizBasicLicenseInactive = "Please ensure you have an active Bunifu Dataviz Basic license.";

			// Token: 0x040001D2 RID: 466
			internal const string DatavizAdvancedLicenseInactive = "Please ensure you have an active Bunifu Dataviz Advanced license.";

			// Token: 0x040001D3 RID: 467
			internal const string ChartsLicenseInactive = "Please ensure you have an active Bunifu Charts license.";

			// Token: 0x040001D4 RID: 468
			internal const string UILicenseExpired = "Your Bunifu UI WinForms license has expired.";

			// Token: 0x040001D5 RID: 469
			internal const string DatavizBasicLicenseExpired = "Your Bunifu Dataviz Basic license has expired.";

			// Token: 0x040001D6 RID: 470
			internal const string DatavizAdvancedLicenseExpired = "Your Bunifu Dataviz Advanced license has expired.";

			// Token: 0x040001D7 RID: 471
			internal const string ChartsLicenseExpired = "Your Bunifu Charts license has expired.";

			// Token: 0x040001D8 RID: 472
			internal const string UILicenseBlocked = "Your Bunifu UI license has been blocked.";

			// Token: 0x040001D9 RID: 473
			internal const string DatavizBasicLicenseBlocked = "Your Bunifu Dataviz Basic license has been blocked.";

			// Token: 0x040001DA RID: 474
			internal const string DatavizAdvancedLicenseBlocked = "Your Bunifu Dataviz Advanced license has been blocked.";

			// Token: 0x040001DB RID: 475
			internal const string ChartsLicenseBlocked = "Your Bunifu Charts license has been blocked.";

			// Token: 0x040001DC RID: 476
			internal const string SystemBackdated = "Please ensure your System Date/Time is correct.";
		}
	}
}
