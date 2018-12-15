using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class MarketQuoteInfo
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24H { get; set; }
    }
}