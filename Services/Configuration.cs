using DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Services
{
    public static class DataLayerServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLayerServices<T, Rs,Rq>(this IServiceCollection services, IConfiguration configuration)
             where T : class, new()
             where Rs : class, new()
             where Rq : class, new()
        {
            services.AddDataLayerServices<T,Rs,Rq >(configuration);
            services.AddTransient<Repository<T,Rs,Rq>>();

            return services;
        }
    }
    public class DataLayerSettings
    {
        public string DefaultConnection { get; set; }
    }

}