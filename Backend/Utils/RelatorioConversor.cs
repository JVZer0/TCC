using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Utils
{
    public class RelatorioConversor
    {
        Models.anuncioRoupaContext ctx = new Models.anuncioRoupaContext();
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

                string mes = "";
                switch (i)
                {
                    case 1: mes = "Janeiro"; break;
                    case 2: mes = "Fevereiro"; break;
                    case 3: mes = "Março"; break;
                    case 4: mes = "Abril"; break;
                    case 5: mes = "Maio"; break;
                    case 6: mes = "Junho"; break;
                    case 7: mes = "Julho"; break;
                    case 8: mes = "Agosto"; break;
                    case 9: mes = "Setembro"; break;
                    case 10: mes = "Outubro"; break;
                    case 11: mes = "Novembro"; break;
                    case 12: mes = "Dezembro"; break;
                }

                relatorioResponse.Mes = mes;
                relatorioResponse.QtdAnuncios = consultasSeparasPorMes.Count;
                relatorioResponse.SomaDosPrecoDosAnuncios = consultasSeparasPorMes.Sum(x => x.VlPreco);

                resp.Add(relatorioResponse);  
            }
            return resp;
        }
        public List<Models.Response.RelatorioResponse.Top10Anunciantes> ConversorTop10Anunciantes(List<Models.TbUsuario> a)
        {
            List<Models.Response.RelatorioResponse.Top10Anunciantes> relatorioTopAnunciantes = new List<Models.Response.RelatorioResponse.Top10Anunciantes>();

            foreach(Models.TbUsuario item in a)
            {
                Models.Response.RelatorioResponse.Top10Anunciantes topAnunciantes = new Models.Response.RelatorioResponse.Top10Anunciantes();

                topAnunciantes.Email = item.DsEmail;
                topAnunciantes.Nome = item.NmUsuario;
                if(item.TbAnuncio.Count == 0) continue;
                topAnunciantes.QtdAnuncios = item.TbAnuncio.Count;
                topAnunciantes.Celular = item.DsCelular;
                topAnunciantes.SomaDosPrecoDosAnuncios = item.TbAnuncio.Sum(x => x.VlPreco);

                relatorioTopAnunciantes.Add(topAnunciantes);
            }

            relatorioTopAnunciantes = relatorioTopAnunciantes.OrderByDescending(x => x.QtdAnuncios).ToList();
            return relatorioTopAnunciantes.Take(10).ToList();
        }
        public List<Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados> ConversorTop10ProdutosMaisAnunciados(List<Models.TbAnuncio> a)
        {
            List<Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados> resp = new List<Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados>();
            foreach(Models.TbAnuncio item in a)
            {
                Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados top10Anuncios = new Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados();

                List<Models.TbAnuncio> xama = ctx.TbAnuncio.Where(x => x.TpProduto == item.TpProduto).ToList();

                top10Anuncios.Nome = item.TpProduto;
                top10Anuncios.QtdAnunciada = xama.Count;
                top10Anuncios.TotalGasto = xama.Sum(x => x.VlPreco);
                List<bool> verdade = new List<bool>();
                foreach (Models.Response.RelatorioResponse.Top10ProdutosMaisAnunciados dale in resp)
                {
                    if(dale.Nome.ToLower() != item.TpProduto.ToLower())
                    {
                        verdade.Add(true);
                    } 
                    else
                    {
                        verdade.Add(false);
                    };
                }
                if(verdade.All(x => x == true)) resp.Add(top10Anuncios);
            }
            resp = resp.OrderByDescending(x => x.QtdAnunciada).ToList();

            return resp.Take(10).ToList();
        }
        public List<Models.Response.RelatorioResponse.EstadosComMaisAnuncios> ConversorQtdAnunciosPorEstado(List<Models.TbAnuncio> a)
        {
            List<Models.Response.RelatorioResponse.EstadosComMaisAnuncios> resp = new List<Models.Response.RelatorioResponse.EstadosComMaisAnuncios>();
            foreach(Models.TbAnuncio item in a)
            {
                Models.Response.RelatorioResponse.EstadosComMaisAnuncios AnunciosEstados = new Models.Response.RelatorioResponse.EstadosComMaisAnuncios();

                List<Models.TbAnuncio> xama = ctx.TbAnuncio.Where(x => x.DsEstado == item.DsEstado).ToList();
                List<Models.TbAnuncio> blicadeila = xama.Where(x => x.BtVendido == true).ToList();

                AnunciosEstados.Estado = item.DsEstado;
                AnunciosEstados.QtdAnuncio = xama.Count;
                AnunciosEstados.QtdVendido = blicadeila.Count;
                List<bool> verdade = new List<bool>();
                foreach (Models.Response.RelatorioResponse.EstadosComMaisAnuncios dale in resp)
                {
                    if(dale.Estado != item.DsEstado)
                    {
                        verdade.Add(true);
                    } 
                    else
                    {
                        verdade.Add(false);
                    };
                }
                if(verdade.All(x => x == true)) resp.Add(AnunciosEstados);
            }
            resp = resp.OrderByDescending(x => x.QtdAnuncio).ToList();

            return resp.ToList();
        }
    }
}