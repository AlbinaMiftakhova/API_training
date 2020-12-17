using API_training.DAL.Domain;
using API_training.Database.Domain;
using System.ComponentModel.DataAnnotations;


namespace API_training.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Books"/>
    /// </summary>
    public class BookDTO : BaseDto
    {
        /// <summary>
        /// Автор книги
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int PublishingYear { get; set; }

        /// <summary>
        /// Провайдер.
        /// </summary>
        public GenreDTO Genre { get; set; }
    }
}
