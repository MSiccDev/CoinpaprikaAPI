using Newtonsoft.Json;

namespace CoinpaprikaAPI.Entity
{
    public class PersonalPostionInfo
    {
        [JsonProperty("coin_id")]
        public string CoinId { get; set; }

        [JsonProperty("coin_name")]
        public string CoinName { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }
    }
}