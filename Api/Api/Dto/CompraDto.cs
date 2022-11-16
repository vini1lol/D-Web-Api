using Api.Models;

namespace Api.Dto
{
    public class CompraDto
    {
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int CompraId { get; set; }

        public List<ProdutoDto>? Produtos{get;set;}
    }
}
