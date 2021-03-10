using System;
using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class ContractDetailInfo
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
