namespace Api.Models
{
    public class UsuarioToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
