using System.Collections.Generic;
using Newtonsoft.Json;

namespace OWL.App.Dtos.Player
{
    public class PlayerTeamDetails
    {
        [JsonProperty("id")]
        public int teamId { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("availableLanguages")]
        public IReadOnlyList<string> languages { get; set; }
    }
}