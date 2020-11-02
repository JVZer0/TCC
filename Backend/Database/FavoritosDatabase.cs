using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Database
{
    public class FavoritosDatabase
    {
        Models.anuncioRoupaContext ctx = new Models.anuncioRoupaContext();
        public bool? ConsultarSeOAnuncioEstaFavoritado(int? IdAnuncio, int? IdUsuario)
        {
            Models.TbFavorito resp = ctx.TbFavorito.FirstOrDefault(x => x.IdAnuncio == IdAnuncio && x.IdUsuario == IdUsuario);
            bool? a = false;
            if(resp != null && resp.BtFavorito == true)
            {
                a = true;
            }
            return a;
        }
        public List<Models.TbFavorito> ConsultarMeusAnunciosFavoritos(int IdUsuario)
        {
            List<Models.TbFavorito> resp = ctx.TbFavorito
                                              .Include(x => x.IdAnuncioNavigation)
                                              .Include(x => x.IdAnuncioNavigation.TbImagem)
                                              .Where(x => x.IdUsuario == IdUsuario && x.IdAnuncioNavigation.DsSituacao == "Publicado").ToList();
            return resp;
        }
        public Models.TbFavorito FavoritarAnuncio(Models.TbFavorito req)
        {
            ctx.Add(req);
            ctx.SaveChanges();
            return req;
        }
        public Models.TbFavorito ConsultarFavorito(int IdFavorito)
        {
            Models.TbFavorito resp = ctx.TbFavorito.Include(x => x.IdAnuncioNavigation)
                                                   .Include(x => x.IdAnuncioNavigation.TbImagem)
                                                   .Where(x => x.IdAnuncioNavigation.DsSituacao == "Publicado")
                                                   .FirstOrDefault(x => x.IdFavorito == IdFavorito);
            return resp;
        }
        public Models.TbFavorito DeletarFavorito(int IdAnuncio, int IdUsuario)
        {
            Models.TbFavorito resp = ctx.TbFavorito.Include(x => x.IdAnuncioNavigation)
                                                   .FirstOrDefault(x => x.IdAnuncio == IdAnuncio && x.IdUsuario == IdUsuario);
            ctx.Remove(resp);
            ctx.SaveChanges();
            return resp;
        }
    }
}