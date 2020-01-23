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
            System.Uri url = new System.Uri(string.Format("{0}/players/{1}", "https://api.overwatchleague.com", playerId));   // This should probably go through a service call -- Will do soon

            var response = _apiRequestHelper.Get(url);

            return JObject.Parse(response)["data"]["player"].ToObject<BasePlayer>();
        }
    }
}
