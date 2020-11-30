using API_training.Models.Requests.Books;
using System.ComponentModel.DataAnnotations;

namespace API_training.Models.Requests.Books
{
    /// <summary>
    /// Запрос на изменение книги
    /// </summary>
    public class UpdateBooksRequest : CreateBooksRequest
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
