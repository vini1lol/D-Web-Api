using Api.Models;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [Route("buscarTodos")]
        [HttpGet]
        public async Task<ActionResult> BuscarTodosProdutos()
        {
            List<Produto> produtos = await _produtoService.BuscarTodosProdutos();
            if (produtos == null)
            {
                return NotFound("Produto(s) não encontrado(s)");
            }
            return Ok(produtos);
        }

        [Route("buscarPorId/{id}")]
        [HttpGet]
        public async Task<ActionResult<Produto>> BuscarPorId(int id)
        {
            Produto produto = await _produtoService.BuscarPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }

        [Route("adicionar")]
        [HttpPost]
        public async Task<ActionResult<Produto>> Adicionar([FromBody] Produto produto)
        {
            Produto produtoAdicionar = await _produtoService.Adicionar(produto);
            var url = Url.Action(nameof(BuscarPorId), new { id = produtoAdicionar.ProdutoId }) ?? $"/{produtoAdicionar.ProdutoId}";
            return Created(url, produtoAdicionar); ;
        }

        [Route("atualizar/{id}")]
        [HttpPut]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produto, int id)
        {
            Produto produtoAtualizar = await _produtoService.Atualizar(id, produto);
            if (produtoAtualizar == null)
            {
                return BadRequest($"Produto com ID {id} não foi encontrado no banco de dados.");
            }
            return Ok(produtoAtualizar);
        }

        [Route("apagar/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Produto>> Apagar(int id)
        {
            bool apagado = await _produtoService.Apagar(id);
            if (!apagado)
            {
                return NotFound($"Produto com ID {id} não foi encontrado no banco de dados.");
            }
            return Ok("Produto apagado com sucesso");
        }
    }
}
