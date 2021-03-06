using System;
using System.Collections.Generic;

namespace Backend.Business
{
    public class RelatorioBusiness
    {
        Database.RelatoriosDatabase databaseRelatorios = new Database.RelatoriosDatabase();
        Validadores validadores = new Validadores();
        public List<Models.TbAnuncio> AnunciosPorDia(DateTime dia)
        {
            validadores.ValidarData(dia);
            List<Models.TbAnuncio> anuncios = databaseRelatorios.AnunciosPorDia(dia);
            if(anuncios == null || anuncios.Count == 0) throw new ArgumentException("Nenhum anuncio encontrado.");
            return anuncios;
        }
        public List<Models.TbAnuncio> AnunciosPorMes(int mesInicio, int mesFim)
        {
            if(mesInicio <= 0) throw new ArgumentException("O mês não pode ser menor ou igual a zero.");
            if(mesFim <= 0) throw new ArgumentException("O mês não pode ser menor ou igual a zero.");
            if(mesFim < mesInicio) throw new ArgumentException("O mês de inicio não pode ser maior que o mês final na pesquisa.");
            List<Models.TbAnuncio> anuncios = databaseRelatorios.AnunciosPorMes(mesInicio, mesFim);
            if(anuncios.Count == 0) throw new ArgumentException("Nenhum anuncio encontrado.");
            return anuncios;
        }
        public List<Models.TbUsuario> Top10Anunciantes()
        {
            List<Models.TbUsuario> users = databaseRelatorios.Top10Anunciantes();
            if(users == null || users.Count == 0) throw new ArgumentException("Nenhum anunciante encontrado.");
            return users;
        }
        public List<Models.TbAnuncio> Top10ProdutosMaisAnunciados()
        {
            List<Models.TbAnuncio> anuncios = databaseRelatorios.Top10ProdutosMaisAnunciados();
            if(anuncios == null || anuncios.Count == 0) throw new ArgumentException("Nenhum produto encontrado.");
            return anuncios;
        }
        public List<Models.TbAnuncio> QtdAnunciosPorEstado()
        {
            List<Models.TbAnuncio> anuncios = databaseRelatorios.QtdAnunciosPorEstado();
            if(anuncios == null || anuncios.Count == 0) throw new ArgumentException("Nenhum anuncio encontrado.");
            return anuncios;
        }
    }
}