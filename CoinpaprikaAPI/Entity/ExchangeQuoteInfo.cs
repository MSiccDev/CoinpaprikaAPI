using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExchangeQuoteInfo
    {
        #region Public Properties

        [JsonProperty("adjusted_volume_24h")]
        public long AdjustedVolume24H { get; set; }

        [JsonProperty("adjusted_volume_30d")]
        public long AdjustedVolume30D { get; set; }

        [JsonProperty("adjusted_volume_7d")]
        public long AdjustedVolume7D { get; set; }

        [JsonProperty("reported_volume_24h")]
        public long ReportedVolume24H { get; set; }

        [JsonProperty("reported_volume_30d")]
        public long ReportedVolume30D { get; set; }

        [JsonProperty("reported_volume_7d")]
        public long ReportedVolume7D { get; set; }

        #endregion Public Properties
    }
}