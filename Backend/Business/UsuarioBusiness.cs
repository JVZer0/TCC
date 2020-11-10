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
            if(usuario.DsEmail.Contains("@") == false) throw new ArgumentException("Email incorreto.");
            if(usuario.DsEmail.Contains(".com") == false) throw new ArgumentException("Email incorreto.");
            try
            {
                int cep = Convert.ToInt32(usuario.DsCep.Replace("-","").Replace(" ",""));
            }
            catch (System.Exception)
            {
                throw new ArgumentException("CEP não pode ter letras nem simbolos.");
            }

            try
            {
                long celular = Convert.ToInt64(usuario.DsCelular.Replace("(","").Replace(")","").Replace(" ","").Replace("-",""));
            }
            catch (System.Exception)
            {
                throw new ArgumentException("Celular não pode ter letras nem símbolos.");
            }
            if(usuario.DsCep.Contains(" ")) throw new ArgumentException("O CEP não pode ter espaços.");
            if(usuario.DtNascimento >= DateTime.Now.AddYears(-5)) throw new ArgumentException("Data de nascimento errada."); 
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
            
            Models.TbUsuario resp = databaseUsuario.RecuperarSenha(CPF,RG);
            if(resp == null) throw new ArgumentException("Verifique os campos de CPF e RG");
            return resp;
        }
    }
}