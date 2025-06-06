#if NETFRAMEWORK && NET40_OR_GREATER
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bunifu.Licensing.Compatibility
{
    /// <summary>
    /// Extension methods for string operations to support compatibility across frameworks
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Split a string with StringSplitOptions
        /// </summary>
        public static string[] Split(this string str, char[] separator, StringSplitOptions options)
        {
            return str.Split(separator, options);
        }

        /// <summary>
        /// Split a string with a single character and StringSplitOptions
        /// </summary>
        public static string[] Split(this string str, char separator, StringSplitOptions options)
        {
            return str.Split(new[] { separator }, options);
        }
    }
}
#endif 