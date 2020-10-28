using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Database
{
    public class AnuncioDatabase
    {
        Models.anuncioRoupaContext ctx = new Models.anuncioRoupaContext();
        public List<Models.TbAnuncio> ConsultarAnuncios(string BarraPesquisa, string Estado, string Cidade, string Genero, string Condicao)
        {
            List<Models.TbAnuncio> anuncios = ctx.TbAnuncio.Include(x => x.TbImagem)
                                                           .Where(x => x.BtVendido == false && x.DsSituacao == "Publicado" && x.DsTitulo.ToLower().Contains(BarraPesquisa.ToLower()) 
                                                                  && x.DsEstado.ToLower().Contains(Estado.ToLower()) && x.DsCidade.ToLower().Contains(Cidade.ToLower())
                                                                  && x.DsGenero.ToLower().Contains(Genero.ToLower()) && x.DsCondicao.ToLower().Contains(Condicao.ToLower()))
                                                          
                                                           .OrderByDescending(x => x.DtPublicacao).ToList();
            return anuncios;
        }
        public Models.TbAnuncio ConsultarAnuncioDetalhado(int? IdAnuncio)
        {
            Models.TbAnuncio resp = ctx.TbAnuncio.Include(x => x.IdUsuarioNavigation).Include(x => x.TbImagem)
                                                                                     .Include(x => x.IdUsuarioNavigation)
                                                                                     .Include(x => x.TbPerguntaResposta)
                                                                                     .FirstOrDefault(x => x.IdAnuncio == IdAnuncio);
            return resp;
        }
        public Models.TbPerguntaResposta Perguntar(Models.TbPerguntaResposta req)
        {
            ctx.Add(req);
            ctx.SaveChanges();
            return req;
        }
        public Models.TbPerguntaResposta ConsultarTBPergundaERespota(int? IdPerguntaResposta)
        {
            Models.TbPerguntaResposta resp = ctx.TbPerguntaResposta.FirstOrDefault(x => x.IdPerguntaResposta == IdPerguntaResposta);
            return resp;
        }
        public Models.TbPerguntaResposta Responder(Models.TbPerguntaResposta req)
        {
            Models.TbPerguntaResposta resp = ctx.TbPerguntaResposta.FirstOrDefault(x => x.IdPerguntaResposta == req.IdPerguntaResposta);
            resp.DsResposta = req.DsResposta;
            resp.BtRespondida = req.BtRespondida;
            ctx.SaveChanges();
            return resp;
        }
        public Models.TbAnuncio Anunciar(Models.TbAnuncio anuncio)
        {
            ctx.Add(anuncio);
            ctx.SaveChanges();
            return anuncio;
        }
        public List<Models.TbAnuncio> ConsultarMeusAnuncios(int? IdUsuario)
        {
            List<Models.TbAnuncio> meusanuncios = ctx.TbAnuncio
                                                        .Include(x => x.IdUsuarioNavigation)
                                                        .Where(x => x.IdUsuario == IdUsuario)      
                                                        .ToList();

            return meusanuncios;
        }
        public void DeletarAnuncio (int IdAnuncio)
        {
            Models.TbAnuncio deletar = ctx.TbAnuncio.Include(x => x.TbImagem)
                                                    .Include(x => x.TbPerguntaResposta)
                                                    .Include(x => x.TbFavorito)
                                                    .FirstOrDefault(x => x.IdAnuncio == IdAnuncio);
            ctx.Remove(deletar);
            ctx.SaveChanges();
        }
        public Models.TbAnuncio InativarAnuncio (int IdAnuncio)
        {
            Models.TbAnuncio UserAnuncio = ctx.TbAnuncio.First(x => x.IdAnuncio == IdAnuncio);
            UserAnuncio.DsSituacao = "Inativo";

            ctx.SaveChanges();
            return UserAnuncio;
        }
        public Models.TbAnuncio AnuncioVendido (int IdAnuncio)
        {
            Models.TbAnuncio UserAnuncio = ctx.TbAnuncio.First(x => x.IdAnuncio == IdAnuncio);
            UserAnuncio.BtVendido = true;
            UserAnuncio.DsSituacao = "Inativo";

            ctx.SaveChanges();
            return UserAnuncio; 
        }
    }
}