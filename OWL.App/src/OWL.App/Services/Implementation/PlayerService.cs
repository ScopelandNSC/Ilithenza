using Microsoft.Extensions.Options;
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
            System.Uri url = new System.Uri(string.Format("{0}/players/{1}", "https://api.overwatchleague.com/", playerId));   // This should probably go through a service call -- Will do soon

            var response = _apiRequestHelper.Get(url);

            var player = new BasePlayer();
            player.playerId = 1;
            player.username = "Scott";
            return new BasePlayer();
        }
    }
}
