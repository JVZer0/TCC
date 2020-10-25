using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Business
{
    public class AnuncioBusiness
    {
        Database.AnuncioDatabase databaseAnuncio = new Database.AnuncioDatabase();
        Validadores validadores = new Validadores();
        public List<Models.TbAnuncio> ConsultarAnuncios(string BarraPesquisa, string Estado, string Cidade, string Genero, string Condicao)
        {{}
            if(string.IsNullOrEmpty(BarraPesquisa) || BarraPesquisa == "BarraPesquisa") { BarraPesquisa = "";};
            if(string.IsNullOrEmpty(Estado) || Estado == "Estado") { Estado = "";};
            if(string.IsNullOrEmpty(Cidade) || Cidade == "Cidade") { Cidade = "";};
            if(string.IsNullOrEmpty(Genero) || Genero == "Genero" || Genero == "Gênero") { Genero = "";};
            if(string.IsNullOrEmpty(Condicao) || Condicao == "Condicao") { Condicao = "";};

            List<Models.TbAnuncio> anuncios = databaseAnuncio.ConsultarAnuncios(BarraPesquisa, Estado, Cidade, Genero, Condicao);
            return anuncios;
        }
        public Models.TbAnuncio ConsultadoAnuncioDetalhado(int? IdAnuncio)
        {
            validadores.ValidarId(IdAnuncio);
            Models.TbAnuncio resp = databaseAnuncio.ConsultarAnuncioDetalhado(IdAnuncio);
            if(resp == null) throw new ArgumentException("Anuncio não encontrado.");
            return resp;
        }
        public Models.TbPerguntaResposta Perguntar(Models.TbPerguntaResposta req)
        {
            validadores.Perguntar(req);
            return databaseAnuncio.Perguntar(req);
        }
        public Models.TbPerguntaResposta Responder(Models.TbPerguntaResposta req)
        {
            validadores.Responder(req);
            Models.TbPerguntaResposta paraValidarRespondedor = databaseAnuncio.ConsultarTBPergundaERespota(req.IdPerguntaResposta);
            if(paraValidarRespondedor.IdRespondedor != req.IdRespondedor) throw new ArgumentException("Você não é o dono desse anuncio. Você não pode responder perguntas dele.");
            return databaseAnuncio.Responder(req);
        }
        public Models.TbAnuncio Anunciar(Models.TbAnuncio anuncio)
        {
            validadores.Anunciar(anuncio);
            if(anuncio.TbImagem.Count > 10) throw new ArgumentException("Você só pode colocar 10 imagens no anuncio.");
            return databaseAnuncio.Anunciar(anuncio);
        }
        public List<Models.TbAnuncio> ConsultarMeusAnuncios(int IdUsuario)
        {
            validadores.ValidarId(IdUsuario);
            return databaseAnuncio.ConsultarMeusAnuncios(IdUsuario);
        }
        public void DeletarAnuncio (int IdAnuncio, int IdUsuario)
        {
            validadores.ValidarId(IdAnuncio);
            validadores.ValidarId(IdUsuario);
            Models.TbAnuncio ValidarUsuario = databaseAnuncio.ConsultarAnuncioDetalhado(IdAnuncio);
            if(ValidarUsuario.IdUsuario != IdUsuario) throw new ArgumentException("Você não é o dono desse anuncio.");
            databaseAnuncio.DeletarAnuncio(IdAnuncio);
        }
    }
}