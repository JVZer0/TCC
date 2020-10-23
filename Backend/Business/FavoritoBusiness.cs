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
    }
}