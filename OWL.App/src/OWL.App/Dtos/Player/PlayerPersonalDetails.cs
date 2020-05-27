using System.Collections.Generic;
using Newtonsoft.Json;

namespace OWL.App.Dtos.Player
{
    public class PlayerPersonalDetails
    {
        [JsonProperty("id")]
        public int playerId { get; set; }

        [JsonProperty("name")]
        public string username { get; set; }

        [JsonProperty("nationality")]
        public string nationality { get; set; }

        [JsonProperty("familyName")]
        public string familyName { get; set; }

        [JsonProperty("givenName")]
        public string givenName { get; set; }

        [JsonProperty("availableLangauges")]
        public IReadOnlyList<string> languages { get; set; }
    }
}