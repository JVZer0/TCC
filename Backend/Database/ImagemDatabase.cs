using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Database
{
    public class ImagemDatabase
    {
        Models.anuncioRoupaContext ctx = new Models.anuncioRoupaContext();
        public Models.TbImagem ApagarImagem(int IdImagem, int IdAnuncio)
        {
            Models.TbImagem resp = ctx.TbImagem.FirstOrDefault(x => x.IdImagem == IdImagem && x.IdAnuncio == IdAnuncio);
            ctx.Remove(resp);
            ctx.SaveChanges();
            return resp;
        }
        public Models.TbImagem ConsultarImagem(int IdImagem, int IdAnuncio)
        {
            Models.TbImagem resp = ctx.TbImagem.FirstOrDefault(x => x.IdImagem == IdImagem && x.IdAnuncio == IdAnuncio);
            return resp;
        }
        public Models.TbImagem InserirImagem(Models.TbImagem req)
        {
            ctx.Add(req);
            ctx.SaveChanges();
            return req;
        }
        public List<Models.TbImagem> InserirVariasImagens(List<Models.TbImagem> req)
        {
            ctx.AddRange(req);
            ctx.SaveChanges();
            return req;
        }
    }
}