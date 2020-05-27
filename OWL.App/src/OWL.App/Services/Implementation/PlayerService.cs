using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OWL.App.Config;
using OWL.App.Dtos.Player;
using OWL.App.Helpers.Interfaces;
using OWL.App.Services.Interface;

namespace OWL.App.Services.Implementation
{
    public class PlayerService : IPlayerService
    {
        private readonly IOptions<OverwatchApiSettings> _overwatchApiSettings;
        private readonly IApiRequestHelper _apiRequestHelper;

        public PlayerService(IOptions<OverwatchApiSettings> overwatchApiSettings, IApiRequestHelper apiRequestHelper)
        {
            _overwatchApiSettings = overwatchApiSettings;
            _apiRequestHelper = apiRequestHelper;
        }

        public BasePlayer GetPlayer(int playerId)
        {
            BasePlayer player = new BasePlayer();

            System.Uri url = new System.Uri(string.Format("{0}/players/{1}", "https://api.overwatchleague.com", playerId));   // This should probably go through a service call -- Will do soon

            var response = _apiRequestHelper.Get(url);

            player.PersonalDetails = JObject.Parse(response)["data"]["player"].ToObject<PlayerPersonalDetails>();

            player.HeroDetails = JObject.Parse(response)["data"]["player"]["attributes"].ToObject<PlayerHeroDetails>();

            player.TeamDetails = GetTeamDetails(response);
            return player;
        }

        private List<PlayerTeamDetails> GetTeamDetails(string response)
        {
            JObject jObject = JObject.Parse(response);
            JArray teams = (JArray)jObject["data"]["player"]["teams"];

            List<PlayerTeamDetails> playerTeams = new List<PlayerTeamDetails>();

            foreach (var team in teams)
            {
                playerTeams.Add(team["team"].ToObject<PlayerTeamDetails>());
            }

            return playerTeams;
        }
    }
}
