
using hackyeah.App.Application.Jwt;

namespace hackyeah.App.Application.Services;

public interface IJwtAuth
{
    public Task<GeneratedToken> GenerateJwt(Guid id, string email);
}