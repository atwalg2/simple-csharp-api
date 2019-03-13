using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using simple_csharp_api.Repository;
using simple_csharp_api.users;

namespace simple_csharp_api.Core.DependencyInjection
{
    public static class UserServiceConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.TryAddScoped<IRepository<User>, UserRepository>();
            return services;
        }
    }
}
