using Api.Context;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly ApplicationDbContext _dbContext;

        public EnderecoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Endereco> BuscarPorId(int id)
        {
            return await _dbContext.Enderecos.FirstOrDefaultAsync(x => x.EnderecoId == id);
        }

        public async Task<Endereco> BuscarPorIdUsuario(int idUsuario)
        {
            return await _dbContext.Enderecos.FirstOrDefaultAsync(x => x.UserId == idUsuario);
        }

        public async Task<Endereco> Adicionar(Endereco endereco)
        {
            await _dbContext.Enderecos.AddAsync(endereco);
            await _dbContext.SaveChangesAsync();

            return endereco;
        }

        public async Task<Endereco> Atualizar(int id, Endereco endereco)
        {
            Endereco enderecoAlterar = await BuscarPorId(id);

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

            return enderecoAlterar;
        }

        public async Task<bool> Apagar(int id)
        {
            Endereco enderecoApagar = await BuscarPorId(id);

            if (enderecoApagar == null)
            {
                throw new Exception($"Endereço com ID {id} não foi encontrado no banco de dados.");
            }

            enderecoApagar.Ativo = false;

            _dbContext.Update(enderecoApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
