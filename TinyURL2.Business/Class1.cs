using Microsoft.Extensions.DependencyInjection;
using TinyURL2.Business.Interfaces;
using TinyURL2.Business.Services;

namespace TinyURL2.Business
{
    public static class AddBusinessServicesExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUrlService, UrlService>();
        } 
    }
}
