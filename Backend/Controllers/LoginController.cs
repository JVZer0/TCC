using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        Business.LoginBusiness business = new Business.LoginBusiness();
        Utils.LoginConversor conversor = new Utils.LoginConversor();
        [HttpPost]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Login> Logar(Models.Request.AnuncioRoupasRequest.Login request)
        {
            try
            {
                Models.TbLogin primeiro = conversor.ConvesorParaTabelaLogin(request);
                Models.TbLogin segundo = business.Logar(primeiro);
                return conversor.ConversorDeTabelaParaResponse(segundo);
            }
            catch (System.Exception e)
            {
                return BadRequest(new Models.Response.Erro(400,e.Message));
            }
        }
        [HttpPost("Criarlogin")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Usuario> CadastrarLogin(Models.Request.AnuncioRoupasRequest.Usuario request)
        {
            try
            {
                return null;
            }
            catch (System.Exception e)
            {
                return BadRequest(new Models.Response.Erro(400,e.Message));
            }
        }
    }
}
