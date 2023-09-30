using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using hackyeah.App.Application.Jwt;
using hackyeah.App.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace hackyeah.App.Infrastructure.Services;

public class JwtAuth : IJwtAuth
{
    private readonly IConfiguration _configuration;

    public JwtAuth(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<GeneratedToken> GenerateJwt(Guid id, string email)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", id.ToString()),
                new Claim("Email", email),
                new Claim(ClaimTypes.Role, "user")
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Audience = _configuration["Jwt:Audience"]!,
            Issuer = _configuration["Jwt:Issuer"]!,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(new GeneratedToken(tokenHandler.WriteToken(token)));
    }
}