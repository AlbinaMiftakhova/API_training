using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API_training.DAL.Contexts;

namespace API_training.DAL.Bootstrap
{
    /// <summary>
    /// Конфигурации БД
    /// </summary>
    public static class DbConfigurations
    {
        /// <summary>
        /// Подключение DbContext
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация</param>
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration, string _connection)
        {
            services.AddDbContext<ApiTrainingContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString(_connection),
                    builder => builder.MigrationsAssembly(typeof(ApiTrainingContext).Assembly.FullName))

            );
        }
    }
}
