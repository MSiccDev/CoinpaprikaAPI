using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class WhitepaperInfo
    {
        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("thumbnail")]
        public Uri Thumbnail { get; set; }
    }
}
