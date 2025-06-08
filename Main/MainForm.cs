using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace BunifuLicenseGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load( object sender, EventArgs e )
        {
            txtHWID.Text = Hardware.GetUniqueID();
            cmbProduct.SelectedIndex = 0;
        }

        private void btnGenerate_Click( object sender, EventArgs e )
        {
            try
            {
                var productType = (LicenseGenerator.ProductType)cmbProduct.SelectedIndex;
                var licenseKey = txtLicenseKey.Text.Trim();
                var name = txtName.Text.Trim();
                var email = txtEmail.Text.Trim();
                var isEnterprise = chkEnterprise.Checked;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter both name and email.");
                    return;
                }

                string existingLicense = null;

                // Check file
                string licenseFilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    $"Bunifu Technologies/{productType}",
                    "License.lic"
                );

                if (File.Exists(licenseFilePath))
                {
                    string encryptedData = File.ReadAllText(licenseFilePath);
                    existingLicense = Cryptography.Decrypt(encryptedData);
                }

                // Check registry
                else
                {
                    using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey($@"Software\Bunifu Technologies\{productType}"))
                    {
                        if (key != null)
                        {
                            var encryptedData = key.GetValue("CLI") as string;
                            if (!string.IsNullOrEmpty(encryptedData))
                            {
                                existingLicense = Cryptography.Decrypt(encryptedData);
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(existingLicense))
                {
                    var existingRecord = JsonConvert.DeserializeObject<LicenseGenerator.LicenseRecord>(existingLicense);
                    MessageBox.Show($"Existing license found. No new license was generated.");
                    return;
                }

                labelStatus.Text = "Generating license...";
                Application.DoEvents();

                string licenseJson = LicenseGenerator.GenerateLicense(productType, email, name, licenseKey, isEnterprise);
                string encryptedLicense = Cryptography.Encrypt(licenseJson);

                LicenseGenerator.SaveLicenseToFile(encryptedLicense, productType);
                LicenseGenerator.SaveLicenseToRegistry(encryptedLicense, productType);

                labelStatus.Text = "License generated and saved successfully!";
                MessageBox.Show("License generated successfully!\n\n" +
                               $"Product: {productType}\n" +
                               $"HWID: {Hardware.GetUniqueID()}\n" +
                               $"Email: {email}\n" +
                               $"License Type: {(isEnterprise ? "Enterprise" : "Premium")}",
                               "Success",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                labelStatus.Text = "Error generating license!";
                MessageBox.Show("Error: " + ex.Message, "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }


    }
}
