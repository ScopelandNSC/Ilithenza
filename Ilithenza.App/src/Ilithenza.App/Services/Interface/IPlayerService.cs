using Ilithenza.App.Dtos.Player;

namespace Ilithenza.App.Services.Interface
{
    public interface IPlayerService
    {
        BasePlayer GetPlayer(int playerId);
    }
}
