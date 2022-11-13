using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
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
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> BuscarPorId(int id)
        {
            User user = await _userService.BuscarPorId(id);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> Adicionar([FromBody] User user)
        {
            User userAdicionar = await _userService.Adicionar(user);
            return Ok(userAdicionar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Atualizar([FromBody] User user, int id)
        {
            User produtoAtualizar = await _userService.Atualizar(id, user);
            return Ok(produtoAtualizar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Apagar(int id)
        {
            bool apagado = await _userService.Apagar(id);
            return Ok(apagado);
        }
    }
}
