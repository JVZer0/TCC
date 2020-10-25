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
        Validadores validadores = new Validadores();
        public Models.TbImagem ApagarImagem(int IdImagem, int IdAnuncio)
        {
            validadores.ValidarId(IdImagem);
            validadores.ValidarId(IdAnuncio);
            Models.TbImagem imagem = databaseImagem.ConsultarImagem(IdImagem, IdAnuncio);
            if(imagem == null) throw new ArgumentException("Imagem não encontrada, ou você não é o dono dessa imagem.");
            return databaseImagem.ApagarImagem(IdImagem, IdAnuncio);
        }
        public Models.TbImagem InserirImagem(Models.TbImagem req)
        {
            Models.TbAnuncio val = businessAnuncio.ConsultadoAnuncioDetalhado(req.IdAnuncio);
            if(val.TbImagem.Count() >= 10) throw new ArgumentException("Você só pode inserir 10 imagens por anuncio.");
            return databaseImagem.InserirImagem(req);
        }
        
    }
}