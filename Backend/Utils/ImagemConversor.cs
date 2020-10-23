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
    }
}