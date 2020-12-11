using API_training.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_training.DAL.Fluent
{
    /// <summary>
    /// Конфигурация миграций для <see cref="Available"/>.
    /// </summary>
    public class AvailabilityConfig : IEntityTypeConfiguration<Available>
    {
        /// <summary>
        /// Конфигурирование сущности <see cref="Available"/>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Available> builder)
        {
            builder.BaseEntityWithLinksConfig<Available, Books, Libraries>(
                e => e.Availabilities);

            builder.Property(x => x.Count)
                .IsRequired();

            builder.ToTable("Availabilities");
        }
    }
}
