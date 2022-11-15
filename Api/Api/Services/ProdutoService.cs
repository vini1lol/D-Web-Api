using Api.Context;
using Api.Dto;
using Api.Models;
using Api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProdutoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProdutoDto> BuscarPorId(int id)
        {
            var produto = await _dbContext.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);

            if (produto == null)
            {
                throw new Exception($"Produto com ID {id} não foi encontrado no banco de dados.");
            }

            var dto = _mapper.Map<ProdutoDto>(produto);

            return dto;
        }

        public async Task<List<ProdutoDto>> BuscarTodosProdutos()
        {
            var produtos = await _dbContext.Produtos.ToListAsync();

            var dtos = new List<ProdutoDto>();
            foreach (var produto in produtos)
            {
                var dto = _mapper.Map<ProdutoDto>(produto);

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<ProdutoDto> Adicionar(Produto produto)
        {
            await _dbContext.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            var dto = new ProdutoDto()
            {
                Descricao = produto.Descricao,
                Nome = produto.Nome,
                ProdutoId = produto.ProdutoId,
                Preco = produto.Preco,
                Status = produto.Status
            };

            return dto;
        }

        public async Task<ProdutoDto> Atualizar(int id, Produto produto)
        {
            var produtoAlterar = _dbContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);

            if (produtoAlterar == null)
            {
                return null;
            }

            produtoAlterar.Nome = produto.Nome;
            produtoAlterar.Descricao = produto.Descricao;
            produtoAlterar.Preco = produto.Preco;

            _dbContext.Produtos.Update(produtoAlterar);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<ProdutoDto>(produtoAlterar);

            return dto;
        }

        public async Task<bool> Apagar(int id)
        {
            var produtoApagar = _dbContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);

            if (produtoApagar == null)
            {
                return false;
            }

            produtoApagar.Status = false;

            _dbContext.Produtos.Update(produtoApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
