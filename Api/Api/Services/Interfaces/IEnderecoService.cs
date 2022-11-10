using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> BuscarPorId(int id);
        Task<List<Endereco>> BuscarTodosEnderecos();
        Task<Endereco> Adicionar(Endereco endereco);
        Task<Endereco> Atualizar(int id, Endereco endereco);
        Task<bool> Apagar(int id);
    }
}
