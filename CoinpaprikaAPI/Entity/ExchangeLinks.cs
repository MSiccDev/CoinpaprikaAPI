using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExchangeLinks
    {
        [JsonProperty("website")]
        public List<Uri> Website { get; set; }

        [JsonProperty("twitter")]
        public List<Uri> Twitter { get; set; }
    }
}
