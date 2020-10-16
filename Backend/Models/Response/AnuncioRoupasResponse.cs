using System;
using System.Collections.Generic;

namespace Backend.Models.Response
{
    public class AnuncioRoupasResponse
    {
        public class Login
        {
            public int IdUsuario { get; set; }
            public string NomeUsuario { get; set; }
            public string CPF { get; set; }
            public string RG { get; set; }
            public string Email { get; set; }
            public int IdLogin { get; set; }

        }
        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string Username { get; set; }
            public string Senha { get; set; }
            public string NomeUsuario{ get; set; }
            public DateTime? DataDeNascimento { get; set; }
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
            public string N_Enderoco { get; set; }
            public string ComplementoEndereco { get; set; }
            public bool? ConcordoTermos { get; set; }
            public int? IdLogin { get; set; }
        }
        public class Cadastro
        {
            public string NomeUsuario { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Senha { get; set; }
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
        }
        public class Anuncio
        {
            public int IdAnuncio { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string Produto { get; set; }
            public string Condicao { get; set; }
            public string Genero { get; set; }
            public string Marca { get; set; }
            public string Tamanho { get; set; }
            public decimal? Preco { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
            public string Cep { get; set; }
            public bool? Vendido { get; set; }
            public string Situacao { get; set; }
            public DateTime? Publicacao { get; set; }
            public string NomeVendedor { get; set; }
            public string CelularVendedor { get; set; }
            public List<Imagem> Imagens { get; set; }
            public List<PerguntaEResposta> PerguntasERespotas { get; set; }

        }
        public class Imagem
        {
            public int IdImagem { get; set; }
            public int? IdDoAnuncio { get; set; }
            public string TextoImagem { get; set; }
        }
        public class PerguntaEResposta
        {
            public int IdPerguntaResposta { get; set; }
            public string Pergunta { get; set; }
            public DateTime? DataPergunta { get; set; }
            public bool? Respondida { get; set; }
            public string Resposta { get; set; }
            public int? IdUsuario { get; set; }
            public int? IdAnuncio { get; set; }
        }
    }
}