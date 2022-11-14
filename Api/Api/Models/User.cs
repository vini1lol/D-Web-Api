using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco? Endereco { get; set; }
        public IEnumerable<Compra>? Compras { get; set; }
    }
}
