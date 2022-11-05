using Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services
{
    public class TokenService 
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public static string GerarJWT(User usuario)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
        //    var key = Encoding.UTF8.GetBytes(jwt.Key);

        //    var claimsIdentity = new ClaimsIdentity(new Claim[]
        //    {
        //        new Claim(ClaimTypes.Name, usuario.UserName)
        //    });

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = claimsIdentity,
        //        Issuer = jwt.Issuer,
        //        Audience = jwt.Audience,
        //        Expires = DateTime.UtcNow.AddHours(jwt.Expires),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    return tokenHandler.WriteToken(token);
        //}
    }
}
