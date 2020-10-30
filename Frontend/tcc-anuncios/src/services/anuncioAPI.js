import axios from 'axios';
const api = axios.create({
    baseURL: "http://3.84.250.220:5000"
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

    async consultarMeusAnuncios(idUsuario){
        const resp = await api.get(`/Anuncio/MeusAnuncios/${idUsuario}`);
        return resp.data;
    }

    async consultarMeusFavoritos(idUsuario){
        const resp = await api.get(`/Favorito/MeusFavoritos/${idUsuario}`);
        return resp.data;
    }

    async deletarAnuncio(idAnuncio, idUsuario){
        const resp = await api.delete(`/Anuncio/DeletarAnuncio/${idAnuncio}/${idUsuario}`);
        return resp.data;
    }

    async inativarAnuncio(idAnuncio){
        const resp = await api.put(`/Anuncio/InativarAnuncio/${idAnuncio}`);
        return resp.data;
    }

    async anuncioVendido(idAnuncio){
        const resp = await api.put(`/Anuncio/AnuncioVendido/${idAnuncio}`);
        return resp.data;
    }

    async ativarAnuncio(idAnuncio){
        const resp = await api.put(`/Anuncio/AtivarAnuncio/${idAnuncio}`);
        return resp.data;
    }

    async excluirFavorito(idAnuncio, idUsuario){
        const resp = await api.delete(`/Favorito/DeletarFavorito/${idAnuncio}/${idUsuario}`);
        return resp.data;
    }

    async favoritarAnuncio(idAnuncio, idUsuario){
        const resp = await api.post(`/Favorito/FavoritarAnuncio/${idAnuncio}/${idUsuario}`);
        return resp.data;
    }

    async perguntar(req){
        const resp = await api.post(`/Anuncio/Perguntar/`, req);
        return resp.data;
    }

    async responder(req){
        const resp = await api.post(`/Anuncio/Responder/`, req);
        return resp.data;
    }
}