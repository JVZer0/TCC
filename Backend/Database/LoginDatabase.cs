using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class LoginDatabase
    {
        Models.anuncioRoupaContext ctx = new Models.anuncioRoupaContext();
        public Models.TbLogin Logar(Models.TbLogin request)
        {
            Models.TbLogin resp = ctx.TbLogin.Include(x => x.TbUsuario).FirstOrDefault(x => x.DsUsername == request.DsUsername && x.DsSenha == request.DsSenha);
            return resp;
        }
        public Models.TbLogin Cadastrar(Models.TbLogin request)
        {
            ctx.Add(request);
            ctx.SaveChanges();
            return request;
        }
    }
}