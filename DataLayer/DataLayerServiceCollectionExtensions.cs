using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DataLayerServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayerServices<T, TRequest, TResponse>(this IServiceCollection services, IConfiguration configuration)
        where T : class, new()
        where TRequest : class, new()
        where TResponse : class, new()
    {

        // services.AddTransient<IDbContext, GenericDbContext<HRServiceDToRes>>(); 
        services.AddTransient<GenericDbContext<T,TResponse>>();
        services.AddTransient<IRepository<T,TRequest, TResponse>, Repository<T,TRequest, TResponse>>();
        //var provider = services.BuildServiceProvider();
        //var consumerService = provider.GetService<GenericDbContext<TResponse>>();

        return services;
    }


}


}