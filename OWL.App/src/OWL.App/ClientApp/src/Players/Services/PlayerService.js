import apiHelper from '../../Common/Helpers/ApiHelper';

class PlayerService {
    getPlayer(playerId) {
        return apiHelper.get(`api/Player/${playerId}`);
    }
}

export default PlayerService;