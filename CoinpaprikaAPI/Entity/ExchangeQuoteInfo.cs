using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExchangeQuoteInfo
    {
        [JsonProperty("reported_volume_24h")]
        public long ReportedVolume24H { get; set; }

        [JsonProperty("adjusted_volume_24h")]
        public long AdjustedVolume24H { get; set; }
    }
}
