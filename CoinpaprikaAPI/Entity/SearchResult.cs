using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class SearchResult
    {
        [JsonProperty("currencies", NullValueHandling = NullValueHandling.Ignore)]
        public List<CoinInfo> Currencies { get; set; }

        [JsonProperty("exchanges", NullValueHandling = NullValueHandling.Ignore)]
        public List<ExtendedExchangeInfo> Exchanges { get; set; }

        [JsonProperty("icos", NullValueHandling = NullValueHandling.Ignore)]
        public List<IcoInfo> Icos { get; set; }

        [JsonProperty("people", NullValueHandling = NullValueHandling.Ignore)]
        public List<PersonInfo> People { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<TagInfo> Tags { get; set; }
    }
}
