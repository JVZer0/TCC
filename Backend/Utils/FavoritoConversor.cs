using System;
using System.Collections.Generic;
using System.Linq;
namespace Backend.Utils
{
    public class FavoritoConversor
    {
        public Models.Response.AnuncioRoupasResponse.Anuncio FavoritoParaResponse(Models.TbFavorito favorito)
        {
            Models.Response.AnuncioRoupasResponse.Anuncio resp = new Models.Response.AnuncioRoupasResponse.Anuncio();
            resp.Titulo = favorito.IdAnuncioNavigation.DsTitulo;
            resp.TipoProduto = favorito.IdAnuncioNavigation.TpProduto;
            resp.Tamanho = favorito.IdAnuncioNavigation.DsTamanho;
            resp.Preco = favorito.IdAnuncioNavigation.VlPreco;
            resp.Marca = favorito.IdAnuncioNavigation.NmMarca;
            resp.Condicao = favorito.IdAnuncioNavigation.DsCondicao;
            resp.DataPublicacao = favorito.IdAnuncioNavigation.DtPublicacao;
            resp.Descricao = favorito.IdAnuncioNavigation.DsDescricao;
            resp.Genero = favorito.IdAnuncioNavigation.DsGenero;
            resp.IdAnuncio = favorito.IdAnuncioNavigation.IdAnuncio;
            resp.Imagens = favorito.IdAnuncioNavigation.TbImagem.Select(x => new Models.Response.AnuncioRoupasResponse.Imagem(){
                IdDoAnuncio = x.IdAnuncio,
                IdImagem = x.IdImagem,
                TextoImagem = x.ImgAnuncio
            }).ToList();
            return resp;
        }
        public List<Models.Response.AnuncioRoupasResponse.Anuncio> ConverterVariosFavoritosParaResponse(List<Models.TbFavorito> favoritos)
        {
            List<Models.Response.AnuncioRoupasResponse.Anuncio> resp = new List<Models.Response.AnuncioRoupasResponse.Anuncio>();
            foreach (Models.TbFavorito item in favoritos)
            {
                Models.Response.AnuncioRoupasResponse.Anuncio a = this.FavoritoParaResponse(item);
                resp.Add(a);
            }
            return resp;
        }
        public Models.TbFavorito ConversorFavoritarTabela(int IdAnuncio, int IdUsuario)
        {
            Models.TbFavorito resp = new Models.TbFavorito();
            resp.IdAnuncio = IdAnuncio;
            resp.IdUsuario = IdUsuario;
            resp.BtFavorito = true;
            return resp;
        }
    }
}