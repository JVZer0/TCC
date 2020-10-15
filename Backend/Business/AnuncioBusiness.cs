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
        public List<Models.TbAnuncio> TodosAnuncios ()
        {
            List<Models.TbAnuncio> anuncios = databaseanuncio.TodosAnuncios();
            return anuncios;
        }

    }
}