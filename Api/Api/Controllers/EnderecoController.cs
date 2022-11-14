using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Endereco>> BuscarPorIdUsuario(int idUsuario)
        {
            Endereco endereco = await _enderecoService.BuscarPorIdUsuario(idUsuario);
            return Ok(endereco);
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> Adicionar([FromBody] Endereco endereco)
        {
            Endereco enderecoAdicionar = await _enderecoService.Adicionar(endereco);
            return Ok(enderecoAdicionar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Endereco>> Atualizar([FromBody] Endereco endereco, int id)
        {
            Endereco enderecoAtualizar = await _enderecoService.Atualizar(id, endereco);
            return Ok(enderecoAtualizar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> Apagar(int id)
        {
            bool apagado = await _enderecoService.Apagar(id);
            return Ok(apagado);
        }
    }
}
