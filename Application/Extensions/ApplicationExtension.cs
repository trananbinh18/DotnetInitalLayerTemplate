using System;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ApplicationExtension
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddScoped<IPostServices, PostServices>();
        }
    }
}
