using _3T.Framework.Common;
using _3T.Framework.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _3T.StaffSphere.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection BuildPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PeristenceConfig>(configuration.GetSection("PeristenceConfig"));

            services.ConfigurePersistenceDependencies(configuration);
           
            return services;
        }
    }
}