using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class UsuarioDatabase
    {
        Models.anuncioRoupaContext ctx = new Models.anuncioRoupaContext();
        public Models.TbUsuario Alterar(Models.TbUsuario usuario)
        {
            Models.TbUsuario atualUser = ctx.TbUsuario.First(x => x.IdUsuario == usuario.IdUsuario);
            Models.TbLogin atualLogin = ctx.TbLogin.First(y => y.IdLogin == atualUser.IdLogin);
            atualUser.NmUsuario = usuario.NmUsuario;
            atualLogin.DsSenha = usuario.IdLoginNavigation.DsSenha;
            atualLogin.DsUsername = usuario.IdLoginNavigation.DsUsername;
            atualUser.DtNascimento = usuario.DtNascimento;
            atualUser.DsSexo = usuario.DsSexo;
            atualUser.DsEmail = usuario.DsEmail;
            atualUser.DsCelular = usuario.DsCelular;
            atualUser.DsEstado = usuario.DsEstado;
            atualUser.DsCidade = usuario.DsCidade;
            atualUser.DsCep = usuario.DsCep;
            atualUser.DsEndereco = usuario.DsEndereco; 
            atualUser.DsBairro = usuario.DsBairro;
            atualUser.DsNEndereco = usuario.DsNEndereco;
            atualUser.DsComplementoEndereco = usuario.DsComplementoEndereco;

            ctx.SaveChanges();
            return atualUser;
        }
        public Models.TbUsuario Consultar(int IdUsuario)
        {
            Models.TbUsuario resp = ctx.TbUsuario.Include(y => y.IdLoginNavigation).FirstOrDefault(x => x.IdUsuario == IdUsuario);
            return resp;
        }
        public Models.TbUsuario RecuperarSenha(string CPF, string RG)
        {
            Models.TbUsuario resp = ctx.TbUsuario.Include(x => x.IdLoginNavigation).FirstOrDefault(x => x.DsCpf == CPF && x.DsRg == RG);
            return resp;
        }
    }
}