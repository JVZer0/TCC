using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class UsuarioDatabase
    {
        Models.anunciosRoupasContext ctx = new Models.anunciosRoupasContext();
        public Models.TbUsuario Alterar(Models.TbUsuario usuario)
        {
            Models.TbUsuario atualUser = ctx.TbUsuario.First(x => x.IdUsuario == usuario.IdUsuario);
            Models.TbLogin atualLogin = ctx.TbLogin.First(y => y.IdLogin == atualUser.IdLogin);
            atualUser.NmUsuario = usuario.NmUsuario;
            atualLogin.DsSenha = usuario.IdLoginNavigation.DsSenha;
            atualLogin.DsUsername = usuario.IdLoginNavigation.DsUsername;
            atualUser.DtNascimento = usuario.DtNascimento;
            atualUser.DsSexo = usuario.DsSexo;
            atualUser.DsCpf = usuario.DsCpf;
            atualUser.DsRg = usuario.DsRg;
            atualUser.DsEmail = usuario.DsEmail;
            atualUser.DsCelular = usuario.DsCelular;
            atualUser.DsEstado = usuario.DsEstado;
            atualUser.DsCidade = usuario.DsCidade;
            atualUser.DsCep = usuario.DsCep;
            atualUser.DsEndereco = usuario.DsEndereco; 
            atualUser.DsBairro = usuario.DsBairro;
            atualUser.DsNEndereco = usuario.DsNEndereco;
            atualUser.DsComplementoEndereco = usuario.DsComplementoEndereco;
            atualUser.BtConcordoTermos = usuario.BtConcordoTermos;

            ctx.SaveChanges();
            return atualUser;
        }
    }
}