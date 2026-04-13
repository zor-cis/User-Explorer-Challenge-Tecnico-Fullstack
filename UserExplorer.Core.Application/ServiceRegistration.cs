using Microsoft.Extensions.DependencyInjection;
using UserExplorer.Core.Application.Interfaces;
using UserExplorer.Core.Application.Services;

namespace UserExplorer.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services) 
        { 
            services.AddScoped<IUserService, UserService>();
        }
    }
}
