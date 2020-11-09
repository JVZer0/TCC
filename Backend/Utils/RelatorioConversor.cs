using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Utils
{
    public class RelatorioConversor
    {
        public List<Models.Response.RelatorioResponse.AnunciosPorDia> ConversorAnunciosPorDia(List<Models.TbAnuncio> a)
        {
            List<Models.Response.RelatorioResponse.AnunciosPorDia> porDia = new List<Models.Response.RelatorioResponse.AnunciosPorDia>();
            foreach (Models.TbAnuncio item in a)
            {
                Models.Response.RelatorioResponse.AnunciosPorDia sim = new Models.Response.RelatorioResponse.AnunciosPorDia();
                sim.Cliente = item.IdUsuarioNavigation.NmUsuario;
                sim.Dia = item.DtPublicacao;
                sim.Preco = item.VlPreco;
                sim.TipoProduto = item.TpProduto;
                porDia.Add(sim);
            }
            return porDia;
        }
        public List<Models.Response.RelatorioResponse.AnunciosPorMes> ConversorAnunciosPorMes(DateTime mesIncio, DateTime mesFim, List<Models.TbAnuncio> a)
        {
            List<Models.Response.RelatorioResponse.AnunciosPorMes> resp = new List<Models.Response.RelatorioResponse.AnunciosPorMes>();
            for(int i = mesIncio.Month; i <= mesFim.Month; i++)
            {
                Models.Response.RelatorioResponse.AnunciosPorMes relatorioResponse = new Models.Response.RelatorioResponse.AnunciosPorMes();

                List<Models.TbAnuncio> consultasSeparasPorMes = a.Where(x => x.DtPublicacao.Value.Month == i).ToList();

                relatorioResponse.Mes = i;
                relatorioResponse.QtdAnuncios = consultasSeparasPorMes.Count;
                relatorioResponse.SomaDosPrecoDosAnuncios = consultasSeparasPorMes.Sum(x => x.VlPreco);

                resp.Add(relatorioResponse);  
            }
            return resp;
        }
        public List<Models.Response.RelatorioResponse.Top10Anunciantes> ConversorTop10Anunciantes(List<Models.TbUsuario> a)
        {
            return null;
        }
        public List<Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados> ConversorTop10ProdutosMaisAnunciados(List<Models.TbAnuncio> a)
        {
            return null;
        }
        public List<Models.Response.RelatorioResponse.Top5EstadosComMaisAnuncios> ConversorTop5EstadosComMaisAnuncios(List<Models.TbAnuncio> a)
        {
            return null;
        }
    }
}