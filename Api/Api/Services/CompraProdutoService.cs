using Api.Context;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class CompraProdutoService : ICompraProdutoService
    {
        private readonly CompraProduto _compraProduto = new();
        private readonly ApplicationDbContext _dbContext;

        public CompraProdutoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CompraProduto> Adicionar(int idCompra, int idProduto)
        {
            _compraProduto.CompraId = idCompra;
            _compraProduto.ProdutoId = idProduto;

            await _dbContext.CompraProdutos.AddAsync(_compraProduto);
            await _dbContext.SaveChangesAsync();

            return _compraProduto;
        }

        public async Task<bool> Apagar(int id)
        {
            List<CompraProduto> compraProdutoApagar = await BuscarTodasPorCompras(id);

            if (compraProdutoApagar.Count() == 0)
            {
                return false;
            }

            var i = 0;
            do
            {
                _dbContext.CompraProdutos.Remove(compraProdutoApagar[i]);
                i++;
            } while (compraProdutoApagar.Count() != i);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<List<CompraProduto>> BuscarTodasPorCompras(int id)
        {
            return _dbContext.CompraProdutos.Where(x => x.CompraId == id).ToListAsync();
        }
    }
}
