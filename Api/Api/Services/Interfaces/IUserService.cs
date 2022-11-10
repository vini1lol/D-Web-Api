using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> BuscarPorId(int id);
        Task<List<User>> BuscarTodosUsuarios();
        Task<User> Adicionar(User user);
        Task<User> Atualizar(int id, User user);
        Task<bool> Apagar(int id);
    }
}
