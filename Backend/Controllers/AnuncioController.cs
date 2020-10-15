using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnuncioController : ControllerBase
    {
        Business.AnuncioBusiness businessanuncio = new Business.AnuncioBusiness();
        Utils.AnuncioConversor conversoranuncio = new Utils.AnuncioConversor();
        [HttpGet]
        public ActionResult<List<Models.Response.AnuncioRoupasResponse.Anuncio>> TodosAnuncios ()
        {
            try
            {
                List<Models.TbAnuncio> anuncios = businessanuncio.TodosAnuncios();
                return conversoranuncio.ListaTabela(anuncios);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
