using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaAPI.Entity
{
    public class ExtendedCoinInfo
    {
        #region Public Properties

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("development_status")]
        public string DevelopmentStatus { get; set; }

        [JsonProperty("first_data_at")]
        public DateTimeOffset FirstDataAt { get; set; }

        [JsonProperty("hardware_wallet")]
        public bool HardwareWallet { get; set; }

        [JsonProperty("hash_algorithm")]
        public string HashAlgorithm { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }

        [JsonProperty("last_data_at")]
        public DateTimeOffset LastDataAt { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("open_source")]
        public bool OpenSource { get; set; }

        [JsonProperty("org_structure")]
        public string OrgStructure { get; set; }

        [JsonProperty("parent")]
        public ParentInfo Parent { get; set; }

        [JsonProperty("proof_type")]
        public string ProofType { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("started_at")]
        public DateTimeOffset StartedAt { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("tags")]
        public List<TagInfo> Tags { get; set; }

        [JsonProperty("team")]
        public List<TeamInfo> Team { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("whitepaper")]
        public WhitepaperInfo Whitepaper { get; set; }

        #endregion Public Properties
    }
}