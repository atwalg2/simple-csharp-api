
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace simple_csharp_api.Core.DependencyInjection
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddAppConfig(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}