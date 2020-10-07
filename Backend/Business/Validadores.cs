using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Business
{
    public class Validadores
    {
        public void VerificarLogin(Models.TbLogin tabela)
        {
            if(tabela == null) throw new ArgumentException("Username ou senha incorretos.");
                
            ValidarTexto(tabela.DsUsername);
            ValidarTexto(tabela.DsSenha);  
        }

        public void Alterar(Models.TbUsuario usuario)
        {
            ValidarTexto(usuario.NmUsuario);
            ValidarTexto(usuario.DsSexo);
            ValidarTexto(usuario.DsCpf);
            ValidarTexto(usuario.DsRg);
            ValidarTexto(usuario.DsEmail);
            ValidarTexto(usuario.DsCelular);
            ValidarTexto(usuario.DsEstado);
            ValidarTexto(usuario.DsCidade);
            ValidarTexto(usuario.DsCep);
            ValidarTexto(usuario.DsEndereco);
            ValidarTexto(usuario.DsBairro);
            ValidarTexto(usuario.DsNEndereco);
            ValidarData(usuario.DtNascimento);
            ValidarTermos(usuario.BtConcordoTermos);
            ValidarId(usuario.IdUsuario);
            ValidarTexto(usuario.IdLoginNavigation.DsSenha);
            ValidarTexto(usuario.IdLoginNavigation.DsUsername);
            
        }



        public void ValidarData(DateTime? data)
        {
            if(data == new DateTime()) throw new ArgumentException("Data incorreta.");    
        }
        public void ValidarTexto(string texto)
        {
            if(string.IsNullOrEmpty(texto)) throw new ArgumentException("Campo obrigatorio.");    
        }
        public void ValidarId(int? id)
        {
            if(id <= 0) throw new ArgumentException("Id inválido.");
        }
        public void ValidarTermos(bool? concordo)
        {
            if(concordo == false) throw new ArgumentException("É obrigatorio concordar com os termos.");
        }

    }
}