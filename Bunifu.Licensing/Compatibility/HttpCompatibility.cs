#if !NET5_0_OR_GREATER
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace System.Net.Http
{
    // Basic HttpClient implementation for .NET Framework
    public class HttpClient : IDisposable
    {
        private readonly WebClient _webClient;

        public HttpClient()
        {
            _webClient = new WebClient();
            DefaultRequestHeaders = new HttpRequestHeaders();
        }

        public Uri BaseAddress { get; set; }
        public HttpRequestHeaders DefaultRequestHeaders { get; private set; }

        public Task<HttpResponseMessage> PostAsync(string requestUri, StringContent content)
        {
            try
            {
                string fullUri = BaseAddress != null ? new Uri(BaseAddress, requestUri).ToString() : requestUri;
                
                foreach (var header in DefaultRequestHeaders.AcceptHeaders)
                {
                    _webClient.Headers.Add("Accept", header);
                }
                
                _webClient.Headers.Add("Content-Type", content.MediaType);
                byte[] responseBytes = _webClient.UploadData(fullUri, "POST", content.GetBytes());
                
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new ByteArrayContent(responseBytes)
                };
                
                return Task.FromResult(response);
            }
            catch (WebException ex)
            {
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                if (ex.Response is HttpWebResponse webResponse)
                {
                    statusCode = webResponse.StatusCode;
                }
                
                var response = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(ex.Message)
                };
                
                return Task.FromResult(response);
            }
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }
    }

    public class HttpRequestHeaders
    {
        private readonly List<string> _acceptHeaders = new List<string>();
        
        public List<string> AcceptHeaders => _acceptHeaders;
        
        public void Clear()
        {
            _acceptHeaders.Clear();
        }
        
        public void Add(MediaTypeWithQualityHeaderValue header)
        {
            _acceptHeaders.Add(header.ToString());
        }
    }

    public class HttpResponseMessage
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpContent Content { get; set; }
        
        public override string ToString()
        {
            return StatusCode.ToString();
        }
    }

    public abstract class HttpContent
    {
        public abstract string ToString();
    }

    public class StringContent : HttpContent
    {
        private readonly string _content;
        private readonly byte[] _contentBytes;
        
        public string MediaType { get; }
        
        public StringContent(string content, Encoding encoding, string mediaType)
        {
            _content = content;
            _contentBytes = encoding.GetBytes(content);
            MediaType = mediaType;
        }
        
        // Add parameterless constructor for .NET Framework compatibility
        public StringContent(string content) : this(content, Encoding.UTF8, "text/plain")
        {
        }
        
        public byte[] GetBytes()
        {
            return _contentBytes;
        }
        
        public override string ToString()
        {
            return _content;
        }
    }

    public class ByteArrayContent : HttpContent
    {
        private readonly byte[] _content;
        
        public ByteArrayContent(byte[] content)
        {
            _content = content;
        }
        
        public override string ToString()
        {
            return Encoding.UTF8.GetString(_content);
        }
    }

    public class MediaTypeWithQualityHeaderValue
    {
        private readonly string _mediaType;
        
        public MediaTypeWithQualityHeaderValue(string mediaType)
        {
            _mediaType = mediaType;
        }
        
        public override string ToString()
        {
            return _mediaType;
        }
    }
}
#endif 