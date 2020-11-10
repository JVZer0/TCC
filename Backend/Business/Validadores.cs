using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Business
{
    public class Validadores
    {
        public void VerificarLogin(Models.TbLogin tabela)
        {
            if(tabela == null) throw new ArgumentException("Username ou senha incorretos.");
                
            ValidarTexto(tabela.DsUsername);
            ValidarTexto(tabela.DsSenha);  
        }

        public void Alterar(Models.TbUsuario usuario)
        {
            ValidarTexto(usuario.NmUsuario);
            ValidarTexto(usuario.DsSexo);
            ValidarTexto(usuario.DsEmail);
            ValidarTexto(usuario.DsCelular);
            ValidarTexto(usuario.DsEstado);
            ValidarTexto(usuario.DsCidade);
            ValidarTexto(usuario.DsCep);
            ValidarTexto(usuario.DsEndereco);
            ValidarTexto(usuario.DsBairro);
            ValidarTexto(usuario.DsNEndereco);
            ValidarData(usuario.DtNascimento);
            ValidarId(usuario.IdUsuario);
            ValidarTexto(usuario.IdLoginNavigation.DsSenha);
            ValidarTexto(usuario.IdLoginNavigation.DsUsername);
        }
        public void Cadastrar(Models.TbLogin req, string ConfirmarSenha)
        {
            if(req.DsSenha != ConfirmarSenha) throw new ArgumentException("Senhas diferente. Tente conferir a senha novamente.");
            ValidarTexto(req.DsUsername);
            ValidarTexto(req.DsUsername);
            ValidarTexto(req.TbUsuario.FirstOrDefault().NmUsuario);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsEmail);
            ValidarData(req.TbUsuario.FirstOrDefault().DtNascimento);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsSexo);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsCpf);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsRg);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsCelular);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsEstado);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsCidade);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsCep);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsBairro);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsNEndereco);
            ValidarTexto(req.TbUsuario.FirstOrDefault().DsEndereco);
            ValidarTermos(req.TbUsuario.FirstOrDefault().BtConcordoTermos);
            if(req.TbUsuario.FirstOrDefault().DsCpf.Length > 14 && req.TbUsuario.FirstOrDefault().DsCpf.Length < 14) throw new ArgumentException("CPF incorreto.");
            if(req.TbUsuario.FirstOrDefault().DsCep.Length > 6 && req.TbUsuario.FirstOrDefault().DsCep.Length < 6) throw new ArgumentException("CEP incorreto.");
        }
        public void RecuperarSenha(string CPF, string RG)
        {
            ValidarTexto(CPF);
            ValidarTexto(RG);
        }
        public void Perguntar(Models.TbPerguntaResposta req)
        {
            ValidarTexto(req.DsPergunta);
            ValidarData(req.DtPergunta);
            ValidarId(req.IdAnuncio);
            ValidarId(req.IdPerguntador);
            ValidarId(req.IdRespondedor);
        }
        public void Responder(Models.TbPerguntaResposta req)
        {
            ValidarTexto(req.DsResposta);
            ValidarId(req.IdAnuncio);
            ValidarId(req.IdPerguntador);
            ValidarId(req.IdRespondedor);
        }
        public void Anunciar(Models.TbAnuncio anuncio)
        {
            ValidarTexto(anuncio.DsTitulo);
            ValidarData(anuncio.DtPublicacao);
            ValidarId(anuncio.IdUsuario);
            ValidarTexto(anuncio.TpProduto);
            ValidarTexto(anuncio.DsCep);
            ValidarTexto(anuncio.DsCidade);
            ValidarTexto(anuncio.DsCondicao);
            ValidarTexto(anuncio.DsEstado);
            ValidarTexto(anuncio.DsTamanho);
            ValidarTexto(anuncio.DsGenero);
            ValidarTexto(anuncio.NmMarca);
        }
        public void InativarAnuncio(Models.TbAnuncio Anuncios)
        {
            ValidarTexto(Anuncios.DsSituacao);
        }
        public void ValidarAlterarAnuncio(Models.TbAnuncio anuncio)
        {
            ValidarTexto(anuncio.DsTitulo);
            ValidarData(anuncio.DtPublicacao);
            ValidarId(anuncio.IdAnuncio);
            ValidarId(anuncio.IdUsuario);
            ValidarTexto(anuncio.TpProduto);
            ValidarTexto(anuncio.DsCep);
            ValidarTexto(anuncio.DsCidade);
            ValidarTexto(anuncio.DsCondicao);
            ValidarTexto(anuncio.DsEstado);
            ValidarTexto(anuncio.DsTamanho);
            ValidarTexto(anuncio.DsGenero);
            ValidarTexto(anuncio.NmMarca);
            ValidarPreco(anuncio.VlPreco);
        }




        public void ValidarPreco(decimal? preco)
        {
            if(preco == null || preco == 0.00m) throw new ArgumentException("Verifique o preço.");    
        }
        public void ValidarData(DateTime? data)
        {
            if(data == new DateTime()) throw new ArgumentException("Data incorreta.");    
        }
        public void ValidarTexto(string texto)
        {
            if(string.IsNullOrEmpty(texto)) throw new ArgumentException("Campo obrigatorio.");    
        }
        public void ValidarId(int? id)
        {
            if(id <= 0) throw new ArgumentException("Id inválido.");
        }
        public void ValidarTermos(bool? concordo)
        {
            if(concordo == false) throw new ArgumentException("É obrigatorio concordar com os termos.");
        }

    }
}