using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class CoinPaprikaError
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}
