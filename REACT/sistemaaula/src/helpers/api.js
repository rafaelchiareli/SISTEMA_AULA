import axios from 'axios';

var urlBase = "http://localhost:5066/api"
    const Api = axios.create({
        baseURL: urlBase        
    })

    export default Api;