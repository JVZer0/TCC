using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Business
{
    public class AnuncioBusiness
    {
        Database.AnuncioDatabase databaseanuncio = new Database.AnuncioDatabase();
        Validadores validadores = new Validadores();
        public List<Models.TbAnuncio> ConsultarAnuncios(string BarraPesquisa, string Estado, string Cidade, string Tamanho, string Genero, string Condicao)
        {
            if(string.IsNullOrEmpty(BarraPesquisa) || BarraPesquisa == "BarraPesquisa") { BarraPesquisa = "";};
            if(string.IsNullOrEmpty(Estado) || Estado == "Estado") { Estado = "";};
            if(string.IsNullOrEmpty(Cidade) || Cidade == "Cidade") { Cidade = "";};
            if(string.IsNullOrEmpty(Tamanho) || Tamanho == "Tamanho") { Tamanho = "";};
            if(string.IsNullOrEmpty(Tamanho) || Genero == "Genero" || Genero == "Gênero") { Genero = "";};
            if(string.IsNullOrEmpty(Condicao) || Condicao == "Condicao") { Condicao = "";};

            List<Models.TbAnuncio> anuncios = databaseanuncio.ConsultarAnuncios(BarraPesquisa, Estado, Cidade, Tamanho, Genero, Condicao);
            return anuncios;
        }

    }
}