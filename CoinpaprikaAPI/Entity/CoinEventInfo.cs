using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class CoinEventInfo
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("date_to")]
        public string DateTo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_conference")]
        public bool IsConference { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("proof_image_link")]
        public Uri ProofImageLink { get; set; }
    }
}
