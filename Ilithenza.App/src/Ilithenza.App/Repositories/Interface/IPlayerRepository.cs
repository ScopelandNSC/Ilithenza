using Ilithenza.App.Dtos.Player;

namespace Ilithenza.App.Repositories.Interface
{
    public interface IPlayerRepository
    {
        BasePlayer GetPlayer(int playerId);
    }
}
