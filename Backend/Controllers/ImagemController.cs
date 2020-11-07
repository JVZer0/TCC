using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagemController : ControllerBase
    {
        Business.ImagemBusiness businessImagem = new Business.ImagemBusiness();
        Business.GerenciadorImagem gerenciadorImagem = new Business.GerenciadorImagem();
        Utils.ImagemConversor conversorImagem = new Utils.ImagemConversor();
        [HttpDelete("{IdImagem}/{IdAnuncio}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Imagem> ExcluirImagem(int IdImagem, int IdAnuncio)
        {
            try
            {
                Models.TbImagem resp = businessImagem.ApagarImagem(IdImagem, IdAnuncio);
                if(resp.ImgAnuncio != "semimagem.PNG")
                {
                    gerenciadorImagem.DeletarImagem(resp.ImgAnuncio);
                }
                return conversorImagem.ConverterImagemParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpPost("{IdAnuncio}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Imagem> AdicionarImagem([FromForm] IFormFile imagem, int IdAnuncio)
        {
            try
            {
                Models.TbImagem resp = new Models.TbImagem();
                resp.IdAnuncio = IdAnuncio;
                resp.ImgAnuncio = gerenciadorImagem.GerarNovoNome(imagem);
                businessImagem.InserirImagem(resp);
                gerenciadorImagem.SalvarImagem(resp.ImgAnuncio, imagem);
                return conversorImagem.ConverterImagemParaResponse(resp);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpGet("BuscarImagem/{nome}")]
        public ActionResult BuscarImagem(string nome)
        {
            try 
            {
                byte[] imagem = gerenciadorImagem.LerImagem(nome);
                string contentType = gerenciadorImagem.GerarContentType(nome);
                return File(imagem, contentType);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpPost("AdicionarVariasImagens/{IdAnuncio}")]
        public ActionResult<List<Models.Response.AnuncioRoupasResponse.Imagem>> AdicionarVariasImagem(int IdAnuncio, [FromForm] List<IFormFile> imagens)
        {
            try
            {
                List<Models.TbImagem> dale = new List<Models.TbImagem>();
                foreach (IFormFile item in imagens)
                {
                    Models.TbImagem resp = new Models.TbImagem();
                    resp.IdAnuncio = IdAnuncio;
                    resp.ImgAnuncio = gerenciadorImagem.GerarNovoNome(item);
                    dale.Add(resp);
                }
                businessImagem.InserirVariasImagens(dale);
                gerenciadorImagem.SalvarVariasImagens(imagens, dale);
                return conversorImagem.ConverterVariasImagensParaResponse(dale);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(404, ex.Message));
            }
        }
    }
}