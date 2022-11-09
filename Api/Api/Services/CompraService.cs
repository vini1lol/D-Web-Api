using Api.Context;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class CompraService
    {
        private readonly ApplicationDbContext _dbContext;

        public CompraService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Compra> BuscarPorId(int id)
        {
            return await _dbContext.Compras.FirstOrDefaultAsync(x => x.CompraId == id);
        }

        public async Task<List<Compra>> BuscarTodasCompras()
        {
            return await _dbContext.Compras.ToListAsync();
        }

        public async Task<Compra> Adicionar(Compra compra)
        {
            await _dbContext.Compras.AddAsync(compra);
            await _dbContext.SaveChangesAsync();

            return compra;
        }

        public async Task<Compra> Atualizar(int id, Compra compra)
        {
            Compra compraAlterar = await BuscarPorId(id);

            if (compraAlterar == null)
            {
                throw new Exception($"Compra com ID {id} não foi encontrada no banco de dados.");
            }

            compraAlterar.Descricao = compra.Descricao;
            compraAlterar.DataCadastro = compra.DataCadastro;

            _dbContext.Compras.Update(compraAlterar);
            await _dbContext.SaveChangesAsync();

            return compraAlterar;
        }

        public async Task<bool> Apagar(int id)
        {
            Compra compraApagar = await BuscarPorId(id);

            if (compraApagar == null)
            {
                throw new Exception($"Compra com ID {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Compras.Remove(compraApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
