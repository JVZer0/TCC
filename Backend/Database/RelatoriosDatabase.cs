using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class RelatoriosDatabase
    {
        Models.anuncioRoupaContext ctx = new Models.anuncioRoupaContext();
        public List<Models.TbAnuncio> AnunciosPorDia(DateTime dia)
        {
            List<Models.TbAnuncio> anuncios = ctx.TbAnuncio.Include(x => x.IdUsuarioNavigation)
                                                           .Where(x => x.DtPublicacao.Value.Day == dia.Day 
                                                                  &&   x.DtPublicacao.Value.Month == dia.Month
                                                                  &&   x.DtPublicacao.Value.Year == dia.Year).ToList();
            return anuncios;
        }
        public List<Models.TbAnuncio> AnunciosPorMes(int mesInicio, int mesFim)
        {
            List<Models.TbAnuncio> anuncios = ctx.TbAnuncio.Where(x => x.DtPublicacao.Value.Month >= mesInicio
                        && x.DtPublicacao.Value.Month <= mesFim).ToList();
            return anuncios;
        }
        public List<Models.TbUsuario> Top10Anunciantes()
        {
            List<Models.TbUsuario> users = ctx.TbUsuario.Include(x => x.TbAnuncio).ToList();
            return users;
        }
        public List<Models.TbAnuncio> Top10ProdutosMaisAnunciados()
        {
            List<Models.TbAnuncio> anuncios = ctx.TbAnuncio.ToList();
            return anuncios;
        }
        public List<Models.TbAnuncio> QtdAnunciosPorEstado()
        {
            List<Models.TbAnuncio> anuncios = ctx.TbAnuncio.ToList();
            return anuncios;
        }
    }
}