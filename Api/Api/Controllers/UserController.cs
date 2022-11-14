using Api.Models;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> BuscarTodosUsuarios()
        {
            List<User> users = await _userService.BuscarTodosUsuarios();
            if (users == null)
            {
                return NotFound("Usuário(s) não encontrado(s)");
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> BuscarPorId(int id)
        {
            User user = await _userService.BuscarPorId(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Adicionar([FromBody] User user)
        {
            User userAdicionar = await _userService.Adicionar(user);
            var url = Url.Action(nameof(BuscarPorId), new { id = userAdicionar.UserId }) ?? $"/{userAdicionar.UserId}";
            return Created(url, userAdicionar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Atualizar([FromBody] User user, int id)
        {
            User userAtualizar = await _userService.Atualizar(id, user);
            if (userAtualizar == null)
            {
                return BadRequest($"Usuário com ID {id} não foi encontrado no banco de dados.");
            }
            return Ok(userAtualizar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Apagar(int id)
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
