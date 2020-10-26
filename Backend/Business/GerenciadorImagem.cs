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
        public string GerarNovoNome(IFormFile i)
        {
            if(i == null){
                return "semimagem.PNG";
            }
            else{
                string novoNome = Guid.NewGuid().ToString();
                novoNome = novoNome + Path.GetExtension(i.FileName);
                return novoNome;
            }
        }

        public void SalvarImagem(string nome, IFormFile imagem)
        {
            if(nome == "semimagem.PNG")
            {
                return;
            }
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);

            using (FileStream fs = new FileStream(caminhoFoto, FileMode.Create))
            {
                imagem.CopyTo(fs);
            }
        }

        public byte[] LerImagem(string nome)
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
        public void DeletarImagem(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            File.Delete(caminhoFoto);
        }
    }
}