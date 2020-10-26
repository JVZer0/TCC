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

    async alterarInfosUsuario(req) {
        const resp = await api.put(`/Usuario`,req);
        return resp;
    }

    async cadastrar(ln){
        const resp = await api.post('/Login/Criarlogin', ln);
        console.log(resp);
        return resp;
    }

    async recuperar(req){
        const resp = await api.post('/Usuario/RecuperarSenha/', req);
        return resp;
    }

    async consultarAnuncios(BarraPesquisa, Estado, Cidade, Genero, Condicao){
        const resp = await api.get(`/Anuncio/${BarraPesquisa}/${Estado}/${Cidade}/${Genero}/${Condicao}`);
        return resp.data;
    }

    consultarImagem(imagem) {
        const modeloImagem = api.defaults.baseURL + "/Imagem/BuscarImagem/" + imagem;
        return modeloImagem;
    }

    async consultarAnuncioDetalhado(idAnuncio){
        const resp = await api.get(`/Anuncio/AnuncioDetalhado/${idAnuncio}`);
        return resp.data;
    }
}