namespace Backend.Models.Response
{
    public class AnuncioRoupasResponse
    {
        public class Login
        {
            public int IdUsuario { get; set; }
            public string NomeUsuario { get; set; }
            public string CPF { get; set; }
            public string RG { get; set; }
            public string Email { get; set; }
            public int IdLogin { get; set; }

        }
    }
}