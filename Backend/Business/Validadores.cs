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



        private void Data(DateTime? data)
        {
            if(data == new DateTime()) throw new ArgumentException("Data incorreta.");    
        }
        private void ValidarTexto(string texto)
        {
            if(string.IsNullOrEmpty(texto)) throw new ArgumentException("Campo obrigatorio.");    
        }
        private void ValidarId(int? id)
        {
            if(id <= 0) throw new ArgumentException("Id inválido.");
        }

    }
}