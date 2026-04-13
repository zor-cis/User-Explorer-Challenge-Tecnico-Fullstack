using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserExplorer.Core.Domain.Interfaces;
using UserExplorer.Infrastructure.Persistence.Context;
using UserExplorer.Infrastructure.Persistence.Repository;

namespace UserExplorer.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration) 
        {
            #region Context

            services.AddDbContext<UserExplorerContext>(opt => 
            opt.UseSqlite(configuration.GetConnectionString("defaultConection")));

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
