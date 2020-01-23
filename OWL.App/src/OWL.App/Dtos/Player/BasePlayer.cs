using Newtonsoft.Json;

namespace OWL.App.Dtos.Player
{
    public class BasePlayer
    {
        [JsonProperty("id")]
        public int playerId { get; set; }

        [JsonProperty("name")]
        public string username { get; set; }
    }
}