using API_training.Database.Domain;
using System.ComponentModel.DataAnnotations;


namespace API_training.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Books"/>
    /// </summary>
    public class DTOBooks
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
        /// Издательство
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        [MaxLength(4)]
        public int PublishingYear { get; set; }
    }
}
