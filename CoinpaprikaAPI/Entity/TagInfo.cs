﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class TagInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coin_counter")]
        public long CoinCounter { get; set; }

        [JsonProperty("ico_counter")]
        public long IcoCounter { get; set; }
    }
}
