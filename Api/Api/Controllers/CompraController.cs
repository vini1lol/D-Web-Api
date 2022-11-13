using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        private readonly ICompraService _compraService;
        private readonly ICompraProdutoService _compraProdutoService;

        public CompraController(ICompraService compraService, ICompraProdutoService compraProdutoService)
        {
            _compraService = compraService;
            _compraProdutoService = compraProdutoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compra>>> BuscarTodasCompras()
        {
            List<Compra> compras = await _compraService.BuscarTodasCompras();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> BuscarPorId(int id)
        {
            Compra compra = await _compraService.BuscarPorId(id);
            return Ok(compra);
        }

        [HttpPost("{idProduto}")]
        public async Task<ActionResult<Compra>> Adicionar([FromBody] Compra compra, int idProduto)
        {
            Compra compraAdicionar = await _compraService.Adicionar(compra);

            await _compraProdutoService.Adicionar(compraAdicionar.CompraId, idProduto);

            return Ok(compraAdicionar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Compra>> Atualizar([FromBody] Compra compra, int id)
        {
            Compra compraAtualizar = await _compraService.Atualizar(id, compra);
            return Ok(compraAtualizar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Compra>> Apagar(int id)
        {
            bool compraProdutoApagado = await _compraProdutoService.Apagar(id);
            if (compraProdutoApagado) {
                bool apagado = await _compraService.Apagar(id);
                return Ok(apagado);
            }
            else
            {
                return BadRequest($"Relação de Produtos com ID {id} de Compras não foi encontrada no banco de dados.");
            }
        }
    }
}
