using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompraId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public int UserId { get; set; }
        public bool Ativo { get; set; }


        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public IEnumerable<Produto>? Produtos { get; set; }

        public Compra()
        {
            Ativo = true;
        }
    }
}
