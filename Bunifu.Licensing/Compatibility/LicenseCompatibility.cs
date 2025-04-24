using System;
using System.Collections;

// Define compatibility types for .NET Framework only
#if NETFRAMEWORK && NET40_OR_GREATER
namespace System.ComponentModel
{
    // Create a custom License implementation if needed
    // This will only be used if the System.ComponentModel.License cannot be found
    public class License : IDisposable
    {
        public virtual string LicenseKey { get; set; }

        public virtual void Dispose()
        {
            // Cleanup
        }
    }

    // Define LicenseContext for compatibility
    public class LicenseContext
    {
        private Hashtable _savedLicenseKeys;

        public LicenseContext()
        {
            _savedLicenseKeys = new Hashtable();
        }

        public string GetSavedLicenseKey(Type type)
        {
            if (_savedLicenseKeys == null)
                return null;

            return (string)_savedLicenseKeys[type];
        }

        public string GetSavedLicenseKey(Type type, object instance)
        {
            return GetSavedLicenseKey(type);
        }

        public void SetSavedLicenseKey(Type type, string key)
        {
            if (_savedLicenseKeys == null)
                _savedLicenseKeys = new Hashtable();

            _savedLicenseKeys[type] = key;
        }
    }

    // Define LicenseUsageMode enum
    public enum LicenseUsageMode
    {
        Runtime,
        Designtime
    }

    // Define LicenseManager for compatibility
    public static class LicenseManager
    {
        private static LicenseUsageMode _usageMode = LicenseUsageMode.Runtime;

        public static LicenseUsageMode UsageMode 
        { 
            get { return _usageMode; }
            set { _usageMode = value; }
        }

        public static License Validate(Type type, object instance)
        {
            return new License();
        }
    }

    // LicenseProvider class
    public abstract class LicenseProvider
    {
        public abstract License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions);
    }
}
#endif 