using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Backend.Models.Response
{
    public class RelatorioResponse
    {
        public class AnunciosPorDia
        {
            public DateTime? Dia { get; set; }
            public string Cliente { get; set; }
            public string TipoProduto { get; set; }
            public decimal? Preco { get; set; }
        }
        public class AnunciosPorMes
        {
            public string Mes { get; set; }
            public int QtdAnuncios { get; set; }
            public decimal? SomaDosPrecoDosAnuncios { get; set; }
        }
        public class Top10Anunciantes
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Celular { get; set; }
            public int QtdAnuncios { get; set; }
            public decimal? SomaDosPrecoDosAnuncios { get; set; }
        }
        public class Top10ProdutosMaisAnunciados
        {
            public string Nome { get; set; }
            public int QtdAnunciada { get; set; }
            public int TotalComprado { get; set; }
        }
        public class EstadosComMaisAnuncios
        {
            public string Estado { get; set; }
            public int QtdAnuncio { get; set; }
            public int QtdVendido { get; set; }
        }
    }
}