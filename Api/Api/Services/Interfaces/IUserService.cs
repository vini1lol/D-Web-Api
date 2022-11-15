using Api.Dto;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> BuscarPorId(int id);
        Task<List<UserDto>> BuscarTodosUsuarios();
        Task<UserDto> Adicionar(User user);
        Task<UserDto> Atualizar(int id, User user);
        Task<bool> Apagar(int id);
    }
}
