using System;
using System.Threading;
using System.Windows.Forms;

namespace Bunifu.Licensing.Compatibility
{
    /// <summary>
    /// Helper methods for delegate compatibility across different .NET versions
    /// </summary>
    internal static class DelegateExtensions
    {
        // Helper method to create a ThreadStart delegate
        public static ThreadStart CreateThreadStart(Action action)
        {
            return new ThreadStart(action);
        }

        // Helper method to create a MethodInvoker delegate
        public static MethodInvoker CreateMethodInvoker(Action action)
        {
            return new MethodInvoker(action);
        }
    }
} 