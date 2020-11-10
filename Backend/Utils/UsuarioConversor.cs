using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Utils
{
    public class UsuarioConversor
    {
        public Models.TbUsuario ConversorTabelaUsuario (Models.Request.AnuncioRoupasRequest.Usuario req)
        {
            Models.TbUsuario usuario = new Models.TbUsuario();
            usuario.IdUsuario = req.IdUsuario;
            usuario.IdLoginNavigation = new Models.TbLogin(){
                DsSenha = req.Senha.Trim(),
                DsUsername = req.Username.Trim()
            };
            usuario.NmUsuario = req.NomeUsuario.Trim();
            usuario.DtNascimento = req.DataDeNascimento;
            usuario.DsSexo = req.Sexo.Trim();
            usuario.DsEmail = req.Email.Trim();
            usuario.DsCelular = req.Celular.Trim();
            usuario.DsEstado = req.Estado.Trim();
            usuario.DsCidade = req.Cidade.Trim();
            usuario.DsCep = req.CEP.Trim();
            usuario.DsEndereco = req.Endereco.Trim();
            usuario.DsBairro = req.Bairro.Trim();
            usuario.DsNEndereco = req.N_Endereco.Trim();
            usuario.DsComplementoEndereco = req.ComplementoEndereco.Trim();

            return usuario;
        }

        public Models.Response.AnuncioRoupasResponse.Usuario ConversorTabelaResponse(Models.TbUsuario entrada)
        {
            Models.Response.AnuncioRoupasResponse.Usuario resp = new Models.Response.AnuncioRoupasResponse.Usuario();
            resp.IdUsuario = entrada.IdUsuario;
            resp.IdLogin = entrada.IdLogin;
            resp.Username = entrada.IdLoginNavigation.DsUsername;
            resp.Senha = entrada.IdLoginNavigation.DsSenha;
            resp.NomeUsuario = entrada.NmUsuario;
            resp.DataDeNascimento = entrada.DtNascimento;
            resp.Sexo = entrada.DsSexo;
            resp.CPF = entrada.DsCpf;
            resp.RG = entrada.DsRg;
            resp.Email = entrada.DsEmail;
            resp.Celular = entrada.DsCelular;
            resp.Estado = entrada.DsEstado;
            resp.Cidade = entrada.DsCidade;
            resp.CEP = entrada.DsCep;
            resp.Endereco = entrada.DsEndereco;
            resp.Bairro = entrada.DsBairro;
            resp.N_Enderoco = entrada.DsNEndereco;
            resp.ComplementoEndereco = entrada.DsComplementoEndereco;
            resp.ConcordoTermos = entrada.BtConcordoTermos;

            return resp;
        }
    }
}