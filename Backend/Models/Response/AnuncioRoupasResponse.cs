using System;

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
            public string NomeUsuario { get; set; }
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
    }
}