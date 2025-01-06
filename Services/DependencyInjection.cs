using System;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Services
{
    public static class DependencyInjectionthis
    {
       public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
