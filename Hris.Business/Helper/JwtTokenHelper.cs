using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Helper
{
    public interface IJwtTokenHelper
    {
        string GetToken(string email);
        Task<bool> IsTokenValid(string token);
    }
    internal class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly IConfiguration _configuration;
        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetToken(string param)
        {
            var key = _configuration.GetSection("Security:JwtKey").Value;
            var keyBytes = Encoding.UTF8.GetBytes(key!);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                                          new Claim(ClaimTypes.Email, param),
                 }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                                  new SymmetricSecurityKey(keyBytes),
                                  SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<bool> IsTokenValid(string token)
        {
            JwtSecurityToken securityToken = new JwtSecurityToken(token);
            var signingKeys = new JsonWebKeySet(token).GetSigningKeys();
            JwtSecurityTokenHandler securityHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                IssuerSigningKeys = signingKeys
            };
            var data = await securityHandler.ValidateTokenAsync(securityToken, validationParameters);
            return data.IsValid;

        }
    }
}
