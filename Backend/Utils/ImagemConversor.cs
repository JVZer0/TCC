using System;
using System.Collections.Generic;

namespace Backend.Utils
{
    public class ImagemConversor
    {
        public Models.Response.AnuncioRoupasResponse.Imagem ConverterImagemParaResponse(Models.TbImagem req)
        {
            Models.Response.AnuncioRoupasResponse.Imagem resp = new Models.Response.AnuncioRoupasResponse.Imagem();
            resp.IdDoAnuncio = req.IdAnuncio;
            resp.IdImagem = req.IdImagem;
            resp.TextoImagem = req.ImgAnuncio;
            return resp;
        }
        public List<Models.Response.AnuncioRoupasResponse.Imagem> ConverterVariasImagensParaResponse(List<Models.TbImagem> req)
        {
            List<Models.Response.AnuncioRoupasResponse.Imagem> resp = new List<Models.Response.AnuncioRoupasResponse.Imagem>();
            foreach (Models.TbImagem item in req)
            {
                Models.Response.AnuncioRoupasResponse.Imagem primeiro = this.ConverterImagemParaResponse(item);
                resp.Add(primeiro);
            }
            return resp;
        }
    }
}