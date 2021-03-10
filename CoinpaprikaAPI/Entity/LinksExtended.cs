using System;
using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class LinksExtended
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("stats", NullValueHandling = NullValueHandling.Ignore)]
        public Stats Stats { get; set; }
    }
}
