using _3T.Framework.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3T.Gestproj.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureGestProjCommonDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureCommonDependencies(configuration);
            //services.Configure<PeristenceConfig>(options => {
            //    configuration.GetSection("PersistenceConfig");
            //});
            //services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<PeristenceConfig>>().Value);
            return services;
        }
    }
}
