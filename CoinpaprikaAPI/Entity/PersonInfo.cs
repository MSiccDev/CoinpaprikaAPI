using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class PersonInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("teams_count")]
        public long TeamsCount { get; set; }

        [JsonProperty("links")]
        public PersonalSocialLinks Links { get; set; }

        [JsonProperty("postions")]
        public List<PersonalPostionInfo> Postions { get; set; }
    }
}
