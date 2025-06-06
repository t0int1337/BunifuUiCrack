using System;
using System.Diagnostics;
using System.Windows.Forms;
using Bunifu.Licensing.Properties;

namespace Bunifu.Licensing.Views
{
	// Token: 0x02000007 RID: 7
	[DebuggerStepThrough]
	internal static class InformationBoxHelper
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x0000AAB4 File Offset: 0x00008CB4
		public static bool Show(string message, string title, string moreInfoText = "", InformationBox.InformationBoxIcons icon = InformationBox.InformationBoxIcons.Information, string okayText = "Okay", string cancelText = "")
		{
			InformationBox informationBox = new InformationBox();
			informationBox.lblMessage.Text = message;
			informationBox.MoreInformationText = moreInfoText;
			informationBox.btnOkay.Text = okayText;
			informationBox.btnCancel.Text = cancelText;
			bool flag = string.IsNullOrWhiteSpace(title);
			if (flag)
			{
				informationBox.lblWindowTitle.Text = "Bunifu Framework";
			}
			else
			{
				informationBox.lblWindowTitle.Text = title;
			}
			bool flag2 = string.IsNullOrWhiteSpace(cancelText);
			if (flag2)
			{
				informationBox.btnCancel.Hide();
			}
			else
			{
				informationBox.btnCancel.Show();
			}
			bool flag3 = string.IsNullOrWhiteSpace(moreInfoText);
			if (flag3)
			{
				informationBox.lnkMoreInfo.Hide();
			}
			else
			{
				informationBox.lnkMoreInfo.Show();
			}
			bool flag4 = informationBox.IsTextURL(moreInfoText);
			if (flag4)
			{
				informationBox.toolTip.SetToolTip(informationBox.lnkMoreInfo, "Go to " + moreInfoText);
			}
			else
			{
				informationBox.toolTip.SetToolTip(informationBox.lnkMoreInfo, "View more information on this...");
			}
			bool flag5 = icon == InformationBox.InformationBoxIcons.Information;
			if (flag5)
			{
				informationBox.pbIcon.Image = Resources.information;
			}
			else
			{
				bool flag6 = icon == InformationBox.InformationBoxIcons.Warning;
				if (flag6)
				{
					informationBox.pbIcon.Image = Resources.yellow_warning;
				}
				else
				{
					bool flag7 = icon == InformationBox.InformationBoxIcons.Alert;
					if (flag7)
					{
						informationBox.pbIcon.Image = Resources.red_warning;
					}
					else
					{
						bool flag8 = icon == InformationBox.InformationBoxIcons.Error;
						if (flag8)
						{
							informationBox.pbIcon.Image = Resources.error;
						}
					}
				}
			}
			informationBox.lblMessage.Top = (informationBox.pnlBody.Height - informationBox.lblMessage.Height) / 2;
			DialogResult dialogResult = informationBox.ShowDialog();
			return dialogResult == DialogResult.OK;
		}
	}
}
