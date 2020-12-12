using API_training.Models.Requests.Books;
using System.ComponentModel.DataAnnotations;

namespace API_training.Models.Requests.Genres
{
    /// <summary>
    /// Запрос на изменение жанра
    /// </summary>
    public class UpdateGenresRequest : CreateGenresRequest
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
