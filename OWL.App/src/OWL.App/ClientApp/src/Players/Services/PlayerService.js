import apiHelper from '../../Common/Helpers/ApiHelper';

class PlayerService {
    async getPlayer(playerId) {
        var response = await apiHelper.getAsync(`api/Player/${playerId}`);
        return response.data;
    }
}

export default PlayerService;