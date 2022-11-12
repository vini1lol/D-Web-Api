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

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> BuscarTodosProdutos()
        {
            List<Produto> produtos = await _produtoService.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarPorId(int id)
        {
            Produto produto = await _produtoService.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Adicionar([FromBody] Produto produto)
        {
            Produto produtoAdicionar = await _produtoService.Adicionar(produto);
            return Ok(produtoAdicionar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produto, int id)
        {
            produto.ProdutoId = id;
            Produto produtoAtualizar = await _produtoService.Atualizar(id, produto);
            return Ok(produtoAtualizar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Apagar(int id)
        {
            bool apagado = await _produtoService.Apagar(id);
            return Ok(apagado);
        }
    }
}
