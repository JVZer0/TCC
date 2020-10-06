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
            Models.TbUsuario atual = ctx.TbUsuario.First(x => x.IdUsuario == usuario.IdUsuario);
            atual.NmUsuario = usuario.NmUsuario;
            atual.DtNascimento = usuario.DtNascimento;
            atual.DsSexo = usuario.DsSexo;
            atual.DsCpf = usuario.DsCpf;
            atual.DsRg = usuario.DsRg;
            atual.DsEmail = usuario.DsEmail;
            atual.DsCelular = usuario.DsCelular;
            atual.DsEstado = usuario.DsEstado;
            atual.DsCidade = usuario.DsCidade;
            atual.DsCep = usuario.DsCep;
            atual.DsEndereco = usuario.DsEndereco; 
            atual.DsBairro = usuario.DsBairro;
            atual.DsNEndereco = usuario.DsNEndereco;
            atual.DsComplementoEndereco = usuario.DsComplementoEndereco;
            atual.BtConcordoTermos = usuario.BtConcordoTermos;

            return atual;
        }
    }
}