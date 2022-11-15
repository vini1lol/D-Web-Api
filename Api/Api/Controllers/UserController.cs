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
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("buscarTodos")]
        [HttpGet]
        public async Task<ActionResult> BuscarTodosUsuarios()
        {
            var users = await _userService.BuscarTodosUsuarios();
            if (users == null)
            {
                return NotFound("Usuário(s) não encontrado(s)");
            }
            return Ok(users);
        }

        [Route("buscarPorId/{id}")]
        [HttpGet]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            var user = await _userService.BuscarPorId(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(user);
        }

        [Route("adicionar")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] User user)
        {
            var userAdicionar = await _userService.Adicionar(user);
            var url = Url.Action(nameof(BuscarPorId), new { id = userAdicionar.UserId }) ?? $"/{userAdicionar.UserId}";
            return Created(url, userAdicionar);
        }

        [Route("atualizar/{id}")]
        [HttpPut]
        public async Task<ActionResult> Atualizar([FromBody] User user, int id)
        {
            var userAtualizar = await _userService.Atualizar(id, user);
            if (userAtualizar == null)
            {
                return BadRequest($"Usuário com ID {id} não foi encontrado no banco de dados.");
            }
            return Ok(userAtualizar);
        }

        [Route("apagar/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Apagar(int id)
        {
            bool apagado = await _userService.Apagar(id);
            if (!apagado)
            {
                return NotFound($"Usuário com ID {id} não foi encontrado no banco de dados.");
            }
            return Ok("Usuário apagado com sucesso");
        }
    }
}
