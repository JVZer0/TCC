using System;
using System.Collections.Generic;

namespace Backend.Business
{
    public class FavoritoBusiness
    {
        Database.FavoritosDatabase databaseFavorito = new Database.FavoritosDatabase();
        Validadores validadores = new Validadores();
        public bool? ConsultarSeOAnuncioEstaFavoritado(int IdAnuncio, int IdUsuario)
        {
            validadores.ValidarId(IdAnuncio);
            validadores.ValidarId(IdUsuario);
            return databaseFavorito.ConsultarSeOAnuncioEstaFavoritado(IdAnuncio, IdUsuario);
        }
        public List<Models.TbFavorito> ConsultarMeusAnunciosFavoritos(int IdUsuario)
        {
            validadores.ValidarId(IdUsuario);
            return databaseFavorito.ConsultarMeusAnunciosFavoritos(IdUsuario);
        }
        public Models.TbFavorito FavoritarAnuncio(Models.TbFavorito req)
        {
            validadores.ValidarId(req.IdAnuncio);
            validadores.ValidarId(req.IdUsuario);
            return databaseFavorito.FavoritarAnuncio(req);
        }
        public Models.TbFavorito ConsultarFavorito(int IdAnuncio)
        {
            validadores.ValidarId(IdAnuncio);
            return databaseFavorito.ConsultarFavorito(IdAnuncio);
        }
        public Models.TbFavorito DeletarFavorito(int IdAnuncio, int IdUsuario)
        {
            validadores.ValidarId(IdAnuncio);
            validadores.ValidarId(IdUsuario);
            Models.TbFavorito resp = databaseFavorito.DeletarFavorito(IdAnuncio, IdUsuario);
            if(resp == null) throw new ArgumentException("Esse anuncio ainda não foi favoritado para ser exluido dos seus favoritos.");
            return resp;
        }
    }
}