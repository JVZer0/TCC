using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Utils
{
    public class LoginConversor
    {
        public Models.TbLogin ConvesorParaTabelaLogin(Models.Request.AnuncioRoupasRequest.Login request)
        {
            Models.TbLogin final = new Models.TbLogin();
            final.DsUsername = request.Username;
            final.DsSenha = request.Senha;

            return final;
        }
        public Models.Response.AnuncioRoupasResponse.Login ConversorDeTabelaParaResponse(Models.TbLogin entrada)
        {
            Models.Response.AnuncioRoupasResponse.Login final = new Models.Response.AnuncioRoupasResponse.Login();
            final.IdLogin = entrada.IdLogin;
            
            final.NomeUsuario = entrada.TbUsuario.FirstOrDefault().NmUsuario;
            final.IdUsuario = entrada.TbUsuario.FirstOrDefault().IdUsuario;
            final.RG = entrada.TbUsuario.FirstOrDefault().DsRg;
            final.Email = entrada.TbUsuario.FirstOrDefault().DsEmail;
            final.CPF = entrada.TbUsuario.FirstOrDefault().DsCpf;

            return final;
        }
        public Models.TbLogin ConversorTabelaLoginRequestCadastrar(Models.Request.AnuncioRoupasRequest.Cadastro req)
        {
            Models.TbLogin resp = new Models.TbLogin();
            resp.DsUsername = req.Username;
            resp.DsSenha = req.Senha;
            
            Models.TbUsuario user = new Models.TbUsuario();
            user.NmUsuario = req.NomeUsuario;
            user.DsEmail = req.Email;
            user.DtNascimento = req.DataDeNascimento;
            user.DsSexo = req.Sexo;
            user.DsCpf = req.CPF;
            user.DsRg = req.RG;
            user.DsCelular = req.Celular;
            user.DsEstado = req.Estado;
            user.DsCidade = req.Cidade;
            user.DsCep = req.CEP;
            user.DsBairro = req.Bairro;
            user.DsNEndereco = req.N_Endereco;
            user.DsEndereco = req.Endereco;
            user.DsComplementoEndereco = req.ComplementoEndereco;
            user.BtConcordoTermos = req.ConcordoTermos;

            resp.TbUsuario.Add(user);

            return resp;
        }
        public Models.Response.AnuncioRoupasResponse.Cadastro ConversorTabelaLoginResponseCadastrar(Models.TbLogin req)
        {
            Models.Response.AnuncioRoupasResponse.Cadastro resp = new Models.Response.AnuncioRoupasResponse.Cadastro();
            resp.Username = req.DsUsername;
            resp.Senha = req.DsSenha;
            resp.NomeUsuario = req.TbUsuario.First().NmUsuario;
            resp.Email = req.TbUsuario.First().DsEmail;
            resp.DataDeNascimento = req.TbUsuario.First().DtNascimento;
            resp.Sexo = req.TbUsuario.First().DsSexo;
            resp.CPF = req.TbUsuario.First().DsCpf;
            resp.RG = req.TbUsuario.First().DsRg;
            resp.Celular = req.TbUsuario.First().DsCelular;
            resp.Estado = req.TbUsuario.First().DsEstado;
            resp.Cidade = req.TbUsuario.First().DsCidade;
            resp.CEP = req.TbUsuario.First().DsCep;
            resp.Bairro = req.TbUsuario.First().DsBairro;
            resp.N_Endereco = req.TbUsuario.First().DsNEndereco;
            resp.Endereco = req.TbUsuario.First().DsEndereco;
            resp.ComplementoEndereco = req.TbUsuario.First().DsComplementoEndereco;

            return resp;
        }
    }
}