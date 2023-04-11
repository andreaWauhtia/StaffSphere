using _3T.Framework.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _3T.Gestproj.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection BuildApplication(this IServiceCollection services, IConfiguration configuration)
        {
           
            return services;
        }
    }
}