#if NET5_0_OR_NETFRAMEWORK
using System;
using System.Collections;

namespace System.ComponentModel
{
    // These compatibility classes are needed because we don't have a reference to System.ComponentModel
    // in modern .NET or need to ensure consistent behavior across frameworks
    
    #if !NET5_0_OR_GREATER
    public abstract class License : IDisposable
    {
        protected License() { }
        public abstract string LicenseKey { get; }
        public abstract void Dispose();
    }

    // License provider abstract class
    public abstract class LicenseProvider
    {
        protected LicenseProvider() { }
        public abstract License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions);
    }

    // License context
    public class LicenseContext : IServiceProvider
    {
        public LicenseContext() { }
        
        public virtual object GetService(Type serviceType)
        {
            return null;
        }

        public virtual string GetSavedLicenseKey(Type type, string key)
        {
            return null;
        }

        public virtual void SetSavedLicenseKey(Type type, string key)
        {
        }
    }

    // License usage mode enum
    public enum LicenseUsageMode
    {
        Designtime,
        Runtime
    }
    #endif
}
#endif 