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
            return anuncios;
        }
        public List<Models.TbAnuncio> AnunciosPorMes(DateTime mesInicio, DateTime mesFim)
        {
            validadores.ValidarData(mesInicio);
            validadores.ValidarData(mesFim);
            List<Models.TbAnuncio> anuncios = databaseRelatorios.AnunciosPorMes(mesInicio, mesFim);
            return anuncios;
        }
        public List<Models.TbUsuario> Top10Anunciantes()
        {
            List<Models.TbUsuario> users = databaseRelatorios.Top10Anunciantes();
            return users;
        }
        public List<Models.TbAnuncio> Top10ProdutosMaisAnunciados()
        {
            List<Models.TbAnuncio> anuncios = databaseRelatorios.Top10ProdutosMaisAnunciados();
            return anuncios;
        }
        public List<Models.TbAnuncio> Top5EstadosComMaisAnuncios(string Estado)
        {
            validadores.ValidarTexto(Estado);
            List<Models.TbAnuncio> anuncios = databaseRelatorios.Top5EstadosComMaisAnuncios(Estado);
            return anuncios;
        }
    }
}