using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_training.DAL.Domain
{
    /// <summary>
    /// Одежда.
    /// </summary>
    public class Books : BaseEntity
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Автор книги
        /// </summary>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Издатель книги
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания книги
        /// </summary>
        public int PublishingYear { get; set; }

        /// <summary>
        /// Наличие книги в библиотеке
        /// </summary>
        public ICollection<Available> Availability { get; set; }
    }
}
