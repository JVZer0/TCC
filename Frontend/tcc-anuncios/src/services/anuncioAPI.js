import axios from 'axios';
const api = axios.create({
    baseURL: "http://localhost:5000"
  });


export default class anuncioAPI{

    async login(req){
        const resp = await api.post('/Login', req);
        return resp;
    }

    async consultarUsuario(idUsuario) {
        const resp = await api.get(`/Usuario/${idUsuario}`);
        return resp;
    }

    async alterarInfos(req){
        const resp = await api.post('/Login', req);
        return resp;
    }
}