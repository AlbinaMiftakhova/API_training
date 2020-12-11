using System.ComponentModel.DataAnnotations;

namespace API_training.DAL.Domain
{
    /// <summary>
    /// Наличие в библиотеке
    /// </summary>
     public class Available : BaseEntity
    {
        /// <summary>
        /// Количество доступных единиц.
        /// </summary>
        [Required]
        public long Count { get; set; }

        /// <summary>
        /// Библиотека
        /// </summary>
        public Libraries Libraries { get; set; }

        /// <summary>
        /// Книги
        /// </summary>
        public Books Books { get; set; }
    }
}
