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
    public class UsuarioController : ControllerBase
    {
        Business.LoginBusiness business1 = new Business.LoginBusiness();
        Utils.UsuarioConversor conversor = new Utils.UsuarioConversor();
        [HttpPut]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Usuario> Alterar (Models.Request.AnuncioRoupasRequest.Usuario req)
        {
            try
            {
                Models.TbUsuario usuario = conversor.ConversorTabelaUsuario(req);
                
                usuario = business1.Alterar(usuario);

                Models.Response.AnuncioRoupasResponse.Usuario resp = conversor.ConversorTabelaResponse(usuario);
                
                return resp;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.Erro(400, ex.Message)
                );
            }
        }
    }
}
