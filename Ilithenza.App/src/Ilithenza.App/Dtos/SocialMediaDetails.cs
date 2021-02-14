using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ilithenza.App.Dtos.Player
{
    public class SocialMediaDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("competitorId")]
        public int CompetitorId { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("value")]
        public string Link { get; set; }

        [JsonProperty("isPublic")]
        public string IsPublic { get; set; }
    }
}