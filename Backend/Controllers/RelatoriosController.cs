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
                return BadRequest(new Models.Response.Erro(404,ex.Message));
            }
        }
        [HttpGet("AnunciosPorMes")]
        public ActionResult<List<Models.Response.RelatorioResponse.AnunciosPorMes>> AnunciosPorMes(DateTime mesInicio, DateTime mesFim)
        {
            try
            {
                List<Models.TbAnuncio> a = businessRelatorio.AnunciosPorMes(mesInicio, mesFim);
                return conversor.ConversorAnunciosPorMes(mesInicio, mesFim, a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(404,ex.Message));
            }
        }
        [HttpGet("Top10Anunciantes")]
        public ActionResult<List<Models.Response.RelatorioResponse.Top10Anunciantes>> Top10Anunciantes()
        {
            try
            {
                List<Models.TbUsuario> users = businessRelatorio.Top10Anunciantes();
                return conversor.ConversorTop10Anunciantes(users);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(404,ex.Message));
            }
        }
        [HttpGet("Top10ProdutosMaisAnunciados")]
        public ActionResult<List<Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados>> Top10ProdutosMaisAnunciados()
        {
            try
            {
                List<Models.TbAnuncio> a = businessRelatorio.Top10ProdutosMaisAnunciados();
                return conversor.ConversorTop10ProdutosMaisAnunciados(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(404,ex.Message));
            }
        }
        [HttpGet("QtdAnunciosPorEstado")]
        public ActionResult<List<Models.Response.RelatorioResponse.EstadosComMaisAnuncios>> QtdAnunciosPorEstado()
        {
            try
            {
                List<Models.TbAnuncio> a = businessRelatorio.QtdAnunciosPorEstado();
                return conversor.ConversorQtdAnunciosPorEstado(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(404,ex.Message));
            }
        }
    }
}