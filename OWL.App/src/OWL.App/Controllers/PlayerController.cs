using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OWL.App.Config;
using OWL.App.Services.Interface;

namespace OWL.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Route("{playerId:int}")]
        public void GetPlayer(int playerId)
        {
            _playerService.GetPlayer(playerId);
        }
    }
}