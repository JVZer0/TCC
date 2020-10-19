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
        public Models.Response.AnuncioRoupasResponse.Anuncio ConversorAnuncioResponse(Models.TbAnuncio anuncio)
        {
            Models.Response.AnuncioRoupasResponse.Anuncio resp = new Models.Response.AnuncioRoupasResponse.Anuncio();
            resp.IdAnuncio = anuncio.IdAnuncio;
            resp.Titulo = anuncio.DsTitulo;
            resp.Descricao = anuncio.DsDescricao;
            resp.TipoProduto = anuncio.TpProduto;
            resp.Condicao = anuncio.DsCondicao;
            resp.Genero = anuncio.DsGenero;
            resp.Marca = anuncio.NmMarca;
            resp.Tamanho = anuncio.DsTamanho;
            resp.Preco = anuncio.VlPreco;
            resp.DataPublicacao = anuncio.DtPublicacao;

            resp.Imagens = anuncio.TbImagem.Select(x => new Models.Response.AnuncioRoupasResponse.Imagem(){
                IdImagem = x.IdImagem,
                IdDoAnuncio = x.IdAnuncio,
                TextoImagem = x.ImgAnuncio
            }).ToList();

            return resp;
        }
        public List<Models.Response.AnuncioRoupasResponse.Anuncio> ConversorAnuncioListaResponse(List<Models.TbAnuncio> req)
        {
            List<Models.Response.AnuncioRoupasResponse.Anuncio> resp = new List<Models.Response.AnuncioRoupasResponse.Anuncio>();
            foreach (Models.TbAnuncio anuncios in req)
            {
                Models.Response.AnuncioRoupasResponse.Anuncio x = this.ConversorAnuncioResponse(anuncios);
                resp.Add(x);       
            }
            return resp;
        }
        public Models.Response.AnuncioRoupasResponse.AnuncioDetalhado AnuncioDetalhadoResponse(Models.TbAnuncio anuncio)
        {
            Models.Response.AnuncioRoupasResponse.AnuncioDetalhado resp = new Models.Response.AnuncioRoupasResponse.AnuncioDetalhado();
            resp.IdAnuncio = anuncio.IdAnuncio;
            resp.IdDonoAnuncio = anuncio.IdUsuario;
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
            resp.NomeVendedor = anuncio.IdUsuarioNavigation.NmUsuario;
            resp.CelularVendedor = anuncio.IdUsuarioNavigation.DsCelular;
            resp.Cidade = anuncio.DsCidade;

            resp.PerguntasERespotas = anuncio.TbPerguntaResposta.Select(x => new Models.Response.AnuncioRoupasResponse.PerguntaEResposta(){
                IdPerguntaResposta = x.IdPerguntaResposta,
                Pergunta = x.DsPergunta,
                DataPergunta = x.DtPergunta,
                Respondida = x.BtRespondida,
                Resposta = x.DsResposta,
                IdPerguntador = x.IdPerguntador,
                IdRespondedor = x.IdRespondedor,
                IdAnuncio = x.IdAnuncio
            }).ToList();

            resp.Imagens = anuncio.TbImagem.Select(x => new Models.Response.AnuncioRoupasResponse.Imagem(){
                IdImagem = x.IdImagem,
                IdDoAnuncio = x.IdAnuncio,
                TextoImagem = x.ImgAnuncio
            }).ToList();

            return resp;
        }

        public Models.TbPerguntaResposta PerguntarParaTabela(Models.Request.AnuncioRoupasRequest.Pergunta req)
        {
            Models.TbPerguntaResposta resp = new Models.TbPerguntaResposta();
            resp.BtRespondida = false;
            resp.DsPergunta = req.Texto;
            resp.DtPergunta = DateTime.Now;
            resp.IdAnuncio = req.IdAnuncio;
            resp.IdPerguntador = req.IdUsuarioPerguntador;
            resp.IdRespondedor = req.IdUsuarioRespondedor;
            return resp;
        }

        public Models.Response.AnuncioRoupasResponse.PerguntaEResposta PerguntarParaResponse(Models.TbPerguntaResposta req)
        {
            Models.Response.AnuncioRoupasResponse.PerguntaEResposta resp = new Models.Response.AnuncioRoupasResponse.PerguntaEResposta();
            resp.IdPerguntaResposta = req.IdPerguntaResposta;
            resp.Pergunta = req.DsPergunta;
            resp.DataPergunta = req.DtPergunta;
            resp.Respondida = req.BtRespondida;
            resp.IdPerguntador = req.IdPerguntador;
            resp.IdRespondedor = req.IdRespondedor;
            resp.IdAnuncio = req.IdAnuncio;

            return resp;
        }

        public Models.TbPerguntaResposta ResponderParaTabela(Models.Request.AnuncioRoupasRequest.Resposta req)
        {
            Models.TbPerguntaResposta resp = new Models.TbPerguntaResposta();
            resp.IdRespondedor = req.IdUsuarioRespondedor;
            resp.IdPerguntaResposta = req.IdPerguntaResposta;
            resp.DsResposta = req.Texto;
            resp.BtRespondida = true;
            return resp;
        }

        public Models.Response.AnuncioRoupasResponse.PerguntaEResposta ResponderParaResponse(Models.TbPerguntaResposta req)
        {
            Models.Response.AnuncioRoupasResponse.PerguntaEResposta resp = new Models.Response.AnuncioRoupasResponse.PerguntaEResposta();
            resp.IdPerguntaResposta = req.IdPerguntaResposta;
            resp.Pergunta = req.DsPergunta;
            resp.Resposta = req.DsResposta;
            resp.DataPergunta = req.DtPergunta;
            resp.Respondida = req.BtRespondida;
            resp.IdPerguntador = req.IdPerguntador;
            resp.IdRespondedor = req.IdRespondedor;
            resp.IdAnuncio = req.IdAnuncio;
            return resp;
        }
    }
}