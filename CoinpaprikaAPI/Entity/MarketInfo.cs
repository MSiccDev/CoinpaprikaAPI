using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class MarketInfo
    {
        [JsonProperty("exchange_id")]
        public string ExchangeId { get; set; }

        [JsonProperty("exchange_name")]
        public string ExchangeName { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("base_currency_id")]
        public string BaseCurrencyId { get; set; }

        [JsonProperty("base_currency_name")]
        public string BaseCurrencyName { get; set; }

        [JsonProperty("quote_currency_id")]
        public string QuoteCurrencyId { get; set; }

        [JsonProperty("quote_currency_name")]
        public string QuoteCurrencyName { get; set; }

        [JsonProperty("market_url")]
        public Uri MarketUrl { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        [JsonProperty("outlier")]
        public bool Outlier { get; set; }

        [JsonProperty("adjusted_volume_24h_share")]
        public double AdjustedVolume24HShare { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, MarketQuoteInfo> Quotes { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}
