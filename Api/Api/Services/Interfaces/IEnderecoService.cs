using Api.Dto;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<EnderecoDto> BuscarPorId(int id);
        Task<EnderecoDto> BuscarPorIdUsuario(int idUsuario);
        Task<EnderecoDto> Adicionar(Endereco endereco);
        Task<EnderecoDto> Atualizar(int id, Endereco endereco);
        Task<bool> Apagar(int id);
    }
}
