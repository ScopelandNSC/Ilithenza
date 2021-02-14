using System.Threading.Tasks;
using Ilithenza.App.Config;
using Ilithenza.App.Dtos.Player;
using Ilithenza.App.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ilithenza.App.Controllers
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
        public BasePlayer GetPlayer(int playerId)
        {
            return _playerService.GetPlayer(playerId);
        }
    }
}