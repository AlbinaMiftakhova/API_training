using API_training.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API_training.DAL.Fluent
{
    /// <summary>
    /// Методы расширения для FluentApi Configs.
    /// </summary>
    public static class FluentExtentions
    {
        /// <summary>
        /// Конфигурация для слабой сущности.
        /// </summary>
        /// <typeparam name="T">Слабая сущность.</typeparam>
        /// <typeparam name="T1">Сущность-ссылка 1.</typeparam>
        /// <typeparam name="T2">Сущность-ссылка 2.</typeparam>
        /// <param name="builder">Билдер сущности.</param>
        /// <param name="withMany1">Дерево для связи 1.</param>
        /// <param name="withMany2">Дерево для связи 2.</param>
        public static void BaseEntityWithLinksConfig<T, T1, T2>(this EntityTypeBuilder<T> builder,
                                                           Expression<Func<T1, IEnumerable<T>>> withMany1 = default,
                                                           Expression<Func<T2, IEnumerable<T>>> withMany2 = default)
                      where T : BaseEntityWithLinks<T1, T2>
                      where T1 : BaseEntity
                      where T2 : BaseEntity
        {
            builder.ToTable($"{typeof(T).Name}s");

            builder.HasKey(e => new { e.Entity1Id, e.Entity2Id });

            builder.Property(e => e.Entity1Id)
                   .HasColumnName($"{typeof(T1).Name}Id");
            builder.Property(e => e.Entity2Id)
                   .HasColumnName($"{typeof(T2).Name}Id");

            builder.HasOne(e => e.Entity1)
                   .WithMany(withMany1)
                   .HasForeignKey(e => e.Entity1Id);

            builder.HasOne(e => e.Entity2)
                   .WithMany(withMany2)
                   .HasForeignKey(e => e.Entity2Id);
        }
    }
}
