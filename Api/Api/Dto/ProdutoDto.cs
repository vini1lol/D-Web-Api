namespace Api.Dto
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; } = true;

        public List<CompraDto>? Compras { get; set; }
    }

}
