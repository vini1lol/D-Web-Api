using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class User : IdentityUser<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        override
        public int Id { get; set; }
        override
        public string UserName { get; set; }
        public string Password { get; set; }
        override
        public string? Email { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco? Endereco { get; set; }
        public IEnumerable<Compra>? Compras { get; set; }
    }
}
