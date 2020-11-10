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
        Business.AnuncioBusiness businessAnuncio = new Business.AnuncioBusiness();
        Utils.AnuncioConversor conversorAnuncio = new Utils.AnuncioConversor();
        Business.GerenciadorImagem gerenciadorImagem = new Business.GerenciadorImagem();

        [HttpGet("{BarraPesquisa}/{Estado}/{Cidade}/{Genero}/{Condicao}/{NPagina}")]
        public ActionResult<List<Models.Response.AnuncioRoupasResponse.Anuncio>> ConsultarAnuncios(string BarraPesquisa, string Estado, string Cidade, string Genero, string Condicao, int NPagina)
        {
            try
            {
                List<Models.TbAnuncio> anuncios = businessAnuncio.ConsultarAnuncios(BarraPesquisa, Estado, Cidade, Genero, Condicao, NPagina);
                int a = NPagina -1;
                if(a == 0) a = 1;
                List<Models.Response.AnuncioRoupasResponse.Anuncio> resp = conversorAnuncio.ConversorAnuncioListaResponse(anuncios);
                return resp.Skip(a).Take(6).OrderByDescending(x => x.DataPublicacao).ToList();
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpGet("AnuncioDetalhado/{IdAnuncio}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.AnuncioDetalhado> ConsultarAnuncioDetalhado(int IdAnuncio)
        {
            try
            {
                Models.TbAnuncio resp = businessAnuncio.ConsultadoAnuncioDetalhado(IdAnuncio);
                return conversorAnuncio.AnuncioDetalhadoResponse(resp);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpPost("Perguntar")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.PerguntaEResposta> Perguntar(Models.Request.AnuncioRoupasRequest.Pergunta req)
        {
            try
            {
                Models.TbPerguntaResposta a = conversorAnuncio.PerguntarParaTabela(req);
                Models.TbPerguntaResposta b = businessAnuncio.Perguntar(a);
                return conversorAnuncio.PerguntarParaResponse(b);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400, ex.Message));
            }
        }
        [HttpPut("Responder")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.PerguntaEResposta> Responder(Models.Request.AnuncioRoupasRequest.Resposta req)
        {
            try
            {
                Models.TbPerguntaResposta a = conversorAnuncio.ResponderParaTabela(req);
                Models.TbPerguntaResposta b = businessAnuncio.Responder(a);
                return conversorAnuncio.ResponderParaResponse(b);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400, ex.Message));
            }
        }
        [HttpPost("Anunciar")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Anuncio> Anunciar([FromForm] Models.Request.AnuncioRoupasRequest.Anunciar anuncio)
        {
            try
            {
                Models.TbAnuncio anu1 = conversorAnuncio.AnuncioParaTabela(anuncio);
                anu1.TbImagem = gerenciadorImagem.GerarMuitosNomes(anuncio.Imagens);
                Models.TbAnuncio resp = businessAnuncio.Anunciar(anu1);
                gerenciadorImagem.SalvarVariasImagens(anuncio.Imagens,resp.TbImagem.ToList());
                return conversorAnuncio.AnuncioParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400, ex.Message));
            }
        }
        [HttpGet("MeusAnuncios/{IdUsuario}")]
        public ActionResult<List<Models.Response.AnuncioRoupasResponse.MeusAnuncios>> ConsultarMeusAnuncios(int IdUsuario)
        {
            try
            {
                List<Models.TbAnuncio> resp = businessAnuncio.ConsultarMeusAnuncios(IdUsuario);
                return conversorAnuncio.ConversorVariosMeusAnunciosParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpDelete("DeletarAnuncio/{IdAnuncio}/{IdUsuario}")]
        public ActionResult<string> DeletarAnuncio (int IdAnuncio, int IdUsuario)
        {
            try
            {
                businessAnuncio.DeletarAnuncio(IdAnuncio, IdUsuario);
                return "Anuncio apagado com sucesso";
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        } 
        [HttpPut("InativarAnuncio/{IdAnuncio}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.MeusAnuncios> InativarAnuncio(int IdAnuncio)
        {
            try
            {
                Models.TbAnuncio resp = businessAnuncio.InativarAnuncio(IdAnuncio);
                return conversorAnuncio.ConversorMeusAnunciosParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        } 
        [HttpPut("AnuncioVendido/{IdAnuncio}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.AnuncioVendido> AnuncioVendido(int IdAnuncio)
        {
            try
            {
                Models.TbAnuncio resp = businessAnuncio.AnuncioVendido(IdAnuncio);
                return conversorAnuncio.ConversorAnuncioVendidoResponse(resp);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpPut("AlterarAnuncio")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Anuncio> AlterarAnuncio(Models.Request.AnuncioRoupasRequest.AlterarAnuncio a)
        {
            try
            {
                Models.TbAnuncio NovoAnuncio = conversorAnuncio.AlterarAnuncioParaTabela(a);
                Models.TbAnuncio resp = businessAnuncio.AlterarAnuncio(NovoAnuncio);
                return conversorAnuncio.ConversorAnuncioResponse(resp);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400, ex.Message));
            }
        }
        [HttpPut("AtivarAnuncio/{IdAnuncio}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.MeusAnuncios> AtivarAnuncio(int IdAnuncio)
        {
            try
            {
                Models.TbAnuncio resp = businessAnuncio.AtivarAnuncio(IdAnuncio);
                return conversorAnuncio.ConversorMeusAnunciosParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpGet("ConsultarNPaginas")]
        public ActionResult<decimal> ConsultarNPaginas()
        {
            try
            {
                return businessAnuncio.ConsultarNPaginas();
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        } 
    }
}
