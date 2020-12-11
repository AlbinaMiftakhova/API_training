using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace API_training.DAL.Contexts
{
    /// <summary>
    /// Фабрика для создания нового контекста в процессе миграций.
    /// </summary>
    internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApiTrainingContext>
    {
        /// <summary>
        /// Создание контекста для миграций
        /// </summary>
        /// <param name="args">Строковые аршументы миграций</param>
        /// <returns>Контекст</returns>
        public ApiTrainingContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", false, true)
                               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                                        true, true)
                               .AddEnvironmentVariables()
                               .Build();

            var connectionString = configuration.GetConnectionString(nameof(ApiTrainingContext));

            var builder = new DbContextOptionsBuilder<ApiTrainingContext>()
                   .UseNpgsql(connectionString, __options =>
                   {
                       __options.MigrationsAssembly(typeof(ApiTrainingContext).Assembly.FullName);
                   });

            var context = new ApiTrainingContext(builder.Options);

            return context;
        }
    }
}
