using Api.Dto;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDto> BuscarPorId(int id);
        Task<List<ProdutoDto>> BuscarTodosProdutos();
        Task<ProdutoDto> Adicionar(Produto produto);
        Task<ProdutoDto> Atualizar(int id, Produto produto);
        Task<bool> Apagar(int id);
    }
}
