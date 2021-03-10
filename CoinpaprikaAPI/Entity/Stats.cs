using System;
using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class Stats
    {
        [JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
        public long? Members { get; set; }

        [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
        public long? Followers { get; set; }
    }
}
