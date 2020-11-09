using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosController : ControllerBase
    {
        Business.RelatorioBusiness businessRelatorio = new Business.RelatorioBusiness();
        Utils.RelatorioConversor conversor = new Utils.RelatorioConversor();
        [HttpGet("AnunciosPorDia")]
        public ActionResult<List<Models.Response.RelatorioResponse.AnunciosPorDia>> AnunciosPorDia(DateTime dia)
        {
            try
            {
                List<Models.TbAnuncio> a = businessRelatorio.AnunciosPorDia(dia);
                return conversor.ConversorAnunciosPorDia(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
        [HttpGet("AnunciosPorMes/{mesInicio}/{mesFim}")]
        public ActionResult<List<Models.Response.RelatorioResponse.AnunciosPorMes>> AnunciosPorMes(DateTime mesInicio, DateTime mesFim)
        {
            try
            {
                return null;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
        [HttpGet("Top10Anunciantes")]
        public ActionResult<List<Models.Response.RelatorioResponse.Top10Anunciantes>> Top10Anunciantes()
        {
            try
            {
                return null;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
        [HttpGet("Top10ProdutosMaisAnunciados")]
        public ActionResult<List<Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados>> Top10ProdutosMaisAnunciados()
        {
            try
            {
                return null;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
        [HttpGet("Top5EstadosComMaisAnuncios/{Estados}")]
        public ActionResult<List<Models.Response.RelatorioResponse.Top5EstadosComMaisAnuncios>> Top5EstadosComMaisAnuncios(string Estados)
        {
            try
            {
                return null;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
    }
}