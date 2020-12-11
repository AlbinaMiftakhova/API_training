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
        [Required]
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания книги
        /// </summary>
        [Required]
        public int PublishingYear { get; set; }

    }
}
