using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using hashing_salting_password.DTO;
using hashing_salting_password.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace hashing_salting_password.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(UserDTO userDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Secret must be inside the appsettings.
            var key = Encoding.UTF8.GetBytes("fkdasnfjdfnjnsofjasfbjdksfbjkdsfdfdsfdagfdgdf");
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userDTO.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}