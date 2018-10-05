using CoinpaprikaAPI.Base;
using CoinpaprikaAPI.Entity;
using CoinpaprikaAPI.JsonConverters;
using CoinpaprikaAPI.Models;
using CoinpaprikaAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinpaprikaAPI
{
    public class Client
    {
        private readonly string _apiBaseUrl;

        public Client(string version = "v1")
        {
            _apiBaseUrl = $"https://api.coinpaprika.com/{version}";
        }

        public async Task<CoinPaprikaEntity<Global>> GetClobalsAsync()
        {
            var client = BaseClient.GetClient();
            
            var requestUrl = $"{_apiBaseUrl}/global";
            
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return new CoinPaprikaEntity<Global>(response, false, false, null);
            else
                return new CoinPaprikaEntity<Global>(response, false, true, null);
        }

        public async Task<CoinPaprikaEntity<List<CoinInfo>>> GetCoinsAsync()
        {
            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/coins";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return new CoinPaprikaEntity<List<CoinInfo>>(response, false, false, null);
            else
                return new CoinPaprikaEntity<List<CoinInfo>>(response, false, true, null);
        }

        public async Task<CoinPaprikaEntity<List<TickerInfo>>> GetTickerForAll()
        {
            var converters = new List<JsonConverter>() { StringToDezimalConverter.Instance, StringToIntConverter.Instance, StringToLongConverter.Instance };

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/ticker";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return new CoinPaprikaEntity<List<TickerInfo>>(response, false, false, converters);
            else
                return new CoinPaprikaEntity<List<TickerInfo>>(response, false, true, converters);
        }

        public async Task<CoinPaprikaEntity<TickerInfo>> GetTickerForCoin(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotSupportedException("id must be defined");

            var converters = new List<JsonConverter>() { StringToDezimalConverter.Instance, StringToIntConverter.Instance, StringToLongConverter.Instance };

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/ticker/{id}";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)            
                return new CoinPaprikaEntity<TickerInfo>(response, false, false, converters);
            else            
                return new CoinPaprikaEntity<TickerInfo>(response, false, true, converters);
        }


        public async Task<CoinPaprikaEntity<SearchResult>> SearchAsync(string searchterms, int limit = 6, List<SearchCategory> searchCategories = null)
        {
            if (limit < 1 || limit > 250)
                throw new ArgumentOutOfRangeException(nameof(limit), "limit must be between 1 and 250");

            string categoriesToSearch = string.Empty;
            if (searchCategories == null)
                categoriesToSearch = "currencies,exchanges,icos,people,tags";
            else
            {
                foreach (var category in searchCategories)
                {
                    if (!string.IsNullOrWhiteSpace(categoriesToSearch))
                        categoriesToSearch += ",";

                    categoriesToSearch += category.ToString().ToLowerInvariant();
                }
            }

            var client = BaseClient.GetClient();

            var requestUrl = $"{_apiBaseUrl}/search?q={WebUtility.UrlEncode(searchterms)}&c={categoriesToSearch}&limit={limit}";

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUrl)
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return new CoinPaprikaEntity<SearchResult>(response, false, false, null);
            else
                return new CoinPaprikaEntity<SearchResult>(response, false, true, null);
        }
    }
}
