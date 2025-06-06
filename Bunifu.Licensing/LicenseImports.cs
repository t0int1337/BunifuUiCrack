using System;
using System.ComponentModel;

// Import all licensing types from System.ComponentModel
// These will either be the real types from .NET or our compatibility implementations

namespace Bunifu.Licensing
{
    internal class LicenseImports
    {
        // Reference license types to ensure they're available
        internal static void ReferenceLicenseTypes()
        {
            var license = new License();
            var context = new LicenseContext();
            var mode = LicenseUsageMode.Runtime;
            
            // For validation only - code not executed
            if (false)
            {
                license.Dispose();
                var key = license.LicenseKey;
                var savedKey = context.GetSavedLicenseKey(typeof(LicenseImports));
                context.SetSavedLicenseKey(typeof(LicenseImports), "test");
                var validate = LicenseManager.Validate(typeof(LicenseImports), null);
            }
        }
    }
} 