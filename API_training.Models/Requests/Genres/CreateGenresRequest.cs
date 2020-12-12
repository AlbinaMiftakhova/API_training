using System.ComponentModel.DataAnnotations;

namespace API_training.Models.Requests.Genres
{
    /// <summary>
    /// Запрос на создание жанра
    /// </summary>
    public class CreateGenresRequest
    {
        /// <summary>
        /// Название жанра
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
