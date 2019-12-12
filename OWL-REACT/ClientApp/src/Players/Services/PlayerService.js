import apiHelper from '../../Common/Helpers/ApiHelper';

class PlayerService {
    getPlayer(playerId) {
        return apiHelper.get(`Overwatch/api/Player/${playerId}`);
    }
}

export default PlayerService;