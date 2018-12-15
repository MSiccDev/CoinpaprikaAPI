using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class CoinTweetInfo
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_retweet")]
        public bool IsRetweet { get; set; }

        [JsonProperty("status_link")]
        public string StatusLink { get; set; }

        [JsonProperty("media_link")]
        public string MediaLink { get; set; }

        [JsonProperty("video_link")]
        public string VideoLink { get; set; }
    }
}
