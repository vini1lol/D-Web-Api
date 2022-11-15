using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [Route("obterTodas/{idUsuario}")]
        [HttpGet]
        public async Task<ActionResult> BuscarTodasCompras(int idUsuario)
        {
            var compras = await _compraService.BuscarTodasCompras(idUsuario);
            return Ok(compras);
        }

        [Route("obterPorId/{id}")]
        [HttpGet]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            var compra = await _compraService.BuscarPorId(id);
            return Ok(compra);
        }

        [Route("adicionar/{idProduto}")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] Compra compra, int idProduto)
        {
            var compraAdicionar = await _compraService.Adicionar(compra);

            return Ok(compraAdicionar);
        }

        [Route("atualizar/{id}")]
        [HttpPut]
        public async Task<ActionResult> Atualizar([FromBody] Compra compra, int id)
        {
            var compraAtualizar = await _compraService.Atualizar(id, compra);
            return Ok(compraAtualizar);
        }

        [Route("apagar/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Apagar(int id)
        {
            bool apagado = await _compraService.Apagar(id);
            if (apagado)
            {
                return Ok(apagado);
            }
            else
            {
                return BadRequest($"Relação de Produtos com ID {id} de Compras não foi encontrada no banco de dados.");
            }
        }
    }
}
