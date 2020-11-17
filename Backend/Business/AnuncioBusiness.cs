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
        public List<Models.TbAnuncio> ConsultarAnuncios(string BarraPesquisa, string Estado, string Cidade, string Genero, string Condicao, int NPagina)
        {
            if(string.IsNullOrEmpty(BarraPesquisa) || BarraPesquisa == "BarraPesquisa") { BarraPesquisa = "";};
            if(string.IsNullOrEmpty(Estado) || Estado == "Estado") { Estado = "";};
            if(string.IsNullOrEmpty(Cidade) || Cidade == "Cidade") { Cidade = "";};
            if(string.IsNullOrEmpty(Genero) || Genero == "Genero" || Genero == "Gênero") { Genero = "";};
            if(string.IsNullOrEmpty(Condicao) || Condicao == "Condicao") { Condicao = "";};
            if(NPagina < 0) throw new ArgumentException("Página não disponível.");

            List<Models.TbAnuncio> anuncios = databaseAnuncio.ConsultarAnuncios(BarraPesquisa, Estado, Cidade, Genero, Condicao);
            if(anuncios.Count == 0) throw new ArgumentException("Nenhum anuncio encontrado.");
            if(Math.Ceiling(Convert.ToDecimal(anuncios.Count()/NPagina)) < NPagina) throw new ArgumentException("Página não disponível.");
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
            if(req.DsPergunta == "") throw new ArgumentException("Verifique a sua pergunta.");
            if(req.DsPergunta.Length > 255) throw new ArgumentException("A pergunta não pode ter mais que 255 caracteres.");
            return databaseAnuncio.Perguntar(req);
        }
        public Models.TbPerguntaResposta Responder(Models.TbPerguntaResposta req)
        {
            validadores.Responder(req);
            Models.TbPerguntaResposta paraValidarRespondedor = databaseAnuncio.ConsultarTBPergundaERespota(req.IdPerguntaResposta);
            if(paraValidarRespondedor.IdRespondedor != req.IdRespondedor) throw new ArgumentException("Você não é o dono desse anuncio. Você não pode responder perguntas dele.");
            if(req.DsResposta == "") throw new ArgumentException("Verifique a sua resposta.");
            if(req.DsResposta.Length > 255) throw new ArgumentException("A resposta não pode ter mais que 255 caracteres.");
            return databaseAnuncio.Responder(req);
        }
        public Models.TbAnuncio Anunciar(Models.TbAnuncio anuncio)
        {
            validadores.Anunciar(anuncio);
            if(anuncio.TbImagem.Count > 10) throw new ArgumentException("Você só pode colocar 10 imagens no anuncio.");
            if(anuncio.VlPreco <= 0) throw new ArgumentException("O valor não pode ser 0 ou negativo");
            if(anuncio.DsTitulo.Length > 100) throw new ArgumentException("O título não pode ter mais de 100 caracteres.");
            if(anuncio.DsDescricao.Length > 255) throw new ArgumentException("A descrição não pode ter mais de 255 caracteres.");
            if(anuncio.TpProduto.Length > 20) throw new ArgumentException("O tipo do produto não pode ter mais de 20 caracteres.");
            if(anuncio.NmMarca.Length > 70) throw new ArgumentException("A marca não pode ter mais de 70 caracteres.");
            if(anuncio.DsTamanho.Length > 50) throw new ArgumentException("O tamanho não pode ter mais de 50 caracteres.");
            if(anuncio.DsCidade.Length > 130) throw new ArgumentException("A cidade não pode ter mais de 130 caracteres.");
            try
            {
                int cep = Convert.ToInt32(anuncio.DsCep.Replace("-","").Replace(" ",""));
            }
            catch (System.Exception)
            {
                throw new ArgumentException("CEP não pode ter letras nem simbolos.");
            }
            if(anuncio.DsCep.Contains(" ")) throw new ArgumentException("O CEP não pode ter espaços.");
            return databaseAnuncio.Anunciar(anuncio);
        }
        public List<Models.TbAnuncio> ConsultarMeusAnuncios(int IdUsuario)
        {
            validadores.ValidarId(IdUsuario);
            return databaseAnuncio.ConsultarMeusAnuncios(IdUsuario);
        }
        public void DeletarAnuncio(int IdAnuncio, int IdUsuario)
        {
            validadores.ValidarId(IdAnuncio);
            validadores.ValidarId(IdUsuario);
            Models.TbAnuncio ValidarUsuario = databaseAnuncio.ConsultarAnuncioDetalhado(IdAnuncio);
            if(ValidarUsuario.IdUsuario != IdUsuario) throw new ArgumentException("Você não é o dono desse anuncio.");
            databaseAnuncio.DeletarAnuncio(IdAnuncio);
        }
        public Models.TbAnuncio InativarAnuncio(int IdAnuncio)
        {
            validadores.ValidarId(IdAnuncio);
            return databaseAnuncio.InativarAnuncio(IdAnuncio);
        }
        public Models.TbAnuncio AnuncioVendido(int IdAnuncio)
        {
            validadores.ValidarId(IdAnuncio);
            return databaseAnuncio.AnuncioVendido(IdAnuncio);
        }
        public Models.TbAnuncio AlterarAnuncio(Models.TbAnuncio NovoAnuncio)
        {
            validadores.ValidarAlterarAnuncio(NovoAnuncio);
            Models.TbAnuncio resp = databaseAnuncio.ConsultarAnuncioDetalhado(NovoAnuncio.IdAnuncio);
            if(resp == null) throw new ArgumentException("Você não é o dono desse anuncio.");
            if(resp.IdUsuario != NovoAnuncio.IdUsuario)throw new ArgumentException("Você não é o dono desse anuncio.");
            if(NovoAnuncio.TbImagem.Count > 10) throw new ArgumentException("Você só pode colocar 10 imagens no anuncio.");
            if(NovoAnuncio.VlPreco <= 0) throw new ArgumentException("O valor não pode ser 0 ou negativo");
            if(NovoAnuncio.DsTitulo.Length > 100) throw new ArgumentException("O título não pode ter mais de 100 caracteres.");
            if(NovoAnuncio.DsDescricao.Length > 255) throw new ArgumentException("A descrição não pode ter mais de 255 caracteres.");
            if(NovoAnuncio.TpProduto.Length > 20) throw new ArgumentException("O tipo do produto não pode ter mais de 20 caracteres.");
            if(NovoAnuncio.NmMarca.Length > 70) throw new ArgumentException("A marca não pode ter mais de 70 caracteres.");
            if(NovoAnuncio.DsTamanho.Length > 50) throw new ArgumentException("O tamanho não pode ter mais de 50 caracteres.");
            if(NovoAnuncio.DsCidade.Length > 130) throw new ArgumentException("A cidade não pode ter mais de 50 caracteres.");
            try
            {
                int cep = Convert.ToInt32(NovoAnuncio.DsCep.Replace("-","").Replace(" ",""));
            }
            catch (System.Exception)
            {
                throw new ArgumentException("CEP não pode ter letras nem simbolos.");
            }
            if(NovoAnuncio.DsCep.Contains(" ")) throw new ArgumentException("O CEP não pode ter espaços.");
            resp = databaseAnuncio.AlterarAnuncio(NovoAnuncio);
            return resp;
        }
        public Models.TbAnuncio AtivarAnuncio(int IdAnuncio)
        {
            validadores.ValidarId(IdAnuncio);
            return databaseAnuncio.AtivarAnuncio(IdAnuncio);
        }

        public decimal ConsultarNPaginas(string BarraPesquisa, string Estado, string Cidade, string Genero, string Condicao)
        {
            if(string.IsNullOrEmpty(BarraPesquisa) || BarraPesquisa == "BarraPesquisa") { BarraPesquisa = "";};
            if(string.IsNullOrEmpty(Estado) || Estado == "Estado") { Estado = "";};
            if(string.IsNullOrEmpty(Cidade) || Cidade == "Cidade") { Cidade = "";};
            if(string.IsNullOrEmpty(Genero) || Genero == "Genero" || Genero == "Gênero") { Genero = "";};
            if(string.IsNullOrEmpty(Condicao) || Condicao == "Condicao") { Condicao = "";};

            List<Models.TbAnuncio> anuncios = databaseAnuncio.ConsultarAnuncios(BarraPesquisa, Estado, Cidade, Genero, Condicao);
            decimal a = Math.Ceiling(Convert.ToDecimal(anuncios.Count()/6.0));
            return a;
        }
    }
}