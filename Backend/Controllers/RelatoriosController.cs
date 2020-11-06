using System;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosController : ControllerBase
    {
        Business.RelatorioBusiness businessRelatorio = new Business.RelatorioBusiness();
        Utils.RelatorioConversor conversor = new Utils.RelatorioConversor();
        [HttpGet("AnunciosPorDia")]
        public ActionResult<string> AnunciosPorDia(DateTime dia)
        {
            try
            {
                return "AnunciosPorDia";
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
        [HttpGet("AnunciosPorMes")]
        public ActionResult<string> AnunciosPorMes(DateTime mesInicio, DateTime mesFim)
        {
            try
            {
                return "AnunciosPorMes";
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
        [HttpGet("Top10Clientes")]
        public ActionResult<string> Top10Clientes()
        {
            try
            {
                return "Top10Clientes";
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
        [HttpGet("Top10Produtos")]
        public ActionResult<string> Top10Produtos()
        {
            try
            {
                return "Top10Produtos";
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.Erro(400,ex.Message));
            }
        }
    }
}