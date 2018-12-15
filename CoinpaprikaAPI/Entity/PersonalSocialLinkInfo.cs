using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class PersonalSocialLinkInfo
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("followers")]
        public long Followers { get; set; }
    }
}
