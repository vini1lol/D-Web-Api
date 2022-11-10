using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> BuscarPorId(int id);
        Task<List<Produto>> BuscarTodosProdutos();
        Task<Produto> Adicionar(Produto produto);
        Task<Produto> Atualizar(int id, Produto produto);
        Task<bool> Apagar(int id);
    }
}
