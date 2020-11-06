using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Business
{
    public class ImagemBusiness
    {
        Database.ImagemDatabase databaseImagem = new Database.ImagemDatabase();
        Business.AnuncioBusiness businessAnuncio = new Business.AnuncioBusiness();
        Business.GerenciadorImagem gerenciadorImagem = new Business.GerenciadorImagem();
        Validadores validadores = new Validadores();
        public Models.TbImagem ApagarImagem(int IdImagem, int IdAnuncio)
        {
            validadores.ValidarId(IdImagem);
            validadores.ValidarId(IdAnuncio);
            Models.TbImagem imagem = databaseImagem.ConsultarImagem(IdImagem, IdAnuncio);
            if(imagem == null) throw new ArgumentException("Imagem não encontrada, ou você não é o dono dessa imagem.");
            Models.TbAnuncio anuncio = businessAnuncio.ConsultadoAnuncioDetalhado(IdAnuncio);
            if(anuncio.TbImagem.Count() <= 1)
            {
                Models.TbImagem a = new Models.TbImagem();
                a.ImgAnuncio = "semimagem.PNG";
                a.IdAnuncio = IdAnuncio;
                databaseImagem.InserirImagem(a);
            }
            return databaseImagem.ApagarImagem(IdImagem, IdAnuncio);
        }
        public Models.TbImagem InserirImagem(Models.TbImagem req)
        {
            Models.TbAnuncio val = businessAnuncio.ConsultadoAnuncioDetalhado(req.IdAnuncio);
            if(val.TbImagem.Count() >= 10) throw new ArgumentException("Você só pode inserir 10 imagens por anuncio.");
            return databaseImagem.InserirImagem(req);
        }
        public List<Models.TbImagem> InserirVariasImagens(List<Models.TbImagem> req)
        {
            if(req.Count >= 10) throw new ArgumentException("Você só pode inserir 10 imagens por anuncio.");
            Models.TbAnuncio val = businessAnuncio.ConsultadoAnuncioDetalhado(req.FirstOrDefault().IdAnuncio);
            if(val.TbImagem.Count() >= 10) throw new ArgumentException("Você só pode inserir 10 imagens por anuncio.");
            return databaseImagem.InserirVariasImagens(req);
        }
        
    }
}