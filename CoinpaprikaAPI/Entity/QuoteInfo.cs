using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class QuoteInfo
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public decimal Volume24H { get; set; }

        [JsonProperty("volume_24h_change_24h")]
        public decimal Volume24HChange24H { get; set; }

        [JsonProperty("market_cap")]
        public long MarketCap { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public decimal MarketCapChange24H { get; set; }

        [JsonProperty("percent_change_1h")]
        public decimal PercentChange1H { get; set; }

        [JsonProperty("percent_change_12h")]
        public decimal PercentChange12H { get; set; }

        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d")]
        public decimal PercentChange7D { get; set; }

        [JsonProperty("percent_change_30d")]
        public decimal PercentChange30D { get; set; }

        [JsonProperty("percent_change_1y")]
        public decimal PercentChange1Y { get; set; }

        [JsonProperty("ath_price")]
        public decimal? AthPrice { get; set; }

        [JsonProperty("ath_date")]
        public DateTimeOffset? AthDate { get; set; }

        [JsonProperty("percent_from_price_ath")]
        public decimal? PercentFromPriceAth { get; set; }
    }
}
