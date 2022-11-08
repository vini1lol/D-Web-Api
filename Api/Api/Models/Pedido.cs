using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public ICollection<Produto> Produtos { get; set; }

    }
}
