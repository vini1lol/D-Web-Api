using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Interfaces
{
    public interface ICompraService
    {
        Task<Compra> BuscarPorId(int id);
        Task<List<Compra>> BuscarTodasCompras();
        Task<Compra> Adicionar(Compra compra);
        Task<Compra> Atualizar(int id, Compra compra);
        Task<bool> Apagar(int id);
    }
}
