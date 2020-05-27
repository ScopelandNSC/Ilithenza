using System.Collections.Generic;
using Newtonsoft.Json;

namespace OWL.App.Dtos.Player
{
    public class BasePlayer
    {
        public PlayerPersonalDetails PersonalDetails { get; set; }

        public PlayerHeroDetails HeroDetails { get; set; }

        public IEnumerable<PlayerTeamDetails> TeamDetails { get; set; }
    }
}