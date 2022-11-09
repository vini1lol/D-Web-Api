namespace Api.Models
{
    public class CompraProduto
    {
        public int CompraId { get; set; }
        public Compra Compras { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produtos { get; set; }
    }
}
