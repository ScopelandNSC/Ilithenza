export default class BasePlayer {
    constructor(data) {
        this.id = data.id ? data.id : null;
        this.username = data.username
            ? data.username
            : '';
    }
}