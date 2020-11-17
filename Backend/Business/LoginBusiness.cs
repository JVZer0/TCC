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
            if(request.TbUsuario.FirstOrDefault().DsEmail.Contains("@") == false) throw new ArgumentException("Email incorreto.");
            if(request.TbUsuario.FirstOrDefault().DsEmail.Contains(".com") == false) throw new ArgumentException("Email incorreto.");
            if(request.TbUsuario.FirstOrDefault().NmUsuario.Length > 255) throw new ArgumentException("O nome não pode ter mais de 255 caracteres.");
            if(request.TbUsuario.FirstOrDefault().DsEmail.Length > 255) throw new ArgumentException("O email não pode ter mais de 255 caracteres.");
            if(request.TbUsuario.FirstOrDefault().DsCidade.Length > 130) throw new ArgumentException("A cidade não pode ter mais de 130 caracteres.");
            if(request.TbUsuario.FirstOrDefault().DsEndereco.Length > 255) throw new ArgumentException("A endereço não pode ter mais de 255 caracteres.");
            try
            {
                int cep = Convert.ToInt32(request.TbUsuario.FirstOrDefault().DsCep.Replace("-","").Replace(" ",""));
            }
            catch (System.Exception)
            {
                throw new ArgumentException("CEP não pode ter letras nem simbolos.");
            }

            try
            {
                long cpf = Convert.ToInt64(request.TbUsuario.FirstOrDefault().DsCpf.Replace(".","").Replace("/","").Replace("-","").Replace(" ",""));
            }
            catch (System.Exception)
            {
                throw new ArgumentException("CPF não pode ter letras nem símbolos.");
            }

            try
            {
                long celular = Convert.ToInt64(request.TbUsuario.FirstOrDefault().DsCelular.Replace("(","").Replace(")","").Replace(" ","").Replace("-",""));
            }
            catch (System.Exception)
            {
                throw new ArgumentException("Celular não pode ter letras nem símbolos.");
            }
            if(request.TbUsuario.FirstOrDefault().DsCep.Contains(" ")) throw new ArgumentException("O CEP não pode ter espaços.");
            if(request.TbUsuario.FirstOrDefault().DsRg.Contains(" ")) throw new ArgumentException("O RG não pode ter espaços.");
            if(request.TbUsuario.FirstOrDefault().DsCpf.Contains(" ")) throw new ArgumentException("O CPF não pode ter espaços.");
            if(request.TbUsuario.FirstOrDefault().DtNascimento >= DateTime.Now.AddYears(-5)) throw new ArgumentException("Data de nascimento errada."); 
            return databaseLogin.Cadastrar(request);
        }
    }
}