using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Backend.Models.Request
{
    public class AnuncioRoupasRequest
    {
        public class Login
        {
            public string Username { get; set; }
            public string Senha { get; set; }
        }
        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string Username { get; set; }
            public string Senha { get; set; }
            public string NomeUsuario { get; set; }
            public DateTime DataDeNascimento { get; set; }
            public string Sexo { get; set; }
            public string CPF { get; set; }
            public string RG { get; set; }
            public string Email { get; set; }
            public string Celular { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
            public string CEP { get; set; }
            public string Endereco { get; set; }
            public string Bairro { get; set; }
            public string N_Endereco { get; set; }
            public string ComplementoEndereco { get; set; }
            public bool ConcordoTermos { get; set; }
        }
        public class Cadastro
        {
            public string NomeUsuario { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Senha { get; set; }
            public string ConfirmarSenha { get; set; }
            public DateTime? DataDeNascimento { get; set; }
            public string Sexo { get; set; }
            public string CPF { get; set; }
            public string RG { get; set; }
            public string Celular { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
            public string CEP { get; set; }
            public string Bairro { get; set; }
            public string N_Endereco { get; set; }
            public string Endereco { get; set; }
            public string ComplementoEndereco { get; set; }
            public bool? ConcordoTermos { get; set; }
        }
        public class Recuperação
        {
            public string CPF { get; set; }
            public string RG { get; set; }
        }
        public class Pergunta
        {
            public string Texto { get; set; }
            public int IdAnuncio { get; set; }
            public int? IdUsuarioPerguntador { get; set; }
            public int? IdUsuarioRespondedor { get; set; }
        }
        public class Resposta
        {
            public int IdPerguntaResposta { get; set; }
            public string Texto { get; set; }
            public int? IdUsuarioRespondedor { get; set; }
        }
        public class Anunciar
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string TipoDoProduto { get; set; }
            public string Condicao { get; set; }
            public string Genero { get; set; }
            public string Marca { get; set; }
            public string Tamanho { get; set; }
            public decimal Preco { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
            public string CEP { get; set; }
            public int IdUsuario { get; set; }
            public List<IFormFile> Imagens { get; set; }
        }
        public class test
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string TipoDoProduto { get; set; }
            public string Condicao { get; set; }
            public string Genero { get; set; }
            public string Marca { get; set; }
            public string Tamanho { get; set; }
            public decimal Preco { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
            public string CEP { get; set; }
            public int IdUsuario { get; set; }
            public IFormFile Imagens { get; set; }
        }
    }
}