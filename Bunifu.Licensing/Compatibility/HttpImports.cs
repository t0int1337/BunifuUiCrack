using System;

#if NET5_0_OR_GREATER || NET6_0_OR_GREATER
using System.Net.Http;
using System.Net.Http.Headers;
#endif

namespace Bunifu.Licensing.Compatibility
{
    // This class ensures that HTTP types are properly imported
    internal static class HttpImports
    {
        // Method to reference the types so they are included in compilation
        internal static void ReferenceHttpTypes()
        {
#if NET5_0_OR_GREATER || NET6_0_OR_GREATER
            var client = new HttpClient();
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
#endif
        }
    }
} 