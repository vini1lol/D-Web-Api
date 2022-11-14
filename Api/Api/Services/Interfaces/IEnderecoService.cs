using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> BuscarPorId(int id);
        Task<Endereco> BuscarPorIdUsuario(int idUsuario);
        Task<Endereco> Adicionar(Endereco endereco);
        Task<Endereco> Atualizar(int id, Endereco endereco);
        Task<bool> Apagar(int id);
    }
}
