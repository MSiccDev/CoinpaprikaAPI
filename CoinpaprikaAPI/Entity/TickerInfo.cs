using CoinpaprikaAPI.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinpaprikaAPI.Entity
{
    public class TickerInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rank")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int Rank { get; set; }

        [JsonProperty("price_usd")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal PriceUsd { get; set; }

        [JsonProperty("price_btc")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal PriceBtc { get; set; }

        [JsonProperty("volume_24h_usd")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Volume24hUsd { get; set; }

        [JsonProperty("market_cap_usd")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long MarketCapUsd { get; set; }

        [JsonProperty("circulating_supply")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long MaxSupply { get; set; }

        [JsonProperty("percent_change_1h")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal PercentChange1h { get; set; }

        [JsonProperty("percent_change_24h")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal PercentChange24h { get; set; }

        [JsonProperty("percent_change_7d")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal PercentChange7d { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }
    }
}
