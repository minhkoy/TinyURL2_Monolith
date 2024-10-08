using Microsoft.Extensions.DependencyInjection;
using TinyURL2.Business.Interfaces;
using TinyURL2.Infrastructure.Repository;

namespace TinyURL2.Infrastructure
{
    public static class InfrastructureServicesExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
