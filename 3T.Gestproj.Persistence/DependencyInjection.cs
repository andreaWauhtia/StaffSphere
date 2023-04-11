using _3T.Framework.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _3T.Gestproj.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection BuildPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistenceDependencies(configuration);
            //services.Configure<PeristenceConfig>(options => {
            //    configuration.GetSection("PersistenceConfig");
            //});
            //services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<PeristenceConfig>>().Value);
            return services;
        }
    }
}