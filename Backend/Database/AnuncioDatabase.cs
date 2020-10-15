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
        public List<Models.TbAnuncio> TodosAnuncios()
        {
            List<Models.TbAnuncio> anuncios = ctx.TbAnuncio.OrderByDescending(x => x.DtPublicacao).ToList();
            return anuncios;
        }    
    }
}