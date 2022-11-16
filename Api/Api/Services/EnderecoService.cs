using Api.Context;
using Api.Dto;
using Api.Models;
using Api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EnderecoService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EnderecoDto> BuscarPorId(int id)
        {
            var endereco = await _dbContext.Enderecos.FirstOrDefaultAsync(x => x.EnderecoId == id);

            var dto = new EnderecoDto();
            if(endereco != null)
            {
                dto = _mapper.Map<EnderecoDto>(endereco);
            }
            
            return dto;
        }

        public async Task<EnderecoDto> BuscarPorIdUsuario(int idUsuario)
        {
            var endereco =   await _dbContext.Enderecos.FirstOrDefaultAsync(x => x.UserId == idUsuario);
            
            var dto = new EnderecoDto();
            if (endereco != null)
            {
                dto = _mapper.Map<EnderecoDto>(endereco);
            }

            return dto;
        }

        public async Task<EnderecoDto> Adicionar(Endereco endereco)
        {
            await _dbContext.AddAsync(endereco);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<EnderecoDto>(endereco);

            return dto;
        }

        public async Task<EnderecoDto> Atualizar(int id, Endereco endereco)
        {
            Endereco enderecoAlterar = _dbContext.Enderecos.FirstOrDefault(x => x.EnderecoId == id);

            if (enderecoAlterar == null)
            {
                throw new Exception($"Endereço com ID {id} não foi encontrado no banco de dados.");
            }

            enderecoAlterar.Logradouro = endereco.Logradouro;
            enderecoAlterar.CEP = endereco.CEP;
            enderecoAlterar.Numero = endereco.Numero;
            enderecoAlterar.Bairro = endereco.Bairro;
            enderecoAlterar.Cidade = endereco.Cidade;
            enderecoAlterar.Estado = endereco.Estado;

            _dbContext.Enderecos.Update(enderecoAlterar);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<EnderecoDto>(enderecoAlterar);

            return dto;
        }

        public async Task<bool> Apagar(int id)
        {
            var enderecoApagar = _dbContext.Enderecos.FirstOrDefault(x=> x.EnderecoId == id);

            if (enderecoApagar == null)
            {
                return false;
            }

            enderecoApagar.Ativo = false;

            _dbContext.Update(enderecoApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
