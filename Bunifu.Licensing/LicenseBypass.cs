#if SKIP_LICENSE_CHECK
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Bunifu.Licensing.Models;
using Bunifu.Licensing.Options;

namespace Bunifu.Licensing
{
    /// <summary>
    /// Helper class for creating fake licenses when SKIP_LICENSE_CHECK is defined
    /// </summary>
    internal static class LicenseBypass
    {
        /// <summary>
        /// Creates a fake license for the given product
        /// </summary>
        internal static License CreateFakeLicense(ProductTypes product)
        {
            // Create a fake record with valid license data
            Record fakeRecord = new Record();
            fakeRecord.IsValid = true;
            fakeRecord.License.Status = StatusOptions.Active;
            fakeRecord.License.Type = LicenseTypes.Enterprise;
            fakeRecord.License.Plan = "Enterprise";
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = product });
            
            // Ensure the license is valid for all products
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.UIWinForms });
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.DatavizBasicWinForms });
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.DatavizAdvancedWinForms });
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.Charts });
            
            // Set license properties to make it valid
            fakeRecord.License.TotalDays = 1000000; // Effectively unlimited
            fakeRecord.License.CreatedAt = DateTime.Now.AddDays(-1);
            
            return fakeRecord;
        }

        /// <summary>
        /// Creates a fake record for activation
        /// </summary>
        internal static Record CreateFakeRecord(string email, string licenseKey, ProductTypes product)
        {
            // Create a fake record with valid license data
            Record fakeRecord = new Record();
            fakeRecord.IsValid = true;
            fakeRecord._licenseKey = licenseKey;
            fakeRecord.Client.Email = email;
            fakeRecord.License.Status = StatusOptions.Active;
            fakeRecord.License.Type = LicenseTypes.Enterprise;
            fakeRecord.License.Plan = "Enterprise";
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = product });
            
            // Ensure the license is valid for all products
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.UIWinForms });
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.DatavizBasicWinForms });
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.DatavizAdvancedWinForms });
            fakeRecord.License.ProductsLicensed.Add(new Product { Name = ProductTypes.Charts });
            
            // Set license properties to make it valid
            fakeRecord.License.TotalDays = 1000000; // Effectively unlimited
            fakeRecord.License.CreatedAt = DateTime.Now.AddDays(-1);
            
            return fakeRecord;
        }
    }
}
#endif 