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
                DsSenha = req.Senha,
                DsUsername = req.Username
            };
            usuario.NmUsuario = req.NomeUsuario;
            usuario.DtNascimento = req.DataDeNascimento;
            usuario.DsSexo = req.Sexo;
            usuario.DsCpf = req.CPF;
            usuario.DsRg = req.RG;
            usuario.DsEmail = req.Email;
            usuario.DsCelular = req.Celular;
            usuario.DsEstado = req.Estado;
            usuario.DsCidade = req.Cidade;
            usuario.DsCep = req.CEP;
            usuario.DsEndereco = req.Endereco;
            usuario.DsBairro = req.Bairro;
            usuario.DsNEndereco = req.N_Endereco;
            usuario.DsComplementoEndereco = req.ComplementoEndereco;
            usuario.BtConcordoTermos = req.ConcordoTermos;

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