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
            List<Models.Response.RelatorioResponse.Top10Anunciantes> relatorioTopClientes = new List<Models.Response.RelatorioResponse.Top10Anunciantes>();

            foreach(Models.TbUsuario item in a)
            {
                Models.Response.RelatorioResponse.Top10Anunciantes topClientes = new Models.Response.RelatorioResponse.Top10Anunciantes();

                topClientes.Email = item.DsEmail;
                topClientes.Nome = item.NmUsuario;
                if(item.TbAnuncio.Count == 0) continue;
                topClientes.QtdAnuncios = item.TbAnuncio.Count;
                topClientes.Celular = item.DsCelular;
                topClientes.SomaDosPrecoDosAnuncios = item.TbAnuncio.Sum(x => x.VlPreco);

                relatorioTopClientes.Add(topClientes);
            }

            relatorioTopClientes = relatorioTopClientes.OrderByDescending(x => x.QtdAnuncios).ToList();
            return relatorioTopClientes.Take(10).ToList();
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