using System;
using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class Contract
    {
        [JsonProperty("contract")]
        public string Name { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
