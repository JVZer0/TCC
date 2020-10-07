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
        Database.UsuarioDatabase databaseUsuario = new Database.UsuarioDatabase();
        Validadores validadores = new Validadores();
        public Models.TbLogin Logar(Models.TbLogin request)
        {
            validadores.VerificarLogin(request);
            return databaseLogin.Logar(request);
        }

        public Models.TbUsuario Alterar(Models.TbUsuario usuario)
        {
            validadores.Alterar(usuario);
            return databaseUsuario.Alterar(usuario);
        }
        public Models.TbLogin Cadastrar(Models.TbLogin request, string ConfirmarSenha)
        {
            validadores.Cadastrar(request, ConfirmarSenha);
            return databaseLogin.Cadastrar(request);
        }
    }
}