using Api.Context;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Api.Dto;
using AutoMapper;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> BuscarPorId(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            var dto = new UserDto();
            if (user != null)
            {
                dto = _mapper.Map<UserDto>(user);
            }

            return dto;
        }

        public async Task<List<UserDto>> BuscarTodosUsuarios()
        {
            var users = await _dbContext.Users.ToListAsync();

            var dtos = new List<UserDto>();
            if (users != null && users.Any())
            {
                foreach (var user in users)
                {
                    var dto = _mapper.Map<UserDto>(user);
                    dtos.Add(dto);
                }
            }

            return dtos;
        }

        public async Task<UserDto> Adicionar(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<UserDto>(user);

            return dto;
        }

        public async Task<UserDto> Atualizar(int id, User user)
        {
            var userAlterar = _dbContext.Users.FirstOrDefault(x=> x.UserId == id);

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

            var dto = _mapper.Map<UserDto>(user);

            return dto;
        }

        public async Task<bool> Apagar(int id)
        {
            User userApagar = _dbContext.Users.FirstOrDefault(x => x.UserId == id);

            if (userApagar == null)
            {
                return false;
            }

            userApagar.Ativo = false;

            _dbContext.Update(userApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
