using Api.Context;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class CompraProdutoService : ICompraProdutoService
    {
        private readonly ApplicationDbContext _dbContext;

        public CompraProdutoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CompraProduto> Adicionar(CompraProduto compraProduto)
        {
            await _dbContext.CompraProdutos.AddAsync(compraProduto);
            await _dbContext.SaveChangesAsync();

            return compraProduto;
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompraProduto>> BuscarTodasPorCompras(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompraProduto>> BuscarTodasPorProdutos(int id)
        {
            throw new NotImplementedException();
        }
    }
}
