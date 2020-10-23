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
        public bool? ConsultarSeOAnuncioEstaFavoritado(int IdAnuncio, int IdUsuario)
        {
            Models.TbFavorito resp = ctx.TbFavorito.FirstOrDefault(x => x.IdAnuncio == IdAnuncio && x.IdUsuario == IdUsuario);
            bool? a = false;
            if(resp != null && resp.BtFavorito == true)
            {
                a = true;
            }
            return a;
        }
    }
}