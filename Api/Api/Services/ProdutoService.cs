using Api.Context;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdutoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Produto> BuscarPorId(int id)
        {
            Produto produto = await _dbContext.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);

            if (produto == null)
            {
                throw new Exception($"Produto com ID {id} não foi encontrado no banco de dados.");
            }

            return produto;
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> Atualizar(int id, Produto produto)
        {
            Produto produtoAlterar = await BuscarPorId(id);

            if (produtoAlterar == null)
            {
                throw new Exception($"Produto com ID {id} não foi encontrado no banco de dados.");
            }

            produtoAlterar.Nome = produto.Nome;
            produtoAlterar.Descricao = produto.Descricao;
            produtoAlterar.Preco = produto.Preco;

            _dbContext.Produtos.Update(produtoAlterar);
            await _dbContext.SaveChangesAsync();

            return produtoAlterar;
        }

        public async Task<bool> Apagar(int id)
        {
            Produto produtoApagar = await BuscarPorId(id);

            if (produtoApagar == null)
            {
                throw new Exception($"Produto com ID {id} não foi encontrado no banco de dados.");
            }

            produtoApagar.Status = false;

            _dbContext.Produtos.Update(produtoApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
