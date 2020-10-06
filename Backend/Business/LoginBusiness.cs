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
        Database.LoginDatabase database = new Database.LoginDatabase();
        Database.UsuarioDatabase database1 = new Database.UsuarioDatabase();
        Validadores validadores = new Validadores();
        public Models.TbLogin Logar(Models.TbLogin request)
        {
            validadores.VerificarLogin(request);
            return database.Logar(request);
        }

        public Models.TbUsuario Alterar (Models.TbUsuario usuario)
        {
            validadores.Alterar(usuario);
            return database1.Alterar(usuario);
        }
    }
}