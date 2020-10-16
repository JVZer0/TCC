using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnuncioController : ControllerBase
    {
        Business.AnuncioBusiness businessanuncio = new Business.AnuncioBusiness();
        Utils.AnuncioConversor conversoranuncio = new Utils.AnuncioConversor();
        Business.GerenciadorImagem gerenciadorImagem = new Business.GerenciadorImagem();
        [HttpGet("foto/{nome}")]
        public ActionResult BuscarFoto(string nome)
        {
            try 
            {
                byte[] foto = gerenciadorImagem.LerFoto(nome);
                string contentType = gerenciadorImagem.GerarContentType(nome);
                return File(foto, contentType);
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.Erro(404, ex.Message)
                );
            }

        }
        [HttpGet("{BarraPesquisa}/{Estado}/{Cidade}/{Tamanho}/{Genero}/{Condicao}")]
        public ActionResult<List<Models.Response.AnuncioRoupasResponse.Anuncio>> ConsultarAnuncios(string BarraPesquisa, string Estado, string Cidade, string Tamanho, string Genero, string Condicao)
        {
            try
            {
                List<Models.TbAnuncio> anuncios = businessanuncio.ConsultarAnuncios(BarraPesquisa, Estado, Cidade, Tamanho, Genero, Condicao);
                return conversoranuncio.ConversorAnuncioListaResponse(anuncios);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
    }
}
