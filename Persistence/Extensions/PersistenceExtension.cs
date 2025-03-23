
using System;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
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
            RunMigrations(configuration);
            serviceCollection.AddScoped<IPostRepository, PostRepository>();
        }

        public static void RunMigrations(IConfiguration configuration)
        {
            // No need to build-in service, only run migrations
            using var tempServiceProvider = (new ServiceCollection()).AddFluentMigratorCore().ConfigureRunner(c =>
            {
                c.AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("DBConnectionString"))
                .ScanIn(AppDomain.CurrentDomain.GetAssemblies()).For.Migrations();
            })
            .AddLogging(lb => lb.AddFluentMigratorConsole()).BuildServiceProvider(false);

            using var scope = tempServiceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

    }
}

