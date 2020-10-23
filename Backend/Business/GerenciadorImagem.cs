using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Backend.Business
{
    public class GerenciadorImagem
    {
        public List<Models.TbImagem> GerarMuitosNomes(List<IFormFile> req)
        {
            List<Models.TbImagem> resp = new List<Models.TbImagem>();
            if(req == null || req.Count == 0)
            {
                IFormFile xama = null;
                string dale = GerarNovoNome(xama);
                Models.TbImagem foi = new Models.TbImagem();
                foi.ImgAnuncio = dale;
                resp.Add(foi);
            }
            else{
                foreach (IFormFile Imagens in req)
                {
                    string nome = GerarNovoNome(Imagens);
                    Models.TbImagem fo = new Models.TbImagem();
                    fo.ImgAnuncio = nome;
                    resp.Add(fo);
                }
            }
            return resp;
        }
        public string GerarNovoNome(IFormFile f)
        {
            if(f == null){
                return "semimagem.PNG";
            }
            else{
                string novoNome = Guid.NewGuid().ToString();
                novoNome = novoNome + Path.GetExtension(f.FileName);
                return novoNome;
            }
        }

        public void SalvarFoto(string nome, IFormFile foto)
        {
            if(nome == "semimagem.PNG")
            {
                return ;
            }
            else{
                string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);

                using (FileStream fs = new FileStream(caminhoFoto, FileMode.Create))
                {
                    foto.CopyTo(fs);
                }
            }
        }

        public byte[] LerFoto(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            byte[] foto = File.ReadAllBytes(caminhoFoto);

            return foto;
        }

        public string GerarContentType(string nome)
        {
            string extensao = System.IO.Path.GetExtension(nome).Replace(".", "");
            string contentType = "application/" + extensao;
            return contentType;
        }
    }
}