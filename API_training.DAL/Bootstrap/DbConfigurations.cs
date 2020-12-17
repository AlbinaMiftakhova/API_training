using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API_training.DAL.Contexts;
using System.Data.SqlClient;

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
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiTrainingContext>(
                options => options.UseNpgsql(
                    configuration["ApiTrainingContext"],
            builder => builder.MigrationsAssembly(typeof(ApiTrainingContext).Assembly.FullName))
            );
        }
    }
}
