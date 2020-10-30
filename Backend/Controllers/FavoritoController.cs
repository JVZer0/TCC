using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Html;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritoController : ControllerBase
    {
        Business.FavoritoBusiness businessFavorito = new Business.FavoritoBusiness();
        Utils.FavoritoConversor conversorFavorito = new Utils.FavoritoConversor();
        [HttpGet("Favorito/{IdAnuncio}/{IdUsuario}")]
        public ActionResult<bool> ConsultarSeOAnuncioEstaFavoritado(int IdAnuncio, int IdUsuario)
        {
            try
            {
                bool? resp = businessFavorito.ConsultarSeOAnuncioEstaFavoritado(IdAnuncio, IdUsuario);
                return resp;
            }
            catch (System.Exception ex)
            {
               return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }

        [HttpGet("MeusFavoritos/{IdUsuario}")]
        public ActionResult<List<Models.Response.AnuncioRoupasResponse.Anuncio>> ConsultarMeusFavoritos(int IdUsuario)
        {
            try
            {
                List<Models.TbFavorito> resp = businessFavorito.ConsultarMeusAnunciosFavoritos(IdUsuario);
                return conversorFavorito.ConverterVariosFavoritosParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400, ex.Message));
            }
        }
        [HttpPost("FavoritarAnuncio/{IdAnuncio}/{IdUsuario}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Anuncio> FavoritarAnuncio(int IdAnuncio, int IdUsuario)
        {
            try
            {
                Models.TbFavorito favoritando = conversorFavorito.ConversorFavoritarTabela(IdAnuncio, IdUsuario);
                Models.TbFavorito resp = businessFavorito.FavoritarAnuncio(favoritando);
                Models.TbFavorito final = businessFavorito.ConsultarFavorito(resp.IdFavorito);
                return conversorFavorito.FavoritoParaResponse(final);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400, ex.Message));
            }
        }
        [HttpDelete("DeletarFavorito/{IdAnuncio}/{IdUsuario}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Anuncio> DeletarFavorito(int IdAnuncio, int IdUsuario)
        {
            try
            {
                Models.TbFavorito resp = businessFavorito.DeletarFavorito(IdAnuncio, IdUsuario);
                return conversorFavorito.FavoritoParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400, ex.Message));
            }
        }
    }
}