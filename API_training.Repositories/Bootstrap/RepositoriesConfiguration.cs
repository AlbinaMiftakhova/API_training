using API_training.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API_training.Repositories.Bootstrap
{
    /// <summary>
    /// Расширения для конфигурации репозиториев
    /// </summary>
    public static class RepositoriesConfiguration
    {
        /// <summary>
        /// Конфигурирование репозиториев
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup</param>
        public static void ConfigureRepositories (this IServiceCollection services)
        {
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IGenresRepository, GenresRepository>();

        }
    }
}
