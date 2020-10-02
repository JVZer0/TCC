namespace Backend.Models.Request
{
    public class AnuncioRoupasRequest
    {
        public class Login
        {
            public string Username { get; set; }
            public string Senha { get; set; }
        }
    }
}