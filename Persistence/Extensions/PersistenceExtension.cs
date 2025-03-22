
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Implementations;
using Persistence.Repositories.Interfaces;

namespace Persistence.Extensions
{
    public static class PersistenceExtension
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
