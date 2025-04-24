#if NETFRAMEWORK && !NET5_0_OR_GREATER
using System;

namespace System.Runtime.Versioning
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class TargetPlatformAttribute : Attribute
    {
        public TargetPlatformAttribute(string targetPlatformName)
        {
            PlatformName = targetPlatformName;
        }

        public string PlatformName { get; }
    }

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class SupportedOSPlatformAttribute : Attribute
    {
        public SupportedOSPlatformAttribute(string platformName)
        {
            PlatformName = platformName;
        }

        public string PlatformName { get; }
    }
}
#endif 