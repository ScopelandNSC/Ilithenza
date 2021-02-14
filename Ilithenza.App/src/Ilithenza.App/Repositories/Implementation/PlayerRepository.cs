using Ilithenza.App.Dtos.Player;
using Ilithenza.App.Repositories.Interface;

namespace Ilithenza.App.Repositories.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        public BasePlayer GetPlayer(int playerId)
        {
            return new BasePlayer();
        }
    }
}
