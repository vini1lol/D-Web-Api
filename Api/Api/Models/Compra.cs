using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompraId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<Produto> Produtos { get; set; }

    }
}
