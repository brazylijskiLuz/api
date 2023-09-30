using Microsoft.AspNetCore.Authorization;

namespace Shared.BaseModels.Jwt;

public static class JwtPolicies
{
    public const string User = "User";
    public static AuthorizationPolicy UserPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(User).Build();
    }
}