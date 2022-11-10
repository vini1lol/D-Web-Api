using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class CompraProduto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompraProdutoId { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }

        [ForeignKey(nameof(CompraId))]
        public Compra Compras { get; set; }

        [ForeignKey(nameof(ProdutoId))]
        public Produto Produtos { get; set; }
    }
}
