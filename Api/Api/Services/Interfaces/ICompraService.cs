using Api.Dto;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface ICompraService
    {
        Task<CompraDto> BuscarPorId(int id);
        Task<List<CompraDto>> BuscarTodasCompras(int idUsuario);
        Task<CompraDto> Adicionar(Compra compra);
        Task<CompraDto> Atualizar(int id, Compra compra);
        Task<bool> Apagar(int id);
    }
}
