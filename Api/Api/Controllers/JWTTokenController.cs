using Api.Context;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTTokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;

        public JWTTokenController(IConfiguration configuration, ApplicationDbContext applicationDbContext, SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _context = applicationDbContext;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            if (user != null && user.UserName != null && user.Password != null)
            {
                var userData = await GetUser(user.UserName, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                if (userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject ),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: signIn
                        );

                    var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }

                    return BadRequest("Usuario invalido");
                }
                else
                {
                    return BadRequest("Usuario invalido");
                }

            }
            else
            {
                return BadRequest("Usuario invalido");
            }
        }

        [HttpGet]
        public async Task<User> GetUser(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }

    }
}
