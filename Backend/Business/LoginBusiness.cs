using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Business
{
    public class LoginBusiness
    {
        Database.LoginDatabase databaseLogin = new Database.LoginDatabase();
        Validadores validadores = new Validadores();
        public Models.TbLogin Logar(Models.TbLogin request)
        {
            validadores.VerificarLogin(request);
            Models.TbLogin resp = databaseLogin.Logar(request);
            if(resp == null) throw new ArgumentException("Username ou senha errados.");  
            return resp;
        }

        public Models.TbLogin Cadastrar(Models.TbLogin request, string ConfirmarSenha)
        {
            validadores.Cadastrar(request, ConfirmarSenha);
            return databaseLogin.Cadastrar(request);
        }
    }
}