using Api.Models;

namespace Api.Services.Interfaces
{
    public interface ICompraProdutoService
    {
        Task<List<CompraProduto>> BuscarTodasPorCompras(int id);
        Task<List<CompraProduto>> BuscarTodasPorProdutos(int id);
        Task<CompraProduto> Adicionar(CompraProduto compraProduto);
        Task<bool> Apagar(int id);
    }
}
