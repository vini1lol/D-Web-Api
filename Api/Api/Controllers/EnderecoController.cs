using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [Route("buscarPorUserId/{idUsuario}")]
        [HttpGet]
        public async Task<ActionResult> BuscarPorIdUsuario(int idUsuario)
        {
            var endereco = await _enderecoService.BuscarPorIdUsuario(idUsuario);
            return Ok(endereco);
        }

        [Route("adicionar")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] Endereco endereco)
        {
            var enderecoAdicionar = await _enderecoService.Adicionar(endereco);
            return Ok(enderecoAdicionar);
        }

        [Route("atualizar/{id}")]
        [HttpPut]
        public async Task<ActionResult> Atualizar([FromBody] Endereco endereco, int id)
        {
            var enderecoAtualizar = await _enderecoService.Atualizar(id, endereco);
            return Ok(enderecoAtualizar);
        }

        [Route("apagar/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Apagar(int id)
        {
            bool apagado = await _enderecoService.Apagar(id);
            if (!apagado)
            {
                return NotFound($"Endereço com ID {id} não foi encontrado no banco de dados.");
            }
            return Ok("Endereço apagado com sucesso");
        }
    }
}
