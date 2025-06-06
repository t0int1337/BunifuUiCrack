using System.Runtime.CompilerServices;

namespace Bunifu.Licensing.Compatibility
{
    // This class ensures that all compatibility types are properly imported
    internal static class StringImports
    {
        // Method to reference the types so they are included in compilation
        internal static void ReferenceStringHandlerTypes()
        {
#if NETFRAMEWORK || NET5_0 || NET5_0_OR_NETFRAMEWORK
            var handler = new DefaultInterpolatedStringHandler(10, 2);
            handler.AppendLiteral("Test");
            handler.AppendFormatted("value");
            var result = handler.ToStringAndClear();
#endif
        }
    }
} 