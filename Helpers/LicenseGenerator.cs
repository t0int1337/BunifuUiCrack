using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public class LicenseGenerator
{

    public enum ProductType
    {
        UIWinForms = 0,
        Charts = 1,
        DatavizBasicWinForms = 2,
        DatavizAdvancedWinForms = 3
    }

    public class Product
    {
        public int id { get; set; }
        public ProductType name { get; set; }
        public string uuid { get; set; }
    }

    public class Client
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public int WPUserID { get; set; }
        public bool IsTeamAdmin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Device
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OS { get; set; }
        public string HardwareID { get; set; }
        public bool Blocked { get; set; }
        public DateTime LastSeen { get; set; }
    }

    public class License
    {
        public int ID { get; set; }
        public string UUID { get; set; }
        public int? BundleID { get; set; }
        public int? TeamID { get; set; }
        public int? UserID { get; set; }
        public int PurchaseID { get; set; }
        public int TotalDays { get; set; }
        public int MaxDevices { get; set; }
        public int Activations { get; set; }
        public int RemainingDevices { get; set; }
        public string Plan { get; set; }
        public string RenewalURL { get; set; }
        public string LicenseKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ProductType Product { get; set; }
        public List<Product> ProductsLicensed { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
    }

    public class LicenseRecord
    {
        public bool IsValid { get; set; }
        public int ID { get; set; }
        public string UUID { get; set; }
        public string LicenseKey { get; set; }
        public string CreatedAt { get; set; }
        public string LastSeen { get; set; }
        public string RemovedAt { get; set; }
        public Client Client { get; set; }
        public Device Device { get; set; }
        public License License { get; set; }
    }

    public static string GenerateLicense( ProductType productType, string email, string name, string licenseKey, bool enterprise )
    {
        return JsonConvert.SerializeObject(new LicenseRecord
        {
            IsValid = true,
            ID = 123456,
            UUID = "Fake-license-uuid-12345",
            LicenseKey = licenseKey,
            CreatedAt = DateTime.Now.ToString("o"),
            LastSeen = "0001-01-01T00:00:00",
            RemovedAt = "0001-01-01T00:00:00",
            Client = new Client
            {
                Blocked = false,
                IsTeamAdmin = false,
                ID = 345678,
                TeamID = 0,
                WPUserID = 0,
                Name = name,
                Email = email,
                CreatedAt = DateTime.Now
            },
            Device = new Device
            {
                ID = 789012,
                Name = Environment.MachineName,
                OS = Environment.OSVersion.ToString(),
                HardwareID = BunifuLicenseGenerator.Hardware.GetUniqueID(),
                Blocked = false,
                LastSeen = DateTime.Now
            },
            License = new License
            {
                ID = 987654,
                UUID = "Fake-license-plan-uuid-67890",
                BundleID = null,
                TeamID = null,
                UserID = null,
                PurchaseID = 112233,
                TotalDays = enterprise ? 9999 : 365,
                MaxDevices = 5,
                Activations = 1,
                RemainingDevices = enterprise ? 9999 : 4,
                Plan = enterprise ? "Enterprise Plan" : "Premium Plan",
                RenewalURL = null,
                LicenseKey = null,
                CreatedAt = DateTime.Now,
                ExpiryDate = enterprise ? DateTime.Now.AddYears(30) : DateTime.Now.AddYears(1),
                Product = productType,
                ProductsLicensed = new List<Product>
                    {
                        new Product
                        {
                            id = (int)productType,
                            name = productType,
                            uuid = null
                        }
                    },
                Type = enterprise ? 2 : 1,
                Status = 0
            }
        }, Newtonsoft.Json.Formatting.None);
    }

  

    public static void SaveLicenseToFile( string encryptedData, ProductType productType )
    {
        string programDataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "Bunifu Technologies"
        );

        string productFolder = Path.Combine(programDataPath, productType.ToString());
        Directory.CreateDirectory(productFolder); 

        string licenseFilePath = Path.Combine(productFolder, "License.lic");

        File.WriteAllText(licenseFilePath, encryptedData);
    }
    public static void SaveLicenseToRegistry( string encryptedData, ProductType productType )
    {
        try
        {
            var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($@"Software\Bunifu Technologies\{productType.ToString()}");
            key.SetValue("CLI", encryptedData);
            key.Close();
        }
        catch (Exception ex)
        {
            throw new Exception("Registry write failed: " + ex.Message);
        }
    }
}