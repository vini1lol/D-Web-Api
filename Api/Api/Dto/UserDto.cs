using Api.Models;

namespace Api.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnderecoDto? Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}
