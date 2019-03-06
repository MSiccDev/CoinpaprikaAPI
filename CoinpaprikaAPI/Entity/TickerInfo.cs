using CoinpaprikaAPI.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

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
        public long Rank { get; set; }

        [JsonProperty("price_usd")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal PriceUsd { get; set; }

        [JsonProperty("price_btc")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal PriceBtc { get; set; }

        [JsonProperty("volume_24h_usd")]
        [JsonConverter(typeof(StringToDezimalConverter))]
        public decimal Volume24HUsd { get; set; }

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
        public decimal PercentChange1H { get; set; }

        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d")]
        public decimal PercentChange7D { get; set; }

        [JsonProperty("last_updated")]
        [JsonConverter(typeof(StringToDateTimeOffsetConverter))]
        public DateTimeOffset LastUpdated { get; set; }

    }
}
