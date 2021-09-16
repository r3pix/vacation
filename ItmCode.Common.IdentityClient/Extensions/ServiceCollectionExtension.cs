using ItmCode.Common.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItmCode.Common.Identity.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = configuration["Identity:Url"];
                    options.RequireHttpsMetadata = false;
                    options.Audience = configuration["Identity:Audience"];
                });

            services.AddAuthorization();

            return services;
        }
    }
}