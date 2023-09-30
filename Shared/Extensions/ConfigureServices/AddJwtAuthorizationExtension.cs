using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.BaseModels.Jwt;
using Shared.BaseModels.LoginObject;

namespace Shared.Extensions.ConfigureServices;

public static class AddJwtAuthorizationExtension
{
    public static IServiceCollection AddJwtAuthorization(this IServiceCollection services, JwtLogin jwtLogin)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = jwtLogin.Issuer,
                ValidAudience = jwtLogin.Audience,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtLogin.Key ?? string.Empty)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });
        services.AddAuthorization(config =>
        {
            config.AddPolicy(JwtPolicies.User, JwtPolicies.UserPolicy());
        });

        return services;
    }
}