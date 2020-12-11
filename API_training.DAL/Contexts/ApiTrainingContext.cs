using API_training.DAL.Domain;
using API_training.DAL.Fluent;
using Microsoft.EntityFrameworkCore;

namespace API_training.DAL.Contexts
{
    /// <summary>
    /// Контекст для работы с данными БД "Книги"
    /// </summary>
    public class ApiTrainingContext : DbContext
    {
        /// <summary>
        /// Библиотеки
        /// </summary>
        public DbSet<Libraries> Libraries { get; set; }

        /// <summary>
        /// Книги
        /// </summary>
        public DbSet<Books> Books { get; set; }

        /// <summary>
        /// Наличие в библиотеке
        /// </summary>
        public DbSet<Available> Availables { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="ApiTrainingContext"/>
        /// </summary>
        /// <param name="options">Опции для конфигурации контекста</param>
        public ApiTrainingContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        /// <summary>
        /// Правила создания сущностей.
        /// </summary>
        /// <param name="builder">Билдер моделей.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AvailabilityConfig());

        }
    }
}
