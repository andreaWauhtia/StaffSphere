using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _3T.Framework.Application;
using _3T.Framework.Application.Configuration;
using System.Reflection;
using MediatR;

namespace _3T.StaffSphere.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection BuildStaffSphereApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddApplication(configuration);
            //services.Configure<PeristenceConfig>(options => {
            //    configuration.GetSection("PersistenceConfig");
            //});
            //services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<PeristenceConfig>>().Value);
            return services;
        }
    }
}