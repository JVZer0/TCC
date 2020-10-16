using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Business
{
    public class UsuarioBusiness
    {
        Database.UsuarioDatabase databaseUsuario = new Database.UsuarioDatabase();
        Validadores validadores = new Validadores();
        public Models.TbUsuario Alterar(Models.TbUsuario usuario)
        {
            validadores.Alterar(usuario);
            return databaseUsuario.Alterar(usuario);
        }
        public Models.TbUsuario ConsultarUsuario(int IdUsuario)
        {
            validadores.ValidarId(IdUsuario);
            Models.TbUsuario resp = databaseUsuario.Consultar(IdUsuario);
            if(resp == null) throw new ArgumentException("Usuario não encontrado.");
            return resp;
        }
        public Models.TbUsuario RecuperarSenha(string CPF, string RG)
        {
            
            return databaseUsuario.RecuperarSenha(CPF,RG);
        }
    }
}