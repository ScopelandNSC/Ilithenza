using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ilithenza.App.Dtos.Player
{
    public class PlayerHeroDetails
    {
        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("heroes")]
        public IReadOnlyList<string> heroes { get; set; }
    }
}