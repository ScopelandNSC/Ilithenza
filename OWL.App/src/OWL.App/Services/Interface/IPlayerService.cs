using OWL.App.Dtos.Player;

namespace OWL.App.Services.Interface
{
    public interface IPlayerService
    {
        BasePlayer GetPlayer(int playerId);
    }
}
