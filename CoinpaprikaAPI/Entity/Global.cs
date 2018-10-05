using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class Global
    {
        [JsonProperty("market_cap_usd")]
        public long MarketCapUsd { get; set; }

        [JsonProperty("volume_24h_usd")]
        public long Volume24HUsd { get; set; }

        [JsonProperty("bitcoin_dominance_percentage")]
        public decimal BitcoinDominancePercentage { get; set; }

        [JsonProperty("cryptocurrencies_number")]
        public long CryptocurrenciesNumber { get; set; }

        [JsonProperty("last_updated")]
        public long LastUpdated { get; set; }
    }
}
