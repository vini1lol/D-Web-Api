using Api.Context;
using Api.Dto;
using Api.Models;
using Api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Claims;

namespace Api.Services
{
    public class CompraService : ICompraService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompraService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CompraDto> BuscarPorId(int id)
        {
            var compra = await _dbContext.Compras
                .Include(x => x.User)
                .Include(x => x.Produtos)
                .FirstOrDefaultAsync(x => x.CompraId == id);

            var dto = new CompraDto();
            if (compra != null)
            {
                var produtosDto = new List<ProdutoDto>();

                if (compra.Produtos != null && compra.Produtos.Any())
                {
                    foreach (var produto in compra.Produtos)
                    {
                        var produtodto = _mapper.Map<ProdutoDto>(produto);

                        produtosDto.Add(produtodto);
                    }
                }

                dto = _mapper.Map<CompraDto>(compra);
                dto.Produtos = produtosDto;
            }

            return dto;
        }

        public async Task<List<CompraDto>> BuscarTodasCompras(int idUsuario)
        {
            var compras = await _dbContext.Compras
                .Include(x => x.User)
                .Where(x => x.UserId == idUsuario).ToListAsync();

            var dtos = new List<CompraDto>();
            if (compras != null && compras.Any())
            {
                foreach (var compra in compras)
                {
                    var dto = _mapper.Map<CompraDto>(compra);

                    dtos.Add(dto);
                }
            }

            return dtos;
        }

        public async Task<CompraDto> Adicionar(Compra compra)
        {
            await _dbContext.AddAsync(compra);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<CompraDto>(compra);

            return dto;
        }

        public async Task<CompraDto> Atualizar(int id, Compra compra)
        {
            var compraAlterar = _dbContext.Compras
                .Include(x => x.User)
                .Include(x => x.Produtos)
                .FirstOrDefault(x => x.CompraId == id);

            if (compraAlterar == null)
            {
                throw new Exception($"Compra com ID {id} não foi encontrada no banco de dados.");
            }

            compraAlterar.Quantidade = compra.Quantidade;
            compraAlterar.DataCadastro = compra.DataCadastro;

            _dbContext.Update(compraAlterar);
            await _dbContext.SaveChangesAsync();

            var produtosDto = new List<ProdutoDto>();

            if (compraAlterar.Produtos != null && compraAlterar.Produtos.Any())
            {
                foreach (var produto in compraAlterar.Produtos)
                {
                    var produtodto = _mapper.Map<ProdutoDto>(produto);

                    produtosDto.Add(produtodto);
                }
            }

            var dto = _mapper.Map<CompraDto>(compraAlterar);
            dto.Produtos = produtosDto;

            return dto;
        }

        public async Task<bool> Apagar(int id)
        {
            var compraApagar = _dbContext.Compras
                .FirstOrDefault(x => x.CompraId == id);

            if (compraApagar == null)
            {
                throw new Exception($"Compra com ID {id} não foi encontrada no banco de dados.");
            }

            compraApagar.Ativo = false;

            _dbContext.Update(compraApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
