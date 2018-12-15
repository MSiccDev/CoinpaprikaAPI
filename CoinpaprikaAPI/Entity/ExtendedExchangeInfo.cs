using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExtendedExchangeInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("links")]
        public ExchangeLinks Links { get; set; }

        [JsonProperty("markets_data_fetched")]
        public bool MarketsDataFetched { get; set; }

        [JsonProperty("adjusted_rank")]
        public long? AdjustedRank { get; set; }

        [JsonProperty("reported_rank")]
        public long? ReportedRank { get; set; }

        [JsonProperty("currencies")]
        public long Currencies { get; set; }

        [JsonProperty("markets")]
        public long Markets { get; set; }

        [JsonProperty("fiats")]
        public List<FiatInfo> Fiats { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, ExchangeQuoteInfo> Quotes { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}
