using IdentiService.Application.Interfaces.Services;
using IdentityService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Services
{
    public  class AccessTokenGenerator : IAccessTokenGenerator
    {
        private readonly IConfiguration _configuration;
        public AccessTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            try
            {
                
                var secretKey = _configuration["JWT-SECRET-KEY"];
                var issuer = _configuration["JWT-ISSUER"];
                var audience = _configuration["JWT-AUDIENCE"];
                var expiryInHours = int.TryParse(_configuration["JWT-EXPIRE-HOUR"], out var hours) ? hours : 2;



                if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
                {

                    throw new Exception($"Missing JWT configuration values. SecretKey: {secretKey}, Issuer: {issuer}, Audience: {audience}");
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                
                var claims = new[]
                {

                    new Claim(ClaimTypes.Role, user.UserType.ToString()),    
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)

                };

                
                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(expiryInHours),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {        
                throw ;
            }
        }

    }
}
