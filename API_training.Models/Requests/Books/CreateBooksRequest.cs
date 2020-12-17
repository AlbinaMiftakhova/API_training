using System.ComponentModel.DataAnnotations;

namespace API_training.Models.Requests.Books
{
    /// <summary>
    /// Запрос на создание книги
    /// </summary>
    public class CreateBooksRequest
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
        /// Издательство
        /// </summary>
        [Required]
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        [Required]
        public int PublishingYear { get; set; }
    }
}
