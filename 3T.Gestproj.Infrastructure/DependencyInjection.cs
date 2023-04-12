using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _3T.StaffSphere.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection BuildInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            //services.Configure<PeristenceConfig>(options => {
            //    configuration.GetSection("PersistenceConfig");
            //});
            //services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<PeristenceConfig>>().Value);
            return services;
        }
    }
}