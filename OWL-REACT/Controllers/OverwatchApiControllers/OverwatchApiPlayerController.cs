using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OWL_REACT.Config;
using OWL_REACT.Dtos.Player;
using OWL_REACT.Helpers.Interfaces;
using System.Web.Http;

namespace OWL_REACT.Controllers
{
    [RoutePrefix("[Overwatch/api/Player/]")]
    public class OverwatchApiPlayerController : ApiController
    {
        private readonly IOptions<OverwatchApiSettings> _overwatchApiSettings;
        private readonly IApiRequestHelper _apiRequestHelper;

        public JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public OverwatchApiPlayerController(IOptions<OverwatchApiSettings> overwatchApiSettings, IApiRequestHelper apiRequestHelper)
        {
            _overwatchApiSettings = overwatchApiSettings;
            _apiRequestHelper = apiRequestHelper;
        }

        [HttpGet]
        [Route("{playerId:int}")]
        public Player GetAllPlayers(int playerId)
        {
            string url = string.Format("{0}/players/{1}", _overwatchApiSettings.Value.BaseUrl, playerId); // This should probably go through a service call -- Will do soon
            var response = _apiRequestHelper.Get(url);
           
            return JsonConvert.DeserializeObject<Player>(response, settings);
        }
    }
}
