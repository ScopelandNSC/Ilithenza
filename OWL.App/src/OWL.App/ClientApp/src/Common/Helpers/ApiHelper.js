import axios from 'axios';
class ApiHelper {
    static get(url) {
        return axios.get(url);
    }

    static async getAsync(url) {
        return await axios.get(url);
    }
    static post(url, body, headers) {
        return axios.post(url, body, { "headers": headers });
    }
    static postJSON(url, body) {
        return this.post(url, body, { 'Content-Type': 'application/json' });
    }
    static put(url, body, headers) {
        return axios.put(url, body, { "headers": headers });
    }
    static putJSON(url, body) {
        return this.put(url, body, { 'Content-Type': 'application/json' });
    }
    static deleteRequest(url) {
        return axios.delete(url);
    }
}
export default ApiHelper;