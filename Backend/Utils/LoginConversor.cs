using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Utils
{
    public class LoginConversor
    {
        public Models.TbLogin ConvesorParaTabelaLogin(Models.Request.AnuncioRoupasRequest.Login request)
        {
            Models.TbLogin final = new Models.TbLogin();
            final.DsUsername = request.Username;
            final.DsSenha = request.Senha;

            return final;
        }
        public Models.Response.AnuncioRoupasResponse.Login ConversorDeTabelaParaResponse(Models.TbLogin entrada)
        {
            Models.Response.AnuncioRoupasResponse.Login final = new Models.Response.AnuncioRoupasResponse.Login();
            final.IdLogin = entrada.IdLogin;
            
            final.NomeUsuario = entrada.TbUsuario.FirstOrDefault().NmUsuario;
            final.IdUsuario = entrada.TbUsuario.FirstOrDefault().IdUsuario;
            final.RG = entrada.TbUsuario.FirstOrDefault().DsRg;
            final.Email = entrada.TbUsuario.FirstOrDefault().DsEmail;
            final.CPF = entrada.TbUsuario.FirstOrDefault().DsCpf;

            return final;
        }
    }
}