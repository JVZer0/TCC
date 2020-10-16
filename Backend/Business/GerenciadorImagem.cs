using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Backend.Business
{
    public class GerenciadorImagem
    {
        public byte[] LerFoto(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            byte[] foto = File.ReadAllBytes(caminhoFoto);

            return foto;
        }
        public string GerarContentType(string nome)
        {
            string extensao = System.IO.Path.GetExtension(nome).Replace(".", "");
            string contentType = "image/" + extensao;
            return contentType;
        }
    }
}