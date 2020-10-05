namespace Backend.Models.Response
{
    public class Erro
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }

        public Erro (int cod, string msg){
            this.Mensagem = msg; 
            this.Codigo = cod;
        }
    }
}