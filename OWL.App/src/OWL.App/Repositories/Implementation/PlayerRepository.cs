using OWL.App.Dtos.Player;
using OWL.App.Repositories.Interface;

namespace OWL.App.Repositories.Implementation
{
    public class PlayerRepository : IPlayerRepository
    {
        public BasePlayer GetPlayer(int playerId)
        {
            return new BasePlayer();
        }
    }
}
