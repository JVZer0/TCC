using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class LoginDatabase
    {
        Models.anunciosRoupasContext ctx = new Models.anunciosRoupasContext();
        public Models.TbLogin Logar(Models.TbLogin request)
        {
            Models.TbLogin resp = ctx.TbLogin.Include(x => x.TbUsuario).FirstOrDefault(x => x.DsUsername == request.DsUsername && x.DsSenha == request.DsSenha);
            return resp;
        }
    }
}