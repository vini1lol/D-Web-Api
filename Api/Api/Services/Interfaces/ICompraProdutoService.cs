using Api.Models;

namespace Api.Services.Interfaces
{
    public interface ICompraProdutoService
    {
        Task<List<CompraProduto>> BuscarTodasPorCompras(int id);
        Task<CompraProduto> Adicionar(int idCompra, int idProduto);
        Task<bool> Apagar(int id);
    }
}
