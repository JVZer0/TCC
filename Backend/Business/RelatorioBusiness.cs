using System;

namespace Backend.Business
{
    public class RelatorioBusiness
    {
        public string AnunciosPorDia(DateTime dia)
        {
            return "AnunciosPorDia";
        }
        public string AnunciosPorMes(DateTime mesInicio, DateTime mesFim)
        {
            return "AnunciosPorMes";
        }
        public string Top10Clientes()
        {
            return "Top10Clientes";
        }
        public string Top10Produtos()
        {
            return "Top10Produtos";
        }
    }
}