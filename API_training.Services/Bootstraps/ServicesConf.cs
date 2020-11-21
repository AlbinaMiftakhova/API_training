using API_training.Services.Interfaces;
using API_training.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API_training.Services.Bootstraps
{
    /// <summary>
    /// Методы расширения для конфигурации сервисов
    /// </summary>
    public static class ServicesConf
    {
        /// <summary>
        /// Конфигурация сервисов
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IBooksInterface, BooksService>();
        }
    }
}
