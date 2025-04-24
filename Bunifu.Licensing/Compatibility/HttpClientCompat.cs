#if NET40_OR_GREATER && !NET5_0_OR_GREATER
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bunifu.Licensing.Compatibility
{
    internal static class HttpClientCompat
    {
        public static string PostJson(string url, string jsonContent)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                return client.UploadString(url, jsonContent);
            }
        }

        public static string GetString(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
#endif 