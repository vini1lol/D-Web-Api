using Api.Context;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> BuscarPorId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<List<User>> BuscarTodosUsuarios()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> Adicionar(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Atualizar(int id, User user)
        {
            User userAlterar = await BuscarPorId(id);

            if (userAlterar == null)
            {
                return null;
            }

            userAlterar.UserName = user.UserName;
            userAlterar.Email = user.Email;
            userAlterar.Password = user.Password;
            userAlterar.Telefone = user.Telefone;
            userAlterar.DataNascimento = user.DataNascimento;

            _dbContext.Users.Update(userAlterar);
            await _dbContext.SaveChangesAsync();

            return userAlterar;
        }

        public async Task<bool> Apagar(int id)
        {
            User userApagar = await BuscarPorId(id);

            if (userApagar == null)
            {
                return false;
            }

            _dbContext.Users.Remove(userApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
