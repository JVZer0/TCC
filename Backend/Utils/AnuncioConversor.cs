using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Backend.Utils
{
    public class AnuncioConversor
    {
        public Models.Response.AnuncioRoupasResponse.Anuncio ConversorAnuncioResponse (Models.TbAnuncio anuncio)
        {
            Models.Response.AnuncioRoupasResponse.Anuncio resp = new Models.Response.AnuncioRoupasResponse.Anuncio();
            resp.IdAnuncio = anuncio.IdAnuncio;
            resp.Titulo = anuncio.DsTitulo;
            resp.Descricao = anuncio.DsDescricao;
            resp.Produto = anuncio.TpProduto;
            resp.Condicao = anuncio.DsCondicao;
            resp.Genero = anuncio.DsGenero;
            resp.Marca = anuncio.NmMarca;
            resp.Tamanho = anuncio.DsTamanho;
            resp.Preco = anuncio.VlPreco;
            resp.Estado = anuncio.DsEstado;
            resp.Cep = anuncio.DsCep;
            resp.Vendido = anuncio.BtVendido;
            resp.Situacao = anuncio.DsSituacao;
            resp.Publicacao = anuncio.DtPublicacao;
            resp.IdUsuario = anuncio.IdUsuario;

            return resp;
        }
        public List<Models.Response.AnuncioRoupasResponse.Anuncio> ListaTabela (List<Models.TbAnuncio> req)
        {
            List<Models.Response.AnuncioRoupasResponse.Anuncio> resp = new List<Models.Response.AnuncioRoupasResponse.Anuncio>();
            foreach (Models.TbAnuncio anuncios in req)
            {
                Models.Response.AnuncioRoupasResponse.Anuncio x = this.ConversorAnuncioResponse(anuncios);
                resp.Add(x);       
            }
            return resp;
        }
    }
}