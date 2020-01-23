using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OWL.App.Config;
using OWL.App.Helpers.Interfaces;

namespace OWL.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IOptions<OverwatchApiSettings> _overwatchApiSettings;
        private readonly IApiRequestHelper _apiRequestHelper;

        public PlayerController(IOptions<OverwatchApiSettings> overwatchApiSettings, IApiRequestHelper apiRequestHelper)
        {
            _overwatchApiSettings = overwatchApiSettings;
            _apiRequestHelper = apiRequestHelper;
        }

        [HttpGet]
        [Route("{playerId:int}")]
        public void GetPlayer(int playerId)
        {
            System.Uri url = new System.Uri(string.Format("{0}/players/{1}", "https://api.overwatchleague.com/", playerId));   // This should probably go through a service call -- Will do soon

            var response = _apiRequestHelper.Get(url);
        }
    }
}