using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bunifu.Licensing.Helpers
{
	// Token: 0x02000039 RID: 57
	[DebuggerStepThrough]
	internal static class Shadower
	{
		// Token: 0x06000269 RID: 617
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Shadower.MARGINS pMarInset);

		// Token: 0x0600026A RID: 618
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

		// Token: 0x0600026B RID: 619
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

		// Token: 0x0600026C RID: 620 RVA: 0x00017A78 File Offset: 0x00015C78
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool IsCompositionEnabled()
		{
			bool flag = Environment.OSVersion.Version.Major < 6;
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				bool flag3;
				Shadower.DwmIsCompositionEnabled(out flag3);
				flag2 = flag3;
			}
			return flag2;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00017AB0 File Offset: 0x00015CB0
		public static void ApplyShadows(Form form)
		{
			int num = 2;
			Shadower.DwmSetWindowAttribute(form.Handle, 2, ref num, 4);
			Shadower.MARGINS margins = new Shadower.MARGINS
			{
				bottomHeight = 1,
				leftWidth = 0,
				rightWidth = 0,
				topHeight = 0
			};
			Shadower.DwmExtendFrameIntoClientArea(form.Handle, ref margins);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00017B08 File Offset: 0x00015D08
		public static bool IsAeroEnabled()
		{
			bool flag = Environment.OSVersion.Version.Major >= 6;
			bool flag2;
			if (flag)
			{
				int num = 0;
				Shadower.DwmIsCompositionEnabled(ref num);
				flag2 = num == 1;
			}
			else
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x0600026F RID: 623
		[DllImport("dwmapi.dll")]
		private static extern int DwmIsCompositionEnabled(out bool enabled);

		// Token: 0x06000270 RID: 624
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x0400018D RID: 397
		private static bool _isAeroEnabled;

		// Token: 0x0400018E RID: 398
		private static bool _isDraggingEnabled;

		// Token: 0x0400018F RID: 399
		private const int WM_NCHITTEST = 132;

		// Token: 0x04000190 RID: 400
		private const int WS_MINIMIZEBOX = 131072;

		// Token: 0x04000191 RID: 401
		private const int HTCLIENT = 1;

		// Token: 0x04000192 RID: 402
		private const int HTCAPTION = 2;

		// Token: 0x04000193 RID: 403
		private const int CS_DBLCLKS = 8;

		// Token: 0x04000194 RID: 404
		private const int CS_DROPSHADOW = 131072;

		// Token: 0x04000195 RID: 405
		private const int WM_NCPAINT = 133;

		// Token: 0x04000196 RID: 406
		private const int WM_ACTIVATEAPP = 28;

		// Token: 0x0200004E RID: 78
		[EditorBrowsable(EditorBrowsableState.Never)]
		public struct MARGINS
		{
			// Token: 0x040001DD RID: 477
			public int leftWidth;

			// Token: 0x040001DE RID: 478
			public int rightWidth;

			// Token: 0x040001DF RID: 479
			public int topHeight;

			// Token: 0x040001E0 RID: 480
			public int bottomHeight;
		}
	}
}
