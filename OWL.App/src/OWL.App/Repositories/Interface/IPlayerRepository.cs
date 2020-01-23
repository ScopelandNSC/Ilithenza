using OWL.App.Dtos.Player;

namespace OWL.App.Repositories.Interface
{
    public interface IPlayerRepository
    {
        BasePlayer GetPlayer(int playerId);
    }
}
