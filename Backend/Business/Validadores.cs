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

        public Models.TbUsuario Alterar(Models.TbUsuario usuario)
        {
            if (usuario.NmUsuario == string.Empty)
                throw new ArgumentException("Nome Obrigatório."); 
            
            if (usuario.DsSexo == string.Empty)
                throw new ArgumentException("Sexo/Genero invalido"); 
            
            if (usuario.DsCpf == string.Empty)
                throw new ArgumentException("CPF Obrigatório.");
            
            if (usuario.DsRg == string.Empty)
                throw new ArgumentException("RG Obrigatório.");
            
            if (usuario.DsEmail == string.Empty)
                throw new ArgumentException("Email Obrigatório.");
            
            if (usuario.DsCelular == string.Empty)
                throw new ArgumentException("Celular Obrigatório.");
            
            if (usuario.DsEstado == string.Empty)
                throw new ArgumentException("Estado Obrigatório.");
            
            if (usuario.DsCidade == string.Empty) 
                throw new ArgumentException("Cidade Obrigatório.");
            
            if (usuario.DsCep == string.Empty) 
                throw new ArgumentException("CEP Obrigatório.");
            
            if (usuario.DsEndereco == string.Empty)
                throw new ArgumentException("Endereço Obrigatório.");
            
            if (usuario.DsBairro == string.Empty)
                throw new ArgumentException("Bairro Obrigatório.");
            
            if (usuario.DsNEndereco == string.Empty)
                throw new ArgumentException("Nº Endereço Obrigatório.");
            
            return usuario;
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