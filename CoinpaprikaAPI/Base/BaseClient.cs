using CoinpaprikaAPI.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CoinpaprikaAPI.Base
{
    public abstract class BaseClient
    {
        private static HttpClient _httpClientInstance;

        internal static HttpClient GetClient(DateTime? modifiedSince = null, string userAgent = null, string version = null)
        {
            if (_httpClientInstance == null)
            {
                //making sure we are able to decompress using default methods
                var handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };

                _httpClientInstance = new HttpClient(handler);

                if (modifiedSince.HasValue)
                {
                    _httpClientInstance.DefaultRequestHeaders.IfModifiedSince = new DateTimeOffset(modifiedSince.Value);
                }

                _httpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                _httpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                _httpClientInstance.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));

                _httpClientInstance.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                _httpClientInstance.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

                _httpClientInstance.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(string.IsNullOrEmpty(userAgent) ? Helpers.GetAssemblyName() : userAgent,
                                                                                   string.IsNullOrEmpty(version) ? Helpers.GetAssemblyVersion() : version));

                //stoping round trips
                _httpClientInstance.DefaultRequestHeaders.ExpectContinue = false;
            }

            return _httpClientInstance;
        }

    }
}
