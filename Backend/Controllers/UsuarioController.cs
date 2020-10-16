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
        Business.UsuarioBusiness businessUsuario = new Business.UsuarioBusiness();
        Utils.UsuarioConversor conversor = new Utils.UsuarioConversor();
        [HttpPut]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Usuario> Alterar(Models.Request.AnuncioRoupasRequest.Usuario req)
        {
            try
            {
                Models.TbUsuario usuario = conversor.ConversorTabelaUsuario(req);
                
                usuario = businessUsuario.Alterar(usuario);

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
        [HttpGet("{IdUsuario}")]
        public ActionResult<Models.Response.AnuncioRoupasResponse.Usuario> ConsultarInfomacoesDoUsuario(int IdUsuario)
        {
            try
            {
                Models.TbUsuario modeloTabela = businessUsuario.ConsultarUsuario(IdUsuario);
                return conversor.ConversorTabelaResponse(modeloTabela);
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
        [HttpPost("RecuperarSenha/")]
        public ActionResult<string> RecuperarSenha(Models.Request.AnuncioRoupasRequest.Recuperação RGeCPF)
        {
            try
            {
                Models.TbUsuario resp = businessUsuario.RecuperarSenha(RGeCPF.CPF,RGeCPF.RG);
                return resp.IdLoginNavigation.DsSenha;
            }
            catch (System.Exception ex)
            {
                return NotFound(new Models.Response.Erro(404, ex.Message));
            }
        }
    }
}
